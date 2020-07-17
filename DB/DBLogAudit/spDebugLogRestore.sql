/******************************************************************************

Object:

   spDebugLogInsert

Description:

   Inserts a new debug log record.


Revision History:
----------------------
10-01-2019	JDJ	Creation.
05-24-2020  JDJ Added UserDefinedData, EntityName, and Device parameters
07-06-2020  JDJ Renamed
*******************************************************************************/

IF EXISTS (SELECT name FROM dbo.sysobjects WHERE name = 'spDebugLogRestore')
	DROP PROCEDURE spDebugLogRestore
	
GO 

CREATE PROCEDURE [dbo].[spDebugLogRestore]
(
    @AuditLogID                  bigint, 
    @AuditUserName               varchar(64), 
    @AuditWorkstation            varchar(255), 
    @RowsAffected                int = 0 OUTPUT, 
    @ErrMessage                  nvarchar(255) = '' OUTPUT
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

    DECLARE @ErrNum          int
    DECLARE @NumRows         bigint
    DECLARE @throwMsg        varchar(2048)
    SET @ErrNum = 0
    SET @ErrMessage = ''

    BEGIN TRY
        DECLARE @NewWrittenDateTime datetime
        SET @NewWrittenDateTime = GETDATE()

        IF @AuditWorkstation IS NULL
            BEGIN
                SET @AuditWorkstation = COALESCE(HOST_NAME(), 'Unknown')
            END
        ELSE
            BEGIN
                IF LEN(@AuditWorkstation) = 0
                    BEGIN
                        SET @AuditWorkstation = COALESCE(HOST_NAME(), 'Unknown')
                    END
            END
        
        IF NOT EXISTS(SELECT [ID] FROM dbo.DBLogAudit WHERE [ID] = @AuditLogID)
             BEGIN
                 RAISERROR('There is no audit table record with the ID value (%i).', 16, 1, @AuditLogID)
             END

        -- Copy the audit table values to variables
        DECLARE @OrigID                   bigint
        DECLARE @OrigLogType              varchar
        DECLARE @OrigLogDateTime          datetime
        DECLARE @OrigLogMessage           nvarchar(MAX)
        DECLARE @OrigDetailMessage        nvarchar(MAX)
        DECLARE @OrigEntityName           nvarchar(50)
        DECLARE @OrigDevice               nvarchar(50)
        DECLARE @OrigModuleName           nvarchar(MAX)
        DECLARE @OrigMethodName           nvarchar(MAX)
        DECLARE @OrigLineNumber           int
        DECLARE @OrigThreadID             int
        DECLARE @OrigExceptionData        nvarchar(MAX)
        DECLARE @OrigStackData            nvarchar(MAX)
        DECLARE @OrigUserDefineData       nvarchar(MAX)


        -- Copy the existing data, if it exists, to variables
        DECLARE @CurrentID                   bigint
        DECLARE @CurrentLogType              varchar
        DECLARE @CurrentLogDateTime          datetime
        DECLARE @CurrentLogMessage           nvarchar(MAX)
        DECLARE @CurrentDetailMessage        nvarchar(MAX)
        DECLARE @CurrentEntityName           nvarchar(50)
        DECLARE @CurrentDevice               nvarchar(50)
        DECLARE @CurrentModuleName           nvarchar(MAX)
        DECLARE @CurrentMethodName           nvarchar(MAX)
        DECLARE @CurrentLineNumber           int
        DECLARE @CurrentThreadID             int
        DECLARE @CurrentExceptionData        nvarchar
        DECLARE @CurrentStackData            nvarchar
        DECLARE @CurrentUserDefineData       nvarchar(MAX)

        -- Get the specified record's data into variables 
        SELECT
            @OrigID = [OrigID],
            @OrigLogType = [OrigLogType],
            @OrigLogDateTime = [OrigLogDateTime],
            @OrigLogMessage = [OrigLogMessage],
            @OrigDetailMessage = [OrigDetailMessage],
			@OrigEntityName = [OrigEntityName],
			@OrigDevice = [OrigDevice],
            @OrigModuleName = [OrigModuleName],
            @OrigMethodName = [OrigMethodName],
            @OrigLineNumber = [OrigLineNumber],
            @OrigThreadID = [OrigThreadID],
            @OrigExceptionData = [OrigExceptionData],
            @OrigStackData = [OrigStackData],
			@OrigUserDefineData = [OrigUserDefinedData]
        FROM dbo.DBLogAudit
        WHERE ID = @AuditLogID
         
        IF NOT EXISTS(SELECT [ID] FROM [dbo].[DBLog] WHERE [ID] = @OrigID)
        	BEGIN
        	    -- If the audit log data is not found in the primary table,
        	    -- then insert the audit data, reusing the primary tables identity value
                SET IDENTITY_INSERT [dbo].[DBLog] ON
        	    INSERT INTO [dbo].[DBLog]
        	    ( 
                    [ID],
                    [LogType],
                    [LogDateTime],
                    [LogMessage],
                    [DetailMessage],
					[EntityName],
					[Device],
                    [ModuleName],
                    [MethodName],
                    [LineNumber],
                    [ThreadID],
                    [ExceptionData],
                    [StackData],
					[UserDefinedData]
        	    )
        	    VALUES
        	    (
                    @OrigID,
                    @OrigLogType,
                    @OrigLogDateTime,
                    @OrigLogMessage,
                    @OrigDetailMessage,
					@OrigEntityName,
					@OrigDevice,
                    @OrigModuleName,
                    @OrigMethodName,
                    @OrigLineNumber,
                    @OrigThreadID,
                    @OrigExceptionData,
                    @OrigStackData,
					@OrigUserDefineData
        	    )
                SET IDENTITY_INSERT [dbo].[DBLog] OFF
        	    
        	    -- Insert a new audit record in the audit table for this transaction
        	    -- Same data you just took out of the audit table, but inserted as a new transaction.
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
        	    	'R1',
        	    	 @NewWrittenDateTime,
        	    	 @AuditUserName,
        	    	 @AuditWorkstation,
                     @OrigID,
                     @OrigLogType,
                     @OrigLogDateTime,
                     @OrigLogMessage,
                     @OrigDetailMessage,
					 @OrigEntityName,
					 @OrigDevice,
                     @OrigModuleName,
                     @OrigMethodName,
                     @OrigLineNumber,
                     @OrigThreadID,
                     @OrigExceptionData,
                     @OrigStackData,
					 @OrigUserDefineData
        	    )
        	END
        ELSE
        	BEGIN

                 -- Since the primary table record reference in the audit table exists,
                 -- copy that into variables to be put in the audit log later.
                SELECT
                    @CurrentID = [ID],
                    @CurrentLogType = [LogType],
                    @CurrentLogDateTime = [LogDateTime],
                    @CurrentLogMessage = [LogMessage],
                    @CurrentDetailMessage = [DetailMessage],
					@CurrentEntityName = [EntityName],
					@CurrentDevice = [Device],
                    @CurrentModuleName = [ModuleName],
                    @CurrentMethodName = [MethodName],
                    @CurrentLineNumber = [LineNumber],
                    @CurrentThreadID = [ThreadID],
                    @CurrentExceptionData = [ExceptionData],
                    @CurrentStackData = [StackData],
					@CurrentUserDefineData = [UserDefinedData]
                FROM [dbo].[DBLog]
                WHERE [ID] = @OrigID

                 -- Put the data from the audit log into the primary table
                 -- this restoring the old data
                UPDATE [dbo].[DBLog]
                SET
                    [LogType] = @OrigLogType,
                    [LogDateTime] = @OrigLogDateTime,
                    [LogMessage] = @OrigLogMessage,
                    [DetailMessage] = @OrigDetailMessage,
					[EntityName]= @OrigEntityName,
					[Device] = @OrigDevice,
                    [ModuleName] = @OrigModuleName,
                    [MethodName] = @OrigMethodName,
                    [LineNumber] = @OrigLineNumber,
                    [ThreadID] = @OrigThreadID,
                    [ExceptionData] = @OrigExceptionData,
                    [StackData] = @OrigStackData,
					[UserDefinedData] = @CurrentUserDefineData
                WHERE [ID] = @OrigID
                
                -- Now add a new transaction record to the audit table
                -- so the current data is preserved.
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
                    'R0',
                	@NewWrittenDateTime,
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
					@CurrentUserDefineData
                )
        	END

        SET @NumRows = @@ROWCOUNT;
        SET @RowsAffected = @NumRows;
        IF @NumRows = 0
            BEGIN;
                SET @ErrNum = 50004;
                SET @throwMsg = 'The attempt to restore the record failed. Either the data was not correct or you do not have access to restore a record.';
                THROW @ErrNum, @throwMsg, 1;
            END;

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

EXEC sys.sp_addextendedproperty @name=N'Version', @value=N'1.0.0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'PROCEDURE',@level1name=N'spDebugLogRestore'
GO


