/*****************************************************************************************************************************
When       Who What
========== === ================================================================================================================
10/01/2019 JDJ Genesis
05/24/2020 JDJ Added UserDefinedData, EntityName, and Device fields.

******************************************************************************************************************************/

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS(SELECT name FROM dbo.sysobjects WHERE name = 'DBLogAudit')
	BEGIN


		CREATE TABLE [dbo].[DBLogAudit](
			[ID] [bigint] IDENTITY(1,1) NOT NULL,
			[OrigID] [bigint] NOT NULL,
			[OrigLogType] [varchar](50) NOT NULL,
			[OrigLogDateTime] [datetime] NOT NULL,
			[OrigLogMessage] [nvarchar](max) NOT NULL,
			[OrigDetailMessage] [nvarchar](max) NOT NULL,
			[OrigEntityName] [nvarchar](50) NOT NULL,
			[OrigDevice] [nvarchar](50) NOT NULL,
			[OrigModuleName] [nvarchar](max) NOT NULL,
			[OrigMethodName] [nvarchar](max) NOT NULL,
			[OrigLineNumber] [int] NOT NULL,
			[OrigThreadID] [int] NOT NULL,
			[OrigExceptionData] [nvarchar](max) NOT NULL,
			[OrigStackData] [nvarchar](max) NOT NULL,
			[OrigUserDefinedData] [nvarchar](max) NOT NULL,
			[AuditUserName] [nvarchar](30) NOT NULL,
			[AuditWhen] [datetime] NOT NULL,
			[AuditWorkstation] [nvarchar](30) NOT NULL,
			[AuditType] [char](2) NOT NULL,
		 CONSTRAINT [PK_DBLogAudit] PRIMARY KEY CLUSTERED 
		(
			[ID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

		ALTER TABLE [dbo].[DBLogAudit]  WITH CHECK ADD CHECK  (([AuditType]='R0' OR [AuditType]='D0' OR [AuditType]='U0' OR [AuditType]='I0' OR [AuditType]='R1'))

		EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'I0=Insert; U0=Update; D0=Delete; R0=Restore from current; R1=Restore with no current' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DBLogAudit', @level2type=N'COLUMN',@level2name=N'AuditType'

	END

