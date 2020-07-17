/******************************************************************************************************************************
STORED PROCEDURE: spDebugLogDelete
VERSION: 1.0.0

This SP deletes log records older than a given date.


When       Who What
========== === ================================================================================================================
07/06/2020 JDJ Genesis



******************************************************************************************************************************/

-- Check to see if the SP exists.
IF EXISTS (SELECT name FROM dbo.sysobjects WHERE name = 'spDebugLogDelete')
	DROP PROCEDURE spDebugLogDelete
GO 

CREATE PROCEDURE [dbo].[spDebugLogDelete]
(
	@DeletionDate	      datetime,
	@RowsAffected         INT = 0 OUTPUT,
	@ErrMessage           NVARCHAR(255) = '' OUTPUT,
    @AuditUserName        VARCHAR (64), 
    @AuditWorkstation     VARCHAR (255), 
    @WhenDeletedOUT       DATETIME OUTPUT
)
AS
BEGIN

	/*
	When SET NOCOUNT is ON, the count is not returned. When SET NOCOUNT is OFF, the count is returned.
	The @@ROWCOUNT function is updated even when SET NOCOUNT is ON.
	SET NOCOUNT ON prevents the sending of DONE_IN_PROC messages to the client for each statement 
	in a stored procedure. For stored procedures that contain several statements that do not return much 
	actual data, setting SET NOCOUNT to ON can provide a significant performance boost, because 
	network traffic is greatly reduced.
	The setting specified by SET NOCOUNT is in effect at execute or run time and not at parse time.
	*/
	SET NOCOUNT ON

	DECLARE @ErrNum	INT
	DECLARE @NumRows BIGINT
	DECLARE @throwMsg varchar(2048)
	DECLARE @RowsToProcess  int
	DECLARE @CurrentRow     int
	DECLARE @SelectCol1     int

	DECLARE @LocalDeletionTable  TABLE
	(
		[RowID] int not null primary key identity(1,1),
		[ID] [bigint] NOT NULL,
		[LogType] [varchar](50) NOT NULL,
		[LogDateTime] [datetime] NOT NULL,
		[LogMessage] [nvarchar](max) NOT NULL,
		[DetailMessage] [nvarchar](max) NOT NULL,
		[EntityName] [nvarchar](50) NOT NULL,
		[Device] [nvarchar](50) NOT NULL,
		[ModuleName] [nvarchar](max) NOT NULL,
		[MethodName] [nvarchar](max) NOT NULL,
		[LineNumber] [int] NOT NULL,
		[ThreadID] [int] NOT NULL,
		[ExceptionData] [nvarchar](max) NOT NULL,
		[StackData] [nvarchar](max) NOT NULL,
		[UserDefinedData] [nvarchar](max) NOT NULL
	)

	SET @ErrNum = 0;
	SET @ErrMessage = '';
	SET @WhenDeletedOUT = GETDATE();


	BEGIN TRY	

	    INSERT INTO @LocalDeletionTable
		SELECT * FROM [dbo].[DBLog]
		WHERE [LogDateTime] < @DeletionDate 
		SET @RowsToProcess=@@ROWCOUNT

		DELETE FROM [dbo].[DBLog]
		WHERE [LogDateTime] < @DeletionDate 

		SET @NumRows = @@ROWCOUNT;
		SET @RowsAffected = @NumRows;

		IF (@NumRows > 0)
			BEGIN
				--Copy the existing data, if it exists.
				DECLARE @CurrentID                      bigint
				DECLARE @CurrentLogType                 varchar (50)
				DECLARE @CurrentLogDateTime             datetime
				DECLARE @CurrentLogMessage              nvarchar (MAX)
				DECLARE @CurrentDetailMessage           nvarchar (MAX)
				DECLARE @CurrentEntityName              nvarchar (50)
				DECLARE @CurrentDevice                  nvarchar (50)
				DECLARE @CurrentModuleName              nvarchar (MAX)
				DECLARE @CurrentMethodName              nvarchar (MAX)
				DECLARE @CurrentLineNumber              int
				DECLARE @CurrentThreadID                int
				DECLARE @CurrentExceptionData           nvarchar (MAX)
				DECLARE @CurrentStackData               nvarchar (MAX)
				DECLARE @CurrentUserDefinedData         nvarchar (MAX)
        
				SET @CurrentRow=0
				WHILE @CurrentRow < @RowsToProcess
				BEGIN
					SET @CurrentRow = @CurrentRow + 1

					SELECT 
						@CurrentID = ID,
						@CurrentLogType = LogType,
						@CurrentLogDateTime = LogDateTime,
						@CurrentLogMessage = LogMessage,
						@CurrentDetailMessage = DetailMessage,
						@CurrentEntityName = EntityName,
						@CurrentDevice = Device,
						@CurrentModuleName = ModuleName,
						@CurrentMethodName = MethodName,
						@CurrentLineNumber = LineNumber,
						@CurrentThreadID = ThreadID,
						@CurrentExceptionData = ExceptionData,
						@CurrentStackData = StackData,
						@CurrentUserDefinedData = UserDefinedData
					FROM @LocalDeletionTable
					WHERE RowID = @CurrentRow

					-- Now add a new transaction record to the audit table.
					INSERT INTO [dbo].[DBLogAudit]
					(
						[AuditType],
						[AuditWhen],
						[AuditUserName],
						[AuditWorkStation],
						[OrigID],
						[OrigLogType],
						[OrigLogDateTime],
						[OrigLogMessage],
						[OrigDetailMessage],
						[OrigEntityName],
						[OrigDevice],
						[OrigModuleName],
						[OrigMethodName],
						[OrigLineNumber],
						[OrigThreadID],
						[OrigExceptionData],
						[OrigStackData],
						[OrigUserDefinedData]
					)
					VALUES
					(
					   'D0',
					   @WhenDeletedOUT,
					   @AuditUserName,
					   @AuditWorkstation,
					   @CurrentID,
					   @CurrentLogType,
					   @CurrentLogDateTime,
					   @CurrentLogMessage,
					   @CurrentDetailMessage,
					   @CurrentEntityName,
					   @CurrentDevice,
					   @CurrentModuleName,
					   @CurrentMethodName,
					   @CurrentLineNumber,
					   @CurrentThreadID,
					   @CurrentExceptionData,
					   @CurrentStackData,
					   @CurrentUserDefinedData
					)
				END
			END
	END TRY
	BEGIN CATCH
		BEGIN
			-- Capture the error number.
			SET @ErrNum = @@ERROR;
			SET @ErrMessage = 'Error#=[' + CONVERT(nvarchar(255), @ErrNum) + ']::Line=[' + CONVERT(nvarchar(255), ERROR_LINE()) + ']::Message=[' + COALESCE(ERROR_MESSAGE(), 'N/A') + ']::=Procedure=[' + COALESCE(ERROR_PROCEDURE(), 'N/A') + ']::Severity=[' + CONVERT(nvarchar(255), ERROR_SEVERITY()) + ']::Application=[' + APP_NAME() + ']';
		END
	END CATCH

	RETURN @ErrNum

END

GO

EXEC sys.sp_addextendedproperty @name=N'Version', @value=N'1.0.0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'PROCEDURE',@level1name=N'spDebugLogDelete'
GO


