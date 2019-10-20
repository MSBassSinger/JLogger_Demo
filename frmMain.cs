using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jeff.Jones.JLogger;
using Jeff.Jones.JHelpers;


namespace LoggingDemo
{
	public partial class frmMain : Form
	{

		private LOG_TYPE m_DebugLogOptions = LOG_TYPE.Unspecified;

		/// <summary>
		/// Construct the main form for the demo
		/// </summary>
		public frmMain()
		{
			InitializeComponent();

			// Setup logger options here
			m_DebugLogOptions = LOG_TYPE.Error |
								LOG_TYPE.Informational |
								LOG_TYPE.ShowTimeOnly |
								LOG_TYPE.Warning |
								LOG_TYPE.HideThreadID |
								LOG_TYPE.ShowModuleMethodAndLineNumber |
								LOG_TYPE.System |
								LOG_TYPE.SendEmail;

			// Pick a folder for the file logs
			String filePath = Properties.Settings.Default.LogFolder;

			if (filePath.Trim().Length == 0)
			{
				filePath = CommonHelpers.CurDir + @"\";
				Properties.Settings.Default.LogFolder = filePath;
				Properties.Settings.Default.Save();
			}

			// Provide ability to pick a path for the file logs.
			dlgFolder.SelectedPath = filePath;

			// Populate the file path textbox with a default value.
			txtLogFolder.Text = filePath;

			// The DB option is not selected by default, so the 
			// data entry for it is also disabled.
			grpDBInfo.Enabled = false;

			// The file option is selected by default, so the 
			// data entry for it is enabled.
			grpFileInfo.Enabled = true;

			txtDBServer.Text = Properties.Settings.Default.DBServer;
			txtDatabase.Text = Properties.Settings.Default.Database;
			chkUseWindowsAuthentication.Checked = Properties.Settings.Default.UseWindowsAuthentication;
			txtUserName.Text = Properties.Settings.Default.DBUserName;
			txtPassword.Text = Properties.Settings.Default.DBPassword;
			txtSMTPServer.Text = Properties.Settings.Default.SMTPServer;
			txtSMTPPort.Text = Properties.Settings.Default.SMTPPort.ToString();
			txtLogonEmail.Text = Properties.Settings.Default.SMTPLogonName;
			txtSMTPLogonPassword.Text = Properties.Settings.Default.SMTPLogonPassword;
			txtReplyToAddress.Text = Properties.Settings.Default.ReplyToAddress;
			txtFromAddress.Text = Properties.Settings.Default.FromAddress;

			String sendTo = Properties.Settings.Default.SendToAddresses.Trim();

			if (sendTo.Contains(";"))
			{
				sendTo = sendTo.Replace(";", Environment.NewLine);
			}

			if (sendTo.Contains(","))
			{
				sendTo = sendTo.Replace(",", Environment.NewLine);
			}

			txtToAddresses.Text = sendTo;

			txtLogFolder.Text = Properties.Settings.Default.LogFolder;
			txtPrefix.Text = Properties.Settings.Default.LogNamePrefix;


		}

		/// <summary>
		/// If the email bit is choen, then enable the data entry for sending email.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkEnableEmail_CheckedChanged(object sender, EventArgs e)
		{
			if (chkEnableEmail.Checked)
			{
				grpEmailInfo.Enabled = true;
			}
			else
			{
				grpEmailInfo.Enabled = false;
			}
		}

		/// <summary>
		/// If the DB option is chosen, then enable the DB data entry
		/// and disable the log file data entry.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void optDB_CheckedChanged(object sender, EventArgs e)
		{
			if (optDB.Checked)
			{
				grpDBInfo.Enabled = true;
				grpFileInfo.Enabled = false;
			}
			else
			{
				grpDBInfo.Enabled = false;
				grpFileInfo.Enabled = true;
			}
		}

		/// <summary>
		/// If the file option is chosen, then enable the file data entry
		/// and disable the DB data entry.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void optFile_CheckedChanged(object sender, EventArgs e)
		{
			if (optFile.Checked)
			{
				grpDBInfo.Enabled = false;
				grpFileInfo.Enabled = true;
			}
			else
			{
				grpDBInfo.Enabled = true;
				grpFileInfo.Enabled = false;
			}
		}

		/// <summary>
		/// Run the demo test.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRunTest_Click(object sender, EventArgs e)
		{

			btnRunTest.Enabled = false;

			Boolean response = false;

			Properties.Settings.Default.DBServer = txtDBServer.Text.Trim();
			Properties.Settings.Default.Database = txtDatabase.Text.Trim();
			Properties.Settings.Default.UseWindowsAuthentication = chkUseWindowsAuthentication.Checked;
			Properties.Settings.Default.DBUserName = txtUserName.Text.Trim();
			Properties.Settings.Default.DBPassword = txtPassword.Text.Trim();
			Properties.Settings.Default.SMTPServer = txtSMTPServer.Text.Trim();
			Properties.Settings.Default.SMTPPort = txtSMTPPort.Text.Trim().GetInt32(587);
			Properties.Settings.Default.SMTPLogonName = txtLogonEmail.Text.Trim();
			Properties.Settings.Default.SMTPLogonPassword = txtSMTPLogonPassword.Text.Trim();
			Properties.Settings.Default.ReplyToAddress = txtReplyToAddress.Text.Trim();
			Properties.Settings.Default.FromAddress = txtFromAddress.Text.Trim();

			String sendTo = txtToAddresses.Text.Trim();

			if (sendTo.Contains(";"))
			{
				sendTo = sendTo.Replace(";", Environment.NewLine);
			}

			if (sendTo.Contains(","))
			{
				sendTo = sendTo.Replace(",", Environment.NewLine);
			}

			Properties.Settings.Default.SendToAddresses = sendTo;	
			Properties.Settings.Default.LogFolder = txtLogFolder.Text.Trim();
			Properties.Settings.Default.LogNamePrefix = txtPrefix.Text.Trim();
			Properties.Settings.Default.Save();


			// Get the values for the test.
			String filePath = txtLogFolder.Text.Trim();
			String fileNamePrefix = txtPrefix.Text.Trim();
			Int32 daysToRetainLogs = Convert.ToInt32(numDaysToRetain.Value);

			// Calculate the debug options bitset from what is checked.
			GetDebugLogOptions();

			// Is this a DB or file check?
			if (optDB.Checked)
			{
				String dbServer = txtDBServer.Text.Trim();
				String dbDatabase = txtDatabase.Text.Trim();
				Boolean useWindowsAuth = chkUseWindowsAuthentication.Checked;
				String dbUserName = txtUserName.Text.Trim();
				String dbPassword = txtPassword.Text.Trim();

				// Set the db configuration.  Because it is a singleton,
				// the instance does not have to be explicitly instantiated.
				// Just set the configs needed, and start the log.
				response = Logger.Instance.SetDBConfiguration(dbServer,
																dbUserName,
																dbPassword,
																useWindowsAuth,
																true,
																dbDatabase,
																daysToRetainLogs,
																m_DebugLogOptions);

			}
			else
			{
				// Set the log file configuration.  Because it is a singleton,
				// the instance does not have to be explicitly instantiated.
				// Just set the configs needed, and start the log.
				response = Logger.Instance.SetLogData(filePath,
										  fileNamePrefix,
										  daysToRetainLogs,
										  m_DebugLogOptions,
										  "");


			}


			if (chkEnableEmail.Checked)
			{
				// Gather the config data for sending email.
				Int32 smtpPort = Convert.ToInt32(txtSMTPPort.Text);
				Boolean useSSL = chkUseSSL.Checked;
				List<String> sendToAddresses = txtToAddresses.Text.Split(new[] { Environment.NewLine },
																		 StringSplitOptions.None).ToList<String>();


				String smtpServerName = txtSMTPServer.Text.Trim();
				String smtpLogonEmail = txtLogonEmail.Text.Trim();
				String smtpPassword = txtSMTPLogonPassword.Text.Trim();
				String smtpFromAddress = txtFromAddress.Text.Trim();
				String smtpReplyToAddrsss = txtReplyToAddress.Text.Trim();

				// Set the configuration for sending email, if sending email is desired.
				response = Logger.Instance.SetEmailData(smtpServerName,
													smtpLogonEmail,
													smtpPassword,
													smtpPort,
													sendToAddresses,
													smtpFromAddress,
													smtpReplyToAddrsss,
													useSSL);
			}

			// Now that the desired configs are set, start the log.
			Logger.Instance.StartLog();

			// For the demo, we simulate multithreaded use with the Parallel.For
			Parallel.For(1, 101, i =>
			{
				TestMethod(i);
			});

			// Now that the testing is over, stop the log.
			Logger.Instance.StopLog();

			// Dispose releases resources, and will also do a StopLog if not already done.
			Logger.Instance.Dispose();

			// Enable the button so the test can be run again with different values.
			btnRunTest.Enabled = true;
		}

		/// <summary>
		/// This method is used to perform test debug log writes.
		/// </summary>
		/// <param name="counter">The loop iteration number from the Parallel.For loop.</param>
		private void TestMethod(Int32 counter)
		{

			DateTime methodStart = DateTime.Now;

			// Note that the Logger call is not made unless the bit used for the WriteDebugLog
			// is on on the m_DebugLogOptions bitmask.  That allows bits to be turned on and off
			// during operation to adjust what is logged.  No code changes needed to increase or decrease
			// logging.
			if ((m_DebugLogOptions & LOG_TYPE.Flow) == LOG_TYPE.Flow)
			{
				if (counter == 1)
				{
					Logger.Instance.WriteDebugLog(LOG_TYPE.Flow | LOG_TYPE.SendEmail, "1st line in method");
				}
				else
				{
					Logger.Instance.WriteDebugLog(LOG_TYPE.Flow, "1st line in method");
				}
			}

			try
			{
				// A simple divide-by-zero exception is created and logged.
				Int32 x = 100;

				if ((m_DebugLogOptions & LOG_TYPE.Test) == LOG_TYPE.Test)
				{
					Logger.Instance.WriteDebugLog(LOG_TYPE.Test, "Test Message", "More info here");
				}

				Int32 y = 5 - 5;

				if ((m_DebugLogOptions & LOG_TYPE.System) == LOG_TYPE.System)
				{
					Logger.Instance.WriteDebugLog(LOG_TYPE.System, "TickCount", Environment.TickCount.ToString());
				}

				Double Z = x / y;

				if ((m_DebugLogOptions & LOG_TYPE.Cloud) == LOG_TYPE.Cloud)
				{
					Logger.Instance.WriteDebugLog(LOG_TYPE.Cloud, "Cloud Message", $"Task Counter value = {counter.ToString()}");
				}

			}
			catch (DivideByZeroException exDiv)
			{
				// The logger captures the data added to the excpetion instance's Data collection.
				exDiv.Data.Add("x", 100);
				exDiv.Data.Add("y", 0);

				if ((m_DebugLogOptions & LOG_TYPE.Error) == LOG_TYPE.Error)
				{
					if (counter == 1)
					{
						Logger.Instance.WriteDebugLog(LOG_TYPE.Error | LOG_TYPE.SendEmail, exDiv, "Division by zero was intentional");
					}
					else
					{
						Logger.Instance.WriteDebugLog(LOG_TYPE.Error, exDiv, "Division by zero was intentional");
					}
				}

			}
			catch (Exception exUnhandled)
			{
				// I always use a generic catch last so I can catch anything that
				// I did not anticipate
				exUnhandled.Data.Add("x", 100);
				exUnhandled.Data.Add("y", 0);

				if ((m_DebugLogOptions & LOG_TYPE.Error) == LOG_TYPE.Error)
				{
					Logger.Instance.WriteDebugLog(LOG_TYPE.Error & LOG_TYPE.SendEmail, exUnhandled, "Division by zero was intentional");
				}

			}
			finally
			{
				// I had no method-leel resources here, but if I did, this is how I normally handle them.
				// BEGIN dispose of method-level resources here =====================================
				// if (dac != null)
				//   {
				//     dac.Dispose();
				//     dac = null;
				//   }
				// END dispose of method-level resources here =======================================
				
				if ((m_DebugLogOptions & LOG_TYPE.Performance) == LOG_TYPE.Performance)
				{
					TimeSpan elapsedTime = DateTime.Now - methodStart;

					Logger.Instance.WriteDebugLog(LOG_TYPE.Performance,
													$"END; elapsed time = [{elapsedTime,0:mm} mins, {elapsedTime,0:ss} secs, {elapsedTime:fff} msecs].",
													elapsedTime.TotalMilliseconds.ToString());
				}
			}

		}

		/// <summary>
		/// Reads the debug log option checkboxes, and builds the m_DebugLogOptions bitmask to use for logging.
		/// </summary>
		private void GetDebugLogOptions()
		{

			m_DebugLogOptions = LOG_TYPE.Unspecified;

			if (chkFlow.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Flow;
			}

			if (chkError.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Error;
			}

			if (chkInformational.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Informational;
			}

			if (chkWarning.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Warning;
			}

			if (chkSystem.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.System;
			}

			if (chkPerformance.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Performance;
			}

			if (chkTest.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Test;
			}

			if (chkEnableEmail.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.SendEmail;
			}

			if (chkDatabase.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Database;
			}

			if (chkService.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Service;
			}

			if (chkCloud.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Cloud;
			}

			if (chkManagement.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Management;
			}

			if (chkFatal.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Fatal;
			}

			if (chkNetwork.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Network;
			}

			if (chkThreat.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Threat;
			}

			if (chkIncludeMethod.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.ShowModuleMethodAndLineNumber;
			}

			if (chkTimeOnly.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.ShowTimeOnly;
			}

			if (chkFlow.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.Flow;
			}

			if (chkHideThreadID.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.HideThreadID;
			}

			if (chkIncludeStackTrace.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.IncludeStackTrace;
			}

			if (chkIncludeExceptionData.Checked)
			{
				m_DebugLogOptions |= LOG_TYPE.IncludeExceptionData;
			}

			Logger.Instance.DebugLogOptions = m_DebugLogOptions;

		}

		/// <summary>
		/// Used to call the folder select UI to choose the folder for written log files.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnFolder_Click(object sender, EventArgs e)
		{
			DialogResult result = dlgFolder.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				txtLogFolder.Text = dlgFolder.SelectedPath;
			}

		}

	}  // public partial class frmMain : Form

}  // END namespace LoggingDemo
