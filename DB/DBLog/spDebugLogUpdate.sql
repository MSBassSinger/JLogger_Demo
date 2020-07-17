/******************************************************************************************************************************
STORED PROCEDURE: spDebugLogUpdate
VERSION: 1.0.0

This SP updates a single log record.
No audit log entry made.

When       Who What
========== === ================================================================================================================
07/06/2020 JDJ Genesis



******************************************************************************************************************************/

-- Check to see if the SP exists.
IF EXISTS (SELECT name FROM dbo.sysobjects WHERE name = 'spDebugLogUpdate')
	DROP PROCEDURE spDebugLogUpdate
GO 


CREATE PROCEDURE [dbo].[spDebugLogUpdate]
(
    @ID                          bigint,
    @LogType                     varchar (50),
    @LogDateTime                 datetime,
    @LogMessage                  nvarchar(MAX),
    @DetailMessage               nvarchar(MAX),
	@EntityName                  nvarchar(50),
	@Device                      nvarchar(50),
    @ModuleName                  nvarchar(MAX),
    @MethodName                  nvarchar(MAX),
    @LineNumber                  int,
    @ThreadID                    int,
    @ExceptionData               nvarchar(MAX),
    @StackData                   nvarchar(MAX),
	@UserDefinedData             nvarchar(MAX), 
    @WhenUpdatedOUT              DATETIME OUTPUT, 
    @RowsAffected                INT = 0 OUTPUT, 
    @ErrMessage                  NVARCHAR (255) = '' OUTPUT
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

    DECLARE @ErrNum INT

    DECLARE @NumRows BIGINT
    DECLARE @throwMsg varchar(2048)
    SET @ErrNum = 0
    SET @ErrMessage = ''

    BEGIN TRY        
        SET @WhenUpdatedOUT = GETDATE();

        IF NOT EXISTS(SELECT[ID] FROM [dbo].[DBLog] WHERE [ID] = @ID)
        BEGIN
        	   RAISERROR('There is no record to update with the identity value (%i).', 16, 1, @ID)
        END
        
        UPDATE [dbo].[DBLog]
        SET
            [LogType] = @LogType,
            [LogDateTime] = @LogDateTime,
            [LogMessage] = @LogMessage,
            [DetailMessage] = @DetailMessage,
			[EntityName] = @EntityName,
			[Device] = @Device,
            [ModuleName] = @ModuleName,
            [MethodName] = @MethodName,
            [LineNumber] = @LineNumber,
            [ThreadID] = @ThreadID,
            [ExceptionData] = @ExceptionData,
            [StackData] = @StackData,
			[UserDefinedData] = @UserDefinedData
        WHERE [ID] = @ID

        SET @NumRows = @@ROWCOUNT;
        SET @RowsAffected = @NumRows;
        IF @NumRows = 0
            BEGIN;
                SET @ErrNum = 50004;
                SET @throwMsg = 'The attempt to update the record failed. Either the data was not correct or you do not have access to update a record.';
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

EXEC sys.sp_addextendedproperty @name=N'Version', @value=N'1.0.0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'PROCEDURE',@level1name=N'spDebugLogUpdate'
GO


