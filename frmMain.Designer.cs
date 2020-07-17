namespace LoggingDemo
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.grpDestination = new System.Windows.Forms.GroupBox();
			this.numDaysToRetain = new System.Windows.Forms.NumericUpDown();
			this.lblRetain = new System.Windows.Forms.Label();
			this.optDB = new System.Windows.Forms.RadioButton();
			this.optFile = new System.Windows.Forms.RadioButton();
			this.grpLogConfig = new System.Windows.Forms.GroupBox();
			this.chkIncludeExceptionData = new System.Windows.Forms.CheckBox();
			this.chkEnableEmail = new System.Windows.Forms.CheckBox();
			this.chkHideThreadID = new System.Windows.Forms.CheckBox();
			this.chkIncludeStackTrace = new System.Windows.Forms.CheckBox();
			this.chkTimeOnly = new System.Windows.Forms.CheckBox();
			this.chkIncludeMethod = new System.Windows.Forms.CheckBox();
			this.grpDBInfo = new System.Windows.Forms.GroupBox();
			this.lblAuditTable = new System.Windows.Forms.Label();
			this.lblDBOK = new System.Windows.Forms.Label();
			this.btnValidateDB = new System.Windows.Forms.Button();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtDatabase = new System.Windows.Forms.TextBox();
			this.txtDBServer = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.lblDBUserName = new System.Windows.Forms.Label();
			this.chkUseWindowsAuthentication = new System.Windows.Forms.CheckBox();
			this.lblDatabase = new System.Windows.Forms.Label();
			this.lblServer = new System.Windows.Forms.Label();
			this.grpFileInfo = new System.Windows.Forms.GroupBox();
			this.txtPrefix = new System.Windows.Forms.TextBox();
			this.lblPrefix = new System.Windows.Forms.Label();
			this.btnFolder = new System.Windows.Forms.Button();
			this.txtLogFolder = new System.Windows.Forms.TextBox();
			this.lblLogFolder = new System.Windows.Forms.Label();
			this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.btnRunTest = new System.Windows.Forms.Button();
			this.grpEmailInfo = new System.Windows.Forms.GroupBox();
			this.txtToAddresses = new System.Windows.Forms.TextBox();
			this.lblToAddresses = new System.Windows.Forms.Label();
			this.chkUseSSL = new System.Windows.Forms.CheckBox();
			this.txtFromAddress = new System.Windows.Forms.TextBox();
			this.lblFromAddress = new System.Windows.Forms.Label();
			this.txtReplyToAddress = new System.Windows.Forms.TextBox();
			this.lblReplyToAddress = new System.Windows.Forms.Label();
			this.txtSMTPLogonPassword = new System.Windows.Forms.TextBox();
			this.lblSMTPLogonPassword = new System.Windows.Forms.Label();
			this.txtLogonEmail = new System.Windows.Forms.TextBox();
			this.lblLogon = new System.Windows.Forms.Label();
			this.txtSMTPPort = new System.Windows.Forms.TextBox();
			this.lblSMTPPort = new System.Windows.Forms.Label();
			this.txtSMTPServer = new System.Windows.Forms.TextBox();
			this.lblSMTPServer = new System.Windows.Forms.Label();
			this.chkFlow = new System.Windows.Forms.CheckBox();
			this.chkError = new System.Windows.Forms.CheckBox();
			this.chkInformational = new System.Windows.Forms.CheckBox();
			this.chkPerformance = new System.Windows.Forms.CheckBox();
			this.chkSystem = new System.Windows.Forms.CheckBox();
			this.chkWarning = new System.Windows.Forms.CheckBox();
			this.chkDatabase = new System.Windows.Forms.CheckBox();
			this.chkTest = new System.Windows.Forms.CheckBox();
			this.chkManagement = new System.Windows.Forms.CheckBox();
			this.chkCloud = new System.Windows.Forms.CheckBox();
			this.chkService = new System.Windows.Forms.CheckBox();
			this.chkThreat = new System.Windows.Forms.CheckBox();
			this.chkNetwork = new System.Windows.Forms.CheckBox();
			this.chkFatal = new System.Windows.Forms.CheckBox();
			this.grpLogOptions = new System.Windows.Forms.GroupBox();
			this.grpUDF = new System.Windows.Forms.GroupBox();
			this.txtUDF = new System.Windows.Forms.TextBox();
			this.lstUDF = new System.Windows.Forms.ListBox();
			this.btnUDFAdd = new System.Windows.Forms.Button();
			this.btnUDFRemove = new System.Windows.Forms.Button();
			this.grpOther = new System.Windows.Forms.GroupBox();
			this.lblEntityName = new System.Windows.Forms.Label();
			this.txtEntityName = new System.Windows.Forms.TextBox();
			this.grpDestination.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numDaysToRetain)).BeginInit();
			this.grpLogConfig.SuspendLayout();
			this.grpDBInfo.SuspendLayout();
			this.grpFileInfo.SuspendLayout();
			this.grpEmailInfo.SuspendLayout();
			this.grpLogOptions.SuspendLayout();
			this.grpUDF.SuspendLayout();
			this.grpOther.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpDestination
			// 
			this.grpDestination.Controls.Add(this.numDaysToRetain);
			this.grpDestination.Controls.Add(this.lblRetain);
			this.grpDestination.Controls.Add(this.optDB);
			this.grpDestination.Controls.Add(this.optFile);
			this.grpDestination.Location = new System.Drawing.Point(19, 18);
			this.grpDestination.Name = "grpDestination";
			this.grpDestination.Size = new System.Drawing.Size(357, 109);
			this.grpDestination.TabIndex = 0;
			this.grpDestination.TabStop = false;
			this.grpDestination.Text = "Log Destination & Retention";
			// 
			// numDaysToRetain
			// 
			this.numDaysToRetain.Location = new System.Drawing.Point(133, 69);
			this.numDaysToRetain.Name = "numDaysToRetain";
			this.numDaysToRetain.Size = new System.Drawing.Size(94, 21);
			this.numDaysToRetain.TabIndex = 3;
			this.numDaysToRetain.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblRetain
			// 
			this.lblRetain.AutoSize = true;
			this.lblRetain.Location = new System.Drawing.Point(12, 73);
			this.lblRetain.Name = "lblRetain";
			this.lblRetain.Size = new System.Drawing.Size(97, 13);
			this.lblRetain.TabIndex = 2;
			this.lblRetain.Text = "Days to retain logs";
			// 
			// optDB
			// 
			this.optDB.AutoSize = true;
			this.optDB.Location = new System.Drawing.Point(15, 46);
			this.optDB.Name = "optDB";
			this.optDB.Size = new System.Drawing.Size(71, 17);
			this.optDB.TabIndex = 1;
			this.optDB.TabStop = true;
			this.optDB.Text = "Database";
			this.optDB.UseVisualStyleBackColor = true;
			this.optDB.CheckedChanged += new System.EventHandler(this.optDB_CheckedChanged);
			// 
			// optFile
			// 
			this.optFile.AutoSize = true;
			this.optFile.Location = new System.Drawing.Point(15, 23);
			this.optFile.Name = "optFile";
			this.optFile.Size = new System.Drawing.Size(41, 17);
			this.optFile.TabIndex = 0;
			this.optFile.TabStop = true;
			this.optFile.Text = "File";
			this.optFile.UseVisualStyleBackColor = true;
			this.optFile.CheckedChanged += new System.EventHandler(this.optFile_CheckedChanged);
			// 
			// grpLogConfig
			// 
			this.grpLogConfig.Controls.Add(this.chkIncludeExceptionData);
			this.grpLogConfig.Controls.Add(this.chkEnableEmail);
			this.grpLogConfig.Controls.Add(this.chkHideThreadID);
			this.grpLogConfig.Controls.Add(this.chkIncludeStackTrace);
			this.grpLogConfig.Controls.Add(this.chkTimeOnly);
			this.grpLogConfig.Controls.Add(this.chkIncludeMethod);
			this.grpLogConfig.Location = new System.Drawing.Point(19, 128);
			this.grpLogConfig.Name = "grpLogConfig";
			this.grpLogConfig.Size = new System.Drawing.Size(357, 172);
			this.grpLogConfig.TabIndex = 2;
			this.grpLogConfig.TabStop = false;
			this.grpLogConfig.Text = "Log Configuration";
			// 
			// chkIncludeExceptionData
			// 
			this.chkIncludeExceptionData.AutoSize = true;
			this.chkIncludeExceptionData.Checked = true;
			this.chkIncludeExceptionData.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIncludeExceptionData.Location = new System.Drawing.Point(21, 121);
			this.chkIncludeExceptionData.Name = "chkIncludeExceptionData";
			this.chkIncludeExceptionData.Size = new System.Drawing.Size(186, 17);
			this.chkIncludeExceptionData.TabIndex = 5;
			this.chkIncludeExceptionData.Text = "Include Exception Data Collection";
			this.chkIncludeExceptionData.UseVisualStyleBackColor = true;
			// 
			// chkEnableEmail
			// 
			this.chkEnableEmail.AutoSize = true;
			this.chkEnableEmail.Checked = true;
			this.chkEnableEmail.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEnableEmail.Location = new System.Drawing.Point(21, 144);
			this.chkEnableEmail.Name = "chkEnableEmail";
			this.chkEnableEmail.Size = new System.Drawing.Size(112, 17);
			this.chkEnableEmail.TabIndex = 4;
			this.chkEnableEmail.Text = "Enable Email Send";
			this.chkEnableEmail.UseVisualStyleBackColor = true;
			this.chkEnableEmail.CheckedChanged += new System.EventHandler(this.chkEnableEmail_CheckedChanged);
			// 
			// chkHideThreadID
			// 
			this.chkHideThreadID.AutoSize = true;
			this.chkHideThreadID.Location = new System.Drawing.Point(21, 75);
			this.chkHideThreadID.Name = "chkHideThreadID";
			this.chkHideThreadID.Size = new System.Drawing.Size(124, 17);
			this.chkHideThreadID.TabIndex = 3;
			this.chkHideThreadID.Text = "Hide .NET Thread ID";
			this.chkHideThreadID.UseVisualStyleBackColor = true;
			// 
			// chkIncludeStackTrace
			// 
			this.chkIncludeStackTrace.AutoSize = true;
			this.chkIncludeStackTrace.Location = new System.Drawing.Point(21, 98);
			this.chkIncludeStackTrace.Name = "chkIncludeStackTrace";
			this.chkIncludeStackTrace.Size = new System.Drawing.Size(120, 17);
			this.chkIncludeStackTrace.TabIndex = 2;
			this.chkIncludeStackTrace.Text = "Include Stack Trace";
			this.chkIncludeStackTrace.UseVisualStyleBackColor = true;
			// 
			// chkTimeOnly
			// 
			this.chkTimeOnly.AutoSize = true;
			this.chkTimeOnly.Checked = true;
			this.chkTimeOnly.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTimeOnly.Location = new System.Drawing.Point(21, 52);
			this.chkTimeOnly.Name = "chkTimeOnly";
			this.chkTimeOnly.Size = new System.Drawing.Size(154, 17);
			this.chkTimeOnly.TabIndex = 1;
			this.chkTimeOnly.Text = "Show Time Only (not date)";
			this.chkTimeOnly.UseVisualStyleBackColor = true;
			// 
			// chkIncludeMethod
			// 
			this.chkIncludeMethod.AutoSize = true;
			this.chkIncludeMethod.Checked = true;
			this.chkIncludeMethod.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIncludeMethod.Location = new System.Drawing.Point(21, 29);
			this.chkIncludeMethod.Name = "chkIncludeMethod";
			this.chkIncludeMethod.Size = new System.Drawing.Size(219, 17);
			this.chkIncludeMethod.TabIndex = 0;
			this.chkIncludeMethod.Text = "Show Module, Method, and Line Number";
			this.chkIncludeMethod.UseVisualStyleBackColor = true;
			// 
			// grpDBInfo
			// 
			this.grpDBInfo.Controls.Add(this.lblAuditTable);
			this.grpDBInfo.Controls.Add(this.lblDBOK);
			this.grpDBInfo.Controls.Add(this.btnValidateDB);
			this.grpDBInfo.Controls.Add(this.txtPassword);
			this.grpDBInfo.Controls.Add(this.txtUserName);
			this.grpDBInfo.Controls.Add(this.txtDatabase);
			this.grpDBInfo.Controls.Add(this.txtDBServer);
			this.grpDBInfo.Controls.Add(this.lblPassword);
			this.grpDBInfo.Controls.Add(this.lblDBUserName);
			this.grpDBInfo.Controls.Add(this.chkUseWindowsAuthentication);
			this.grpDBInfo.Controls.Add(this.lblDatabase);
			this.grpDBInfo.Controls.Add(this.lblServer);
			this.grpDBInfo.Enabled = false;
			this.grpDBInfo.Location = new System.Drawing.Point(19, 306);
			this.grpDBInfo.Name = "grpDBInfo";
			this.grpDBInfo.Size = new System.Drawing.Size(357, 195);
			this.grpDBInfo.TabIndex = 3;
			this.grpDBInfo.TabStop = false;
			this.grpDBInfo.Text = "Database Info";
			// 
			// lblAuditTable
			// 
			this.lblAuditTable.BackColor = System.Drawing.SystemColors.Control;
			this.lblAuditTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblAuditTable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAuditTable.Location = new System.Drawing.Point(188, 158);
			this.lblAuditTable.Name = "lblAuditTable";
			this.lblAuditTable.Size = new System.Drawing.Size(155, 21);
			this.lblAuditTable.TabIndex = 14;
			this.lblAuditTable.Text = "No Audit Table";
			this.lblAuditTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblAuditTable.Visible = false;
			// 
			// lblDBOK
			// 
			this.lblDBOK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDBOK.Location = new System.Drawing.Point(147, 158);
			this.lblDBOK.Name = "lblDBOK";
			this.lblDBOK.Size = new System.Drawing.Size(35, 21);
			this.lblDBOK.TabIndex = 13;
			this.lblDBOK.Visible = false;
			// 
			// btnValidateDB
			// 
			this.btnValidateDB.Location = new System.Drawing.Point(9, 158);
			this.btnValidateDB.Name = "btnValidateDB";
			this.btnValidateDB.Size = new System.Drawing.Size(132, 21);
			this.btnValidateDB.TabIndex = 11;
			this.btnValidateDB.Text = "Validate DB Connection";
			this.btnValidateDB.UseVisualStyleBackColor = true;
			this.btnValidateDB.Click += new System.EventHandler(this.btnValidateDB_Click);
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(99, 121);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(244, 21);
			this.txtPassword.TabIndex = 10;
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(99, 94);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(244, 21);
			this.txtUserName.TabIndex = 9;
			// 
			// txtDatabase
			// 
			this.txtDatabase.Location = new System.Drawing.Point(99, 44);
			this.txtDatabase.Name = "txtDatabase";
			this.txtDatabase.Size = new System.Drawing.Size(244, 21);
			this.txtDatabase.TabIndex = 7;
			// 
			// txtDBServer
			// 
			this.txtDBServer.Location = new System.Drawing.Point(99, 17);
			this.txtDBServer.Name = "txtDBServer";
			this.txtDBServer.Size = new System.Drawing.Size(244, 21);
			this.txtDBServer.TabIndex = 6;
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(9, 124);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(53, 13);
			this.lblPassword.TabIndex = 5;
			this.lblPassword.Text = "Password";
			// 
			// lblDBUserName
			// 
			this.lblDBUserName.AutoSize = true;
			this.lblDBUserName.Location = new System.Drawing.Point(9, 97);
			this.lblDBUserName.Name = "lblDBUserName";
			this.lblDBUserName.Size = new System.Drawing.Size(59, 13);
			this.lblDBUserName.TabIndex = 4;
			this.lblDBUserName.Text = "User Name";
			// 
			// chkUseWindowsAuthentication
			// 
			this.chkUseWindowsAuthentication.AutoSize = true;
			this.chkUseWindowsAuthentication.Location = new System.Drawing.Point(11, 72);
			this.chkUseWindowsAuthentication.Name = "chkUseWindowsAuthentication";
			this.chkUseWindowsAuthentication.Size = new System.Drawing.Size(163, 17);
			this.chkUseWindowsAuthentication.TabIndex = 3;
			this.chkUseWindowsAuthentication.Text = "Use Windows Authentication";
			this.chkUseWindowsAuthentication.UseVisualStyleBackColor = true;
			// 
			// lblDatabase
			// 
			this.lblDatabase.AutoSize = true;
			this.lblDatabase.Location = new System.Drawing.Point(9, 47);
			this.lblDatabase.Name = "lblDatabase";
			this.lblDatabase.Size = new System.Drawing.Size(53, 13);
			this.lblDatabase.TabIndex = 1;
			this.lblDatabase.Text = "Database";
			// 
			// lblServer
			// 
			this.lblServer.AutoSize = true;
			this.lblServer.Location = new System.Drawing.Point(9, 21);
			this.lblServer.Name = "lblServer";
			this.lblServer.Size = new System.Drawing.Size(55, 13);
			this.lblServer.TabIndex = 0;
			this.lblServer.Text = "DB Server";
			// 
			// grpFileInfo
			// 
			this.grpFileInfo.Controls.Add(this.txtPrefix);
			this.grpFileInfo.Controls.Add(this.lblPrefix);
			this.grpFileInfo.Controls.Add(this.btnFolder);
			this.grpFileInfo.Controls.Add(this.txtLogFolder);
			this.grpFileInfo.Controls.Add(this.lblLogFolder);
			this.grpFileInfo.Location = new System.Drawing.Point(402, 393);
			this.grpFileInfo.Name = "grpFileInfo";
			this.grpFileInfo.Size = new System.Drawing.Size(614, 108);
			this.grpFileInfo.TabIndex = 4;
			this.grpFileInfo.TabStop = false;
			this.grpFileInfo.Text = "Log File Info";
			// 
			// txtPrefix
			// 
			this.txtPrefix.Location = new System.Drawing.Point(101, 52);
			this.txtPrefix.Name = "txtPrefix";
			this.txtPrefix.Size = new System.Drawing.Size(253, 21);
			this.txtPrefix.TabIndex = 4;
			this.txtPrefix.Text = "Test_";
			// 
			// lblPrefix
			// 
			this.lblPrefix.AutoSize = true;
			this.lblPrefix.Location = new System.Drawing.Point(10, 57);
			this.lblPrefix.Name = "lblPrefix";
			this.lblPrefix.Size = new System.Drawing.Size(85, 13);
			this.lblPrefix.TabIndex = 3;
			this.lblPrefix.Text = "Log Name Prefix";
			// 
			// btnFolder
			// 
			this.btnFolder.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFolder.Location = new System.Drawing.Point(559, 18);
			this.btnFolder.Name = "btnFolder";
			this.btnFolder.Size = new System.Drawing.Size(47, 29);
			this.btnFolder.TabIndex = 2;
			this.btnFolder.Text = ". . .";
			this.btnFolder.UseVisualStyleBackColor = true;
			this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
			// 
			// txtLogFolder
			// 
			this.txtLogFolder.Location = new System.Drawing.Point(80, 23);
			this.txtLogFolder.Name = "txtLogFolder";
			this.txtLogFolder.Size = new System.Drawing.Size(473, 21);
			this.txtLogFolder.TabIndex = 1;
			// 
			// lblLogFolder
			// 
			this.lblLogFolder.AutoSize = true;
			this.lblLogFolder.Location = new System.Drawing.Point(10, 28);
			this.lblLogFolder.Name = "lblLogFolder";
			this.lblLogFolder.Size = new System.Drawing.Size(57, 13);
			this.lblLogFolder.TabIndex = 0;
			this.lblLogFolder.Text = "Log Folder";
			// 
			// dlgFolder
			// 
			this.dlgFolder.Description = "Log Folder";
			this.dlgFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
			this.dlgFolder.SelectedPath = "C:\\";
			// 
			// btnRunTest
			// 
			this.btnRunTest.Location = new System.Drawing.Point(763, 25);
			this.btnRunTest.Name = "btnRunTest";
			this.btnRunTest.Size = new System.Drawing.Size(247, 33);
			this.btnRunTest.TabIndex = 5;
			this.btnRunTest.Text = "&Run Test";
			this.btnRunTest.UseVisualStyleBackColor = true;
			this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
			// 
			// grpEmailInfo
			// 
			this.grpEmailInfo.Controls.Add(this.txtToAddresses);
			this.grpEmailInfo.Controls.Add(this.lblToAddresses);
			this.grpEmailInfo.Controls.Add(this.chkUseSSL);
			this.grpEmailInfo.Controls.Add(this.txtFromAddress);
			this.grpEmailInfo.Controls.Add(this.lblFromAddress);
			this.grpEmailInfo.Controls.Add(this.txtReplyToAddress);
			this.grpEmailInfo.Controls.Add(this.lblReplyToAddress);
			this.grpEmailInfo.Controls.Add(this.txtSMTPLogonPassword);
			this.grpEmailInfo.Controls.Add(this.lblSMTPLogonPassword);
			this.grpEmailInfo.Controls.Add(this.txtLogonEmail);
			this.grpEmailInfo.Controls.Add(this.lblLogon);
			this.grpEmailInfo.Controls.Add(this.txtSMTPPort);
			this.grpEmailInfo.Controls.Add(this.lblSMTPPort);
			this.grpEmailInfo.Controls.Add(this.txtSMTPServer);
			this.grpEmailInfo.Controls.Add(this.lblSMTPServer);
			this.grpEmailInfo.Location = new System.Drawing.Point(754, 64);
			this.grpEmailInfo.Name = "grpEmailInfo";
			this.grpEmailInfo.Size = new System.Drawing.Size(262, 320);
			this.grpEmailInfo.TabIndex = 6;
			this.grpEmailInfo.TabStop = false;
			this.grpEmailInfo.Text = "Send Email Info";
			// 
			// txtToAddresses
			// 
			this.txtToAddresses.AcceptsReturn = true;
			this.txtToAddresses.Location = new System.Drawing.Point(10, 225);
			this.txtToAddresses.Multiline = true;
			this.txtToAddresses.Name = "txtToAddresses";
			this.txtToAddresses.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtToAddresses.Size = new System.Drawing.Size(246, 87);
			this.txtToAddresses.TabIndex = 14;
			// 
			// lblToAddresses
			// 
			this.lblToAddresses.AutoSize = true;
			this.lblToAddresses.Location = new System.Drawing.Point(7, 211);
			this.lblToAddresses.Name = "lblToAddresses";
			this.lblToAddresses.Size = new System.Drawing.Size(160, 13);
			this.lblToAddresses.TabIndex = 13;
			this.lblToAddresses.Text = "To Addresses (separate by line)";
			// 
			// chkUseSSL
			// 
			this.chkUseSSL.AutoSize = true;
			this.chkUseSSL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkUseSSL.Checked = true;
			this.chkUseSSL.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkUseSSL.Location = new System.Drawing.Point(9, 184);
			this.chkUseSSL.Name = "chkUseSSL";
			this.chkUseSSL.Size = new System.Drawing.Size(64, 17);
			this.chkUseSSL.TabIndex = 12;
			this.chkUseSSL.Text = "Use SSL";
			this.chkUseSSL.UseVisualStyleBackColor = true;
			// 
			// txtFromAddress
			// 
			this.txtFromAddress.Location = new System.Drawing.Point(104, 150);
			this.txtFromAddress.Name = "txtFromAddress";
			this.txtFromAddress.Size = new System.Drawing.Size(152, 21);
			this.txtFromAddress.TabIndex = 11;
			// 
			// lblFromAddress
			// 
			this.lblFromAddress.AutoSize = true;
			this.lblFromAddress.Location = new System.Drawing.Point(6, 154);
			this.lblFromAddress.Name = "lblFromAddress";
			this.lblFromAddress.Size = new System.Drawing.Size(73, 13);
			this.lblFromAddress.TabIndex = 10;
			this.lblFromAddress.Text = "From Address";
			// 
			// txtReplyToAddress
			// 
			this.txtReplyToAddress.Location = new System.Drawing.Point(104, 126);
			this.txtReplyToAddress.Name = "txtReplyToAddress";
			this.txtReplyToAddress.Size = new System.Drawing.Size(152, 21);
			this.txtReplyToAddress.TabIndex = 9;
			// 
			// lblReplyToAddress
			// 
			this.lblReplyToAddress.AutoSize = true;
			this.lblReplyToAddress.Location = new System.Drawing.Point(6, 130);
			this.lblReplyToAddress.Name = "lblReplyToAddress";
			this.lblReplyToAddress.Size = new System.Drawing.Size(92, 13);
			this.lblReplyToAddress.TabIndex = 8;
			this.lblReplyToAddress.Text = "Reply-To Address";
			// 
			// txtSMTPLogonPassword
			// 
			this.txtSMTPLogonPassword.Location = new System.Drawing.Point(104, 99);
			this.txtSMTPLogonPassword.Name = "txtSMTPLogonPassword";
			this.txtSMTPLogonPassword.PasswordChar = '*';
			this.txtSMTPLogonPassword.Size = new System.Drawing.Size(152, 21);
			this.txtSMTPLogonPassword.TabIndex = 7;
			// 
			// lblSMTPLogonPassword
			// 
			this.lblSMTPLogonPassword.AutoSize = true;
			this.lblSMTPLogonPassword.Location = new System.Drawing.Point(7, 103);
			this.lblSMTPLogonPassword.Name = "lblSMTPLogonPassword";
			this.lblSMTPLogonPassword.Size = new System.Drawing.Size(85, 13);
			this.lblSMTPLogonPassword.TabIndex = 6;
			this.lblSMTPLogonPassword.Text = "Logon Password";
			// 
			// txtLogonEmail
			// 
			this.txtLogonEmail.Location = new System.Drawing.Point(86, 74);
			this.txtLogonEmail.Name = "txtLogonEmail";
			this.txtLogonEmail.Size = new System.Drawing.Size(170, 21);
			this.txtLogonEmail.TabIndex = 5;
			// 
			// lblLogon
			// 
			this.lblLogon.AutoSize = true;
			this.lblLogon.Location = new System.Drawing.Point(6, 78);
			this.lblLogon.Name = "lblLogon";
			this.lblLogon.Size = new System.Drawing.Size(63, 13);
			this.lblLogon.TabIndex = 4;
			this.lblLogon.Text = "Logon Email";
			// 
			// txtSMTPPort
			// 
			this.txtSMTPPort.Location = new System.Drawing.Point(92, 46);
			this.txtSMTPPort.Name = "txtSMTPPort";
			this.txtSMTPPort.Size = new System.Drawing.Size(164, 21);
			this.txtSMTPPort.TabIndex = 3;
			// 
			// lblSMTPPort
			// 
			this.lblSMTPPort.AutoSize = true;
			this.lblSMTPPort.Location = new System.Drawing.Point(6, 50);
			this.lblSMTPPort.Name = "lblSMTPPort";
			this.lblSMTPPort.Size = new System.Drawing.Size(56, 13);
			this.lblSMTPPort.TabIndex = 2;
			this.lblSMTPPort.Text = "SMTP Port";
			// 
			// txtSMTPServer
			// 
			this.txtSMTPServer.Location = new System.Drawing.Point(86, 17);
			this.txtSMTPServer.Name = "txtSMTPServer";
			this.txtSMTPServer.Size = new System.Drawing.Size(170, 21);
			this.txtSMTPServer.TabIndex = 1;
			// 
			// lblSMTPServer
			// 
			this.lblSMTPServer.AutoSize = true;
			this.lblSMTPServer.Location = new System.Drawing.Point(6, 21);
			this.lblSMTPServer.Name = "lblSMTPServer";
			this.lblSMTPServer.Size = new System.Drawing.Size(68, 13);
			this.lblSMTPServer.TabIndex = 0;
			this.lblSMTPServer.Text = "SMTP Server";
			// 
			// chkFlow
			// 
			this.chkFlow.AutoSize = true;
			this.chkFlow.Location = new System.Drawing.Point(12, 23);
			this.chkFlow.Name = "chkFlow";
			this.chkFlow.Size = new System.Drawing.Size(91, 17);
			this.chkFlow.TabIndex = 15;
			this.chkFlow.Text = "Program Flow";
			this.chkFlow.UseVisualStyleBackColor = true;
			// 
			// chkError
			// 
			this.chkError.AutoSize = true;
			this.chkError.Checked = true;
			this.chkError.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkError.Location = new System.Drawing.Point(12, 46);
			this.chkError.Name = "chkError";
			this.chkError.Size = new System.Drawing.Size(50, 17);
			this.chkError.TabIndex = 16;
			this.chkError.Text = "Error";
			this.chkError.UseVisualStyleBackColor = true;
			// 
			// chkInformational
			// 
			this.chkInformational.AutoSize = true;
			this.chkInformational.Location = new System.Drawing.Point(12, 69);
			this.chkInformational.Name = "chkInformational";
			this.chkInformational.Size = new System.Drawing.Size(90, 17);
			this.chkInformational.TabIndex = 17;
			this.chkInformational.Text = "Informational";
			this.chkInformational.UseVisualStyleBackColor = true;
			// 
			// chkPerformance
			// 
			this.chkPerformance.AutoSize = true;
			this.chkPerformance.Location = new System.Drawing.Point(12, 138);
			this.chkPerformance.Name = "chkPerformance";
			this.chkPerformance.Size = new System.Drawing.Size(87, 17);
			this.chkPerformance.TabIndex = 18;
			this.chkPerformance.Text = "Performance";
			this.chkPerformance.UseVisualStyleBackColor = true;
			// 
			// chkSystem
			// 
			this.chkSystem.AutoSize = true;
			this.chkSystem.Location = new System.Drawing.Point(12, 115);
			this.chkSystem.Name = "chkSystem";
			this.chkSystem.Size = new System.Drawing.Size(61, 17);
			this.chkSystem.TabIndex = 19;
			this.chkSystem.Text = "System";
			this.chkSystem.UseVisualStyleBackColor = true;
			// 
			// chkWarning
			// 
			this.chkWarning.AutoSize = true;
			this.chkWarning.Checked = true;
			this.chkWarning.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkWarning.Location = new System.Drawing.Point(12, 92);
			this.chkWarning.Name = "chkWarning";
			this.chkWarning.Size = new System.Drawing.Size(66, 17);
			this.chkWarning.TabIndex = 20;
			this.chkWarning.Text = "Warning";
			this.chkWarning.UseVisualStyleBackColor = true;
			// 
			// chkDatabase
			// 
			this.chkDatabase.AutoSize = true;
			this.chkDatabase.Location = new System.Drawing.Point(12, 182);
			this.chkDatabase.Name = "chkDatabase";
			this.chkDatabase.Size = new System.Drawing.Size(72, 17);
			this.chkDatabase.TabIndex = 21;
			this.chkDatabase.Text = "Database";
			this.chkDatabase.UseVisualStyleBackColor = true;
			// 
			// chkTest
			// 
			this.chkTest.AutoSize = true;
			this.chkTest.Location = new System.Drawing.Point(12, 161);
			this.chkTest.Name = "chkTest";
			this.chkTest.Size = new System.Drawing.Size(47, 17);
			this.chkTest.TabIndex = 23;
			this.chkTest.Text = "Test";
			this.chkTest.UseVisualStyleBackColor = true;
			// 
			// chkManagement
			// 
			this.chkManagement.AutoSize = true;
			this.chkManagement.Location = new System.Drawing.Point(12, 251);
			this.chkManagement.Name = "chkManagement";
			this.chkManagement.Size = new System.Drawing.Size(88, 17);
			this.chkManagement.TabIndex = 24;
			this.chkManagement.Text = "Management";
			this.chkManagement.UseVisualStyleBackColor = true;
			// 
			// chkCloud
			// 
			this.chkCloud.AutoSize = true;
			this.chkCloud.Location = new System.Drawing.Point(12, 228);
			this.chkCloud.Name = "chkCloud";
			this.chkCloud.Size = new System.Drawing.Size(53, 17);
			this.chkCloud.TabIndex = 25;
			this.chkCloud.Text = "Cloud";
			this.chkCloud.UseVisualStyleBackColor = true;
			// 
			// chkService
			// 
			this.chkService.AutoSize = true;
			this.chkService.Location = new System.Drawing.Point(12, 205);
			this.chkService.Name = "chkService";
			this.chkService.Size = new System.Drawing.Size(61, 17);
			this.chkService.TabIndex = 26;
			this.chkService.Text = "Service";
			this.chkService.UseVisualStyleBackColor = true;
			// 
			// chkThreat
			// 
			this.chkThreat.AutoSize = true;
			this.chkThreat.Checked = true;
			this.chkThreat.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkThreat.Location = new System.Drawing.Point(12, 320);
			this.chkThreat.Name = "chkThreat";
			this.chkThreat.Size = new System.Drawing.Size(58, 17);
			this.chkThreat.TabIndex = 27;
			this.chkThreat.Text = "Threat";
			this.chkThreat.UseVisualStyleBackColor = true;
			// 
			// chkNetwork
			// 
			this.chkNetwork.AutoSize = true;
			this.chkNetwork.Location = new System.Drawing.Point(12, 297);
			this.chkNetwork.Name = "chkNetwork";
			this.chkNetwork.Size = new System.Drawing.Size(66, 17);
			this.chkNetwork.TabIndex = 28;
			this.chkNetwork.Text = "Network";
			this.chkNetwork.UseVisualStyleBackColor = true;
			// 
			// chkFatal
			// 
			this.chkFatal.AutoSize = true;
			this.chkFatal.Checked = true;
			this.chkFatal.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFatal.Location = new System.Drawing.Point(12, 274);
			this.chkFatal.Name = "chkFatal";
			this.chkFatal.Size = new System.Drawing.Size(50, 17);
			this.chkFatal.TabIndex = 29;
			this.chkFatal.Text = "Fatal";
			this.chkFatal.UseVisualStyleBackColor = true;
			// 
			// grpLogOptions
			// 
			this.grpLogOptions.Controls.Add(this.chkFatal);
			this.grpLogOptions.Controls.Add(this.chkNetwork);
			this.grpLogOptions.Controls.Add(this.chkThreat);
			this.grpLogOptions.Controls.Add(this.chkService);
			this.grpLogOptions.Controls.Add(this.chkCloud);
			this.grpLogOptions.Controls.Add(this.chkManagement);
			this.grpLogOptions.Controls.Add(this.chkTest);
			this.grpLogOptions.Controls.Add(this.chkDatabase);
			this.grpLogOptions.Controls.Add(this.chkWarning);
			this.grpLogOptions.Controls.Add(this.chkSystem);
			this.grpLogOptions.Controls.Add(this.chkPerformance);
			this.grpLogOptions.Controls.Add(this.chkInformational);
			this.grpLogOptions.Controls.Add(this.chkError);
			this.grpLogOptions.Controls.Add(this.chkFlow);
			this.grpLogOptions.Location = new System.Drawing.Point(402, 18);
			this.grpLogOptions.Name = "grpLogOptions";
			this.grpLogOptions.Size = new System.Drawing.Size(138, 367);
			this.grpLogOptions.TabIndex = 1;
			this.grpLogOptions.TabStop = false;
			this.grpLogOptions.Text = "Log Options";
			// 
			// grpUDF
			// 
			this.grpUDF.Controls.Add(this.btnUDFRemove);
			this.grpUDF.Controls.Add(this.btnUDFAdd);
			this.grpUDF.Controls.Add(this.lstUDF);
			this.grpUDF.Controls.Add(this.txtUDF);
			this.grpUDF.Location = new System.Drawing.Point(546, 28);
			this.grpUDF.Name = "grpUDF";
			this.grpUDF.Size = new System.Drawing.Size(202, 281);
			this.grpUDF.TabIndex = 7;
			this.grpUDF.TabStop = false;
			this.grpUDF.Text = "User Defined Fields";
			// 
			// txtUDF
			// 
			this.txtUDF.Location = new System.Drawing.Point(7, 21);
			this.txtUDF.Name = "txtUDF";
			this.txtUDF.Size = new System.Drawing.Size(142, 21);
			this.txtUDF.TabIndex = 0;
			// 
			// lstUDF
			// 
			this.lstUDF.FormattingEnabled = true;
			this.lstUDF.Location = new System.Drawing.Point(8, 46);
			this.lstUDF.Name = "lstUDF";
			this.lstUDF.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstUDF.Size = new System.Drawing.Size(141, 225);
			this.lstUDF.Sorted = true;
			this.lstUDF.TabIndex = 1;
			// 
			// btnUDFAdd
			// 
			this.btnUDFAdd.Location = new System.Drawing.Point(157, 20);
			this.btnUDFAdd.Name = "btnUDFAdd";
			this.btnUDFAdd.Size = new System.Drawing.Size(33, 21);
			this.btnUDFAdd.TabIndex = 2;
			this.btnUDFAdd.Text = "+";
			this.btnUDFAdd.UseVisualStyleBackColor = true;
			this.btnUDFAdd.Click += new System.EventHandler(this.btnUDFAdd_Click);
			// 
			// btnUDFRemove
			// 
			this.btnUDFRemove.Location = new System.Drawing.Point(157, 46);
			this.btnUDFRemove.Name = "btnUDFRemove";
			this.btnUDFRemove.Size = new System.Drawing.Size(33, 22);
			this.btnUDFRemove.TabIndex = 3;
			this.btnUDFRemove.Text = "-";
			this.btnUDFRemove.UseVisualStyleBackColor = true;
			this.btnUDFRemove.Click += new System.EventHandler(this.btnUDFRemove_Click);
			// 
			// grpOther
			// 
			this.grpOther.Controls.Add(this.txtEntityName);
			this.grpOther.Controls.Add(this.lblEntityName);
			this.grpOther.Location = new System.Drawing.Point(548, 315);
			this.grpOther.Name = "grpOther";
			this.grpOther.Size = new System.Drawing.Size(199, 68);
			this.grpOther.TabIndex = 8;
			this.grpOther.TabStop = false;
			this.grpOther.Text = "Other Info";
			// 
			// lblEntityName
			// 
			this.lblEntityName.AutoSize = true;
			this.lblEntityName.Location = new System.Drawing.Point(5, 17);
			this.lblEntityName.Name = "lblEntityName";
			this.lblEntityName.Size = new System.Drawing.Size(65, 13);
			this.lblEntityName.TabIndex = 0;
			this.lblEntityName.Text = "Entity Name";
			// 
			// txtEntityName
			// 
			this.txtEntityName.Location = new System.Drawing.Point(6, 33);
			this.txtEntityName.Name = "txtEntityName";
			this.txtEntityName.Size = new System.Drawing.Size(182, 21);
			this.txtEntityName.TabIndex = 1;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1031, 528);
			this.Controls.Add(this.grpOther);
			this.Controls.Add(this.grpUDF);
			this.Controls.Add(this.grpEmailInfo);
			this.Controls.Add(this.btnRunTest);
			this.Controls.Add(this.grpFileInfo);
			this.Controls.Add(this.grpDBInfo);
			this.Controls.Add(this.grpLogConfig);
			this.Controls.Add(this.grpLogOptions);
			this.Controls.Add(this.grpDestination);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "frmMain";
			this.Text = "Logging Demo";
			this.grpDestination.ResumeLayout(false);
			this.grpDestination.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numDaysToRetain)).EndInit();
			this.grpLogConfig.ResumeLayout(false);
			this.grpLogConfig.PerformLayout();
			this.grpDBInfo.ResumeLayout(false);
			this.grpDBInfo.PerformLayout();
			this.grpFileInfo.ResumeLayout(false);
			this.grpFileInfo.PerformLayout();
			this.grpEmailInfo.ResumeLayout(false);
			this.grpEmailInfo.PerformLayout();
			this.grpLogOptions.ResumeLayout(false);
			this.grpLogOptions.PerformLayout();
			this.grpUDF.ResumeLayout(false);
			this.grpUDF.PerformLayout();
			this.grpOther.ResumeLayout(false);
			this.grpOther.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpDestination;
		private System.Windows.Forms.RadioButton optDB;
		private System.Windows.Forms.RadioButton optFile;
		private System.Windows.Forms.GroupBox grpLogConfig;
		private System.Windows.Forms.CheckBox chkIncludeExceptionData;
		private System.Windows.Forms.CheckBox chkEnableEmail;
		private System.Windows.Forms.CheckBox chkHideThreadID;
		private System.Windows.Forms.CheckBox chkIncludeStackTrace;
		private System.Windows.Forms.CheckBox chkTimeOnly;
		private System.Windows.Forms.CheckBox chkIncludeMethod;
		private System.Windows.Forms.GroupBox grpDBInfo;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtDatabase;
		private System.Windows.Forms.TextBox txtDBServer;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblDBUserName;
		private System.Windows.Forms.CheckBox chkUseWindowsAuthentication;
		private System.Windows.Forms.Label lblDatabase;
		private System.Windows.Forms.Label lblServer;
		private System.Windows.Forms.GroupBox grpFileInfo;
		private System.Windows.Forms.Button btnFolder;
		private System.Windows.Forms.TextBox txtLogFolder;
		private System.Windows.Forms.Label lblLogFolder;
		private System.Windows.Forms.FolderBrowserDialog dlgFolder;
		private System.Windows.Forms.NumericUpDown numDaysToRetain;
		private System.Windows.Forms.Label lblRetain;
		private System.Windows.Forms.TextBox txtPrefix;
		private System.Windows.Forms.Label lblPrefix;
		private System.Windows.Forms.Button btnRunTest;
		private System.Windows.Forms.GroupBox grpEmailInfo;
		private System.Windows.Forms.TextBox txtLogonEmail;
		private System.Windows.Forms.Label lblLogon;
		private System.Windows.Forms.TextBox txtSMTPPort;
		private System.Windows.Forms.Label lblSMTPPort;
		private System.Windows.Forms.TextBox txtSMTPServer;
		private System.Windows.Forms.Label lblSMTPServer;
		private System.Windows.Forms.TextBox txtReplyToAddress;
		private System.Windows.Forms.Label lblReplyToAddress;
		private System.Windows.Forms.TextBox txtSMTPLogonPassword;
		private System.Windows.Forms.Label lblSMTPLogonPassword;
		private System.Windows.Forms.TextBox txtFromAddress;
		private System.Windows.Forms.Label lblFromAddress;
		private System.Windows.Forms.TextBox txtToAddresses;
		private System.Windows.Forms.Label lblToAddresses;
		private System.Windows.Forms.CheckBox chkUseSSL;
		private System.Windows.Forms.CheckBox chkFlow;
		private System.Windows.Forms.CheckBox chkError;
		private System.Windows.Forms.CheckBox chkInformational;
		private System.Windows.Forms.CheckBox chkPerformance;
		private System.Windows.Forms.CheckBox chkSystem;
		private System.Windows.Forms.CheckBox chkWarning;
		private System.Windows.Forms.CheckBox chkDatabase;
		private System.Windows.Forms.CheckBox chkTest;
		private System.Windows.Forms.CheckBox chkManagement;
		private System.Windows.Forms.CheckBox chkCloud;
		private System.Windows.Forms.CheckBox chkService;
		private System.Windows.Forms.CheckBox chkThreat;
		private System.Windows.Forms.CheckBox chkNetwork;
		private System.Windows.Forms.CheckBox chkFatal;
		private System.Windows.Forms.GroupBox grpLogOptions;
		private System.Windows.Forms.Button btnValidateDB;
		private System.Windows.Forms.Label lblDBOK;
		private System.Windows.Forms.Label lblAuditTable;
		private System.Windows.Forms.GroupBox grpUDF;
		private System.Windows.Forms.Button btnUDFRemove;
		private System.Windows.Forms.Button btnUDFAdd;
		private System.Windows.Forms.ListBox lstUDF;
		private System.Windows.Forms.TextBox txtUDF;
		private System.Windows.Forms.GroupBox grpOther;
		private System.Windows.Forms.Label lblEntityName;
		private System.Windows.Forms.TextBox txtEntityName;
	}
}

