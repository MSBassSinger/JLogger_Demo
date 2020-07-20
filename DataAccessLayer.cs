using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Management.Instrumentation;
using Jeff.Jones.JHelpers;

namespace LoggingDemo
{
	/// <summary>
	/// Class used to define the database access for saving log entries
	/// </summary>
	internal class DataAccessLayer
	{
		// Placeholders for constructor parameters.
		private readonly String m_Server = "";
		private readonly String m_DefaultDB = "";
		private readonly Boolean m_UseAuthentication = false;
		private readonly String m_UserName = "";
		private readonly String m_Password = "";
		private readonly Int32 m_ConnectionTimeout = 10;
		private readonly Int32 m_CommandTimeout = 20;
		private readonly Int32 m_PortNumber = 1433;
		private readonly Int32 m_ConnectRetryCount = 3;
		private readonly Int32 m_ConnectRetryInterval = 10;
		private readonly String m_ApplicationName = "";
		private readonly String m_WorkstationID = "";
		private readonly Boolean m_ConnectionPooling = true;

		/// <summary>
		/// Constructor to populate the instance.
		/// </summary>
		/// <param name="server">The SQL Server instance name.</param>
		/// <param name="defaultDB">The database name to use.</param>
		/// <param name="useAuthentication">True if windows authentication, false if SQL Server authentication.</param>
		/// <param name="username">If using SQL Server authentication, provide the login name.  Otherwise, use ""</param>
		/// <param name="password">If using SQL Server authentication, provide the password.  Otherwise, use ""</param>
		/// <param name="connectionTimeout">Time in milliseconds for a connection to timeout.</param>
		/// <param name="commandTimeout">Time in milliseconds for a command to timeout.</param>
		/// <param name="connectRetryCount">(Optional) How many times to try to reconnect before throwing an exception.</param>
		/// <param name="connectRetryInterval">(Optional) How long, in milliseconds, to wait between connection retries.</param>
		/// <param name="applicationName">(Optional) Application name to use in the SQL connection string.</param>
		/// <param name="workstationID">(Optional) name of the workstation to use in the SQL connection string.</param>
		/// <param name="portNumber">(Optional) port number to use for SQL Server listening, if different than the default.</param>
		/// <param name="connectionPooling">(Optional) true to use connection pooling (recommended), false if not.</param>
		public DataAccessLayer(String server,
							   String defaultDB,
							   Boolean useAuthentication,
							   String username,
							   String password,
							   Int32 connectionTimeout,
							   Int32 commandTimeout,
							   Int32 connectRetryCount = 3,
							   Int32 connectRetryInterval = 10,
							   String applicationName = "",
							   String workstationID = "",
							   Int32 portNumber = 1433,
							   Boolean connectionPooling = true)
		{
			m_Server = server ?? "";
			m_DefaultDB = defaultDB ?? "";
			m_UseAuthentication = useAuthentication;
			m_UserName = username ?? "";
			m_Password = password ?? "";
			m_ConnectionTimeout = connectionTimeout;
			m_CommandTimeout = commandTimeout;
			m_ConnectRetryCount = connectRetryCount;
			m_ConnectRetryInterval = connectRetryInterval;

			if (portNumber <= 0)
			{
				m_PortNumber = 1433;
			}
			else
			{
				m_PortNumber = portNumber;
			}

			m_WorkstationID = workstationID ?? "";
			m_ApplicationName = applicationName ?? "";
			m_ConnectionPooling = connectionPooling;
		}

		/// <summary>
		/// Method to build a SQL Server connection string.
		/// </summary>
		/// <returns>Fully formed connection string</returns>
		private String BuildConnectionString()
		{
			String retVal = "";
			SqlConnectionStringBuilder sqlSB = null;

			try
			{

				String server;

				if (m_PortNumber != 1433)
				{
					server = m_Server + ":" + m_PortNumber.ToString(CultureInfo.CurrentCulture);
				}
				else
				{
					server = m_Server;
				}

				sqlSB = new SqlConnectionStringBuilder
				{
					ConnectRetryCount = m_ConnectRetryCount,
					ConnectRetryInterval = m_ConnectRetryInterval,
					ApplicationName = m_ApplicationName,
					ConnectTimeout = m_ConnectionTimeout,
					DataSource = server,
					InitialCatalog = m_DefaultDB,
					IntegratedSecurity = m_UseAuthentication,
					Password = m_Password,
					Pooling = m_ConnectionPooling,
					UserID = m_UserName,
					WorkstationID = m_WorkstationID
				};

				retVal = sqlSB.ConnectionString;
			} // END try

			catch (Exception exUnhandled)
			{
				exUnhandled.Data.Add("Server", m_Server);
				exUnhandled.Data.Add("DefaultDB", m_DefaultDB);
				exUnhandled.Data.Add("UserName", m_UserName);
				exUnhandled.Data.Add("PortNumber", m_PortNumber.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("UseAuthentication", m_UseAuthentication.ToString());
				exUnhandled.Data.Add("ConnectRetryCount", m_ConnectRetryCount.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("ConnectRetryInterval", m_ConnectRetryInterval.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("ApplicationName", m_ApplicationName);
				exUnhandled.Data.Add("ConnectionTimeout", m_ConnectionTimeout.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("WorkstationID", m_WorkstationID);

				throw;
			}  // END catch (Exception eUnhandled)

			finally
			{
				if (sqlSB != null)
				{
					sqlSB.Clear();

					sqlSB = null;
				}
			}  // END finally

			return retVal;
		}  // END BuildConnectionString()

		/// <summary>
		/// A true/false check to see if the connection can be made.
		/// </summary>
		/// <returns></returns>
		public Boolean CheckConnection(out Boolean isAudit)
		{
			Boolean retVal = false;

			SqlConnection sqlConn = null;

			isAudit = false;

			try
			{
				String connString = BuildConnectionString();

				try
				{
					sqlConn = new SqlConnection(connString);

					sqlConn.Open();

					// Check for existence of audit table.
					String dbCheck = $"USE {m_DefaultDB}; SELECT name FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.DBLogAudit') AND Type = N'U'";

					SqlCommand cmd = sqlConn.CreateCommand();

					cmd.CommandText = dbCheck;
					cmd.CommandType = CommandType.Text;
					Object result = cmd.ExecuteScalar();

					if (result != null)
					{
						isAudit = true;
					}

					retVal = true;
				}
				catch (InvalidOperationException exConnOp)
				{
					exConnOp.Data.Add("Check connection", exConnOp.GetFullExceptionMessage(false, false));
					throw;
				}
				catch (SqlException exConnSql)
				{
					exConnSql.Data.Add("ConnectionString", connString);
					throw;
				}
			}  // END try
			catch (Exception exUnhandled)
			{
				exUnhandled.Data.Add("Server", m_Server);
				exUnhandled.Data.Add("DefaultDB", m_DefaultDB);
				exUnhandled.Data.Add("UserName", m_UserName);
				exUnhandled.Data.Add("PortNumber", m_PortNumber.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("UseAuthentication", m_UseAuthentication.ToString());
				exUnhandled.Data.Add("ConnectRetryCount", m_ConnectRetryCount.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("ConnectRetryInterval", m_ConnectRetryInterval.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("ApplicationName", m_ApplicationName);
				exUnhandled.Data.Add("ConnectionTimeout", m_ConnectionTimeout.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("WorkstationID", m_WorkstationID);

				throw;
			}
			finally
			{
				if (sqlConn != null)
				{
					if (sqlConn.State != ConnectionState.Closed)
					{
						sqlConn.Close();
					}

					sqlConn.Dispose();

					sqlConn = null;
				}
			}

			return retVal;
		}  // END public Boolean CheckConnection()

		/// <summary>
		/// Method to execute a query and return data.
		/// For example, query DB log table, return data for date span,
		/// and write it to a log file.
		/// 
		/// The DBReturnValue 
		/// </summary>
		/// <param name="cmd">SQL Command</param>
		/// <param name="isSP">True if a stored procedure, false if not.</param>
		/// <param name="sqlParams">List of parameter objects, or null if no parameters used.</param>
		/// <returns>DBReturnValue instance with results and parameters that have post-execution values.</returns>
		public DBReturnValue ExecuteQuery(String cmd, Boolean isSP, List<SqlParameter> sqlParams)
		{
			DataSet retDS = new DataSet();

			SqlConnection sqlConn = null;

			SqlCommand sqlCmd = null;
			SqlDataAdapter sqlAdapter = null;

			DBReturnValue retVal = new DBReturnValue();

			try
			{
				String connString = BuildConnectionString();
				sqlConn = new SqlConnection(connString);
				sqlCmd = sqlConn.CreateCommand();
				sqlCmd.CommandText = cmd;
				sqlCmd.CommandTimeout = m_CommandTimeout;

				if (isSP)
				{
					sqlCmd.CommandType = CommandType.StoredProcedure;
				}
				else
				{
					sqlCmd.CommandType = CommandType.Text;
				}

				if (sqlParams == null)
				{
					sqlCmd.Parameters.Clear();
				}
				else
				{
					if (sqlParams.Count > 0)
					{
						foreach (SqlParameter sqlParam in sqlParams)
						{
							sqlCmd.Parameters.Add(sqlParam);
						}  // END foreach (SqlParameter sqlParam in sqlParams)
					}  // END if (sqlParams.Count > 0)
				}

				try
				{
					sqlConn.Open();
				}
				catch (InvalidOperationException exConnOp)
				{
					exConnOp.Data.Add("SQL Command", cmd);
					throw;
				}
				catch (SqlException exConnSql)
				{
					exConnSql.Data.Add("ConnectionString", connString);
					throw;
				}

				try
				{
					retDS = new DataSet();
					sqlAdapter = new SqlDataAdapter(sqlCmd);
					retVal.RetCode = sqlAdapter.Fill(retDS);
					retVal.Data = retDS;
				}
				catch (Exception exFill)
				{
					exFill.Data.Add("Failure during fill", exFill.Message);
					throw;
				}

				if (sqlCmd.Parameters != null)
				{
					if (sqlCmd.Parameters.Count > 0)
					{
						if (sqlParams == null)
						{
							sqlParams = new List<SqlParameter>();
						}
						else
						{
							sqlParams.Clear();
						}

						// Since there may be out parameters or return values,
						// they are captured here
						foreach (SqlParameter sqlParam in sqlCmd.Parameters)
						{
							retVal.SQLParams.Add(new SqlParameter
							{
								CompareInfo = sqlParam.CompareInfo,
								DbType = sqlParam.DbType,
								Direction = sqlParam.Direction,
								IsNullable = sqlParam.IsNullable,
								LocaleId = sqlParam.LocaleId,
								Offset = sqlParam.Offset,
								ParameterName = sqlParam.ParameterName,
								Precision = sqlParam.Precision,
								Scale = sqlParam.Scale,
								Size = sqlParam.Size,
								SourceColumn = sqlParam.SourceColumn,
								SourceColumnNullMapping = sqlParam.SourceColumnNullMapping,
								SourceVersion = sqlParam.SourceVersion,
								SqlDbType = sqlParam.SqlDbType,
								SqlValue = sqlParam.SqlValue,
								TypeName = sqlParam.TypeName,
								UdtTypeName = sqlParam.UdtTypeName,
								Value = sqlParam.Value
							});
						}  // END foreach (SqlParameter sqlParam in sqlCmd.Parameters)
					}  // END if (sqlParams.Count > 0)
				}  // ENDF if (sqlParams != null)
			}  // END try
			catch (Exception exUnhandled)
			{
				exUnhandled.Data.Add("Server", m_Server);
				exUnhandled.Data.Add("DefaultDB", m_DefaultDB);
				exUnhandled.Data.Add("UserName", m_UserName);
				exUnhandled.Data.Add("PortNumber", m_PortNumber.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("UseAuthentication", m_UseAuthentication.ToString());
				exUnhandled.Data.Add("ConnectRetryCount", m_ConnectRetryCount.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("ConnectRetryInterval", m_ConnectRetryInterval.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("ApplicationName", m_ApplicationName);
				exUnhandled.Data.Add("ConnectionTimeout", m_ConnectionTimeout.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("WorkstationID", m_WorkstationID);

				retVal.ErrorMessage = exUnhandled.GetFullExceptionMessage(true, true);

				throw;
			}
			finally
			{
				// Do what Momma says - clean up the mess you make. :)
				if (retDS != null)
				{
					retDS.Dispose();

					retDS = null;
				}

				if (sqlAdapter != null)
				{
					sqlAdapter.Dispose();

					sqlAdapter = null;
				}

				if (sqlCmd != null)
				{
					sqlCmd.Dispose();

					sqlCmd = null;
				}

				if (sqlConn != null)
				{
					if (sqlConn.State != ConnectionState.Closed)
					{
						sqlConn.Close();
					}

					sqlConn.Dispose();

					sqlConn = null;
				}
			}

			return retVal;
		}  // END public DBReturnValue ExecuteQuery(String cmd, Boolean isSP, List<SqlParameter> sqlParams)


		/// <summary>
		/// Method to execute SQL that does not return a dataset.
		/// </summary>
		/// <param name="cmd">SQL Command</param>
		/// <param name="isSP">True if a stored procedure, false if not.</param>
		/// <param name="sqlParams">List of parameter objects, or null if no parameters used.</param>
		/// <returns>DBReturnValue instance with results and parameters that have post-execution values.</returns>
		public DBReturnValue ExecuteStatement(String cmd, Boolean isSP, List<SqlParameter> sqlParams)
		{
			SqlConnection sqlConn = null;

			SqlCommand sqlCmd = null;

			DBReturnValue retVal = new DBReturnValue();

			try
			{
				String connString = BuildConnectionString();
				sqlConn = new SqlConnection(connString);
				sqlCmd = sqlConn.CreateCommand();
				sqlCmd.CommandText = cmd;
				sqlCmd.CommandTimeout = m_CommandTimeout;

				if (isSP)
				{
					sqlCmd.CommandType = CommandType.StoredProcedure;
				}
				else
				{
					sqlCmd.CommandType = CommandType.Text;
				}

				if (sqlParams == null)
				{
					sqlCmd.Parameters.Clear();
				}
				else
				{
					if (sqlParams.Count > 0)
					{
						foreach (SqlParameter sqlParam in sqlParams)
						{
							sqlCmd.Parameters.Add(sqlParam);
						}  // END foreach (SqlParameter sqlParam in sqlParams)
					}  // END if (sqlParams.Count > 0)
				}

				try
				{
					sqlConn.Open();
				}
				catch (InvalidOperationException exConnOp)
				{
					exConnOp.Data.Add("SQL Command", cmd);
					throw;
				}
				catch (SqlException exConnSql)
				{
					exConnSql.Data.Add("ConnectionString", connString);
					throw;
				}

				try
				{
					sqlCmd.ExecuteNonQuery();

					retVal.RetCode = 0;
				}
				catch (Exception exFill)
				{
					exFill.Data.Add("Failure during execution.", exFill.Message);
					throw;
				}

				if (sqlCmd.Parameters != null)
				{
					if (sqlCmd.Parameters.Count > 0)
					{
						if (sqlParams == null)
						{
							sqlParams = new List<SqlParameter>();
						}
						else
						{
							sqlParams.Clear();
						}

						// Since there may be out parameters or return values,
						// they are captured here
						foreach (SqlParameter sqlParam in sqlCmd.Parameters)
						{
							retVal.SQLParams.Add(new SqlParameter
							{
								CompareInfo = sqlParam.CompareInfo,
								DbType = sqlParam.DbType,
								Direction = sqlParam.Direction,
								IsNullable = sqlParam.IsNullable,
								LocaleId = sqlParam.LocaleId,
								Offset = sqlParam.Offset,
								ParameterName = sqlParam.ParameterName,
								Precision = sqlParam.Precision,
								Scale = sqlParam.Scale,
								Size = sqlParam.Size,
								SourceColumn = sqlParam.SourceColumn,
								SourceColumnNullMapping = sqlParam.SourceColumnNullMapping,
								SourceVersion = sqlParam.SourceVersion,
								SqlDbType = sqlParam.SqlDbType,
								SqlValue = sqlParam.SqlValue,
								TypeName = sqlParam.TypeName,
								UdtTypeName = sqlParam.UdtTypeName,
								Value = sqlParam.Value
							});
						}  // END foreach (SqlParameter sqlParam in sqlCmd.Parameters)
					}  // END if (sqlParams.Count > 0)
				}  // END if (sqlParams != null)
			}  // END try
			catch (Exception exUnhandled)
			{
				exUnhandled.Data.Add("Server", m_Server);
				exUnhandled.Data.Add("DefaultDB", m_DefaultDB);
				exUnhandled.Data.Add("UserName", m_UserName);
				exUnhandled.Data.Add("PortNumber", m_PortNumber.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("UseAuthentication", m_UseAuthentication.ToString());
				exUnhandled.Data.Add("ConnectRetryCount", m_ConnectRetryCount.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("ConnectRetryInterval", m_ConnectRetryInterval.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("ApplicationName", m_ApplicationName);
				exUnhandled.Data.Add("ConnectionTimeout", m_ConnectionTimeout.ToString(CultureInfo.CurrentCulture));
				exUnhandled.Data.Add("WorkstationID", m_WorkstationID);

				retVal.ErrorMessage = exUnhandled.GetFullExceptionMessage(true, true);

				throw;
			}
			finally
			{
				// Do what your Momma taught you, and clean up your mess. :)
				if (sqlCmd != null)
				{
					sqlCmd.Dispose();

					sqlCmd = null;
				}

				if (sqlConn != null)
				{
					if (sqlConn.State != ConnectionState.Closed)
					{
						sqlConn.Close();
					}

					sqlConn.Dispose();

					sqlConn = null;
				}
			}

			return retVal;
		}  // END public DBReturnValue ExecuteStatement(String cmd, Boolean isSP, List<SqlParameter> sqlParams)
	}   // END private class DataAccessLayer
}
