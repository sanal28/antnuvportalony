/****** Object:  StoredProcedure [dbo].[UspProjectTaskOper]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspProjectTaskOper]
@Attachments varchar(Max),
@Billable bit,
@Comments varchar(Max),
@EndDate datetime,
@Fk_ProjectId int,
@PlannedHours float,
@Priority int,
@ProjectPhase varchar(Max),
@StartDate datetime,
@Status bit,
@TaskDetails varchar(Max),
@TaskId int=null,
@TaskName varchar(Max),
@TaskStatusId int,
@Operation Tinyint,
@CreatedDate datetime,
@CreatedEmpID int,
@ModifiedDate datetime,
@ModifiedEmpID int
As
BEGIN
DECLARE @Returnvalue int
Declare @CompletedDate datetime = null
	BEGIN TRY
	if(@TaskStatusId=3)
		set @CompletedDate=getdate()
		if @Operation=1
		BEGIN
			BEGIN TRAN
			INSERT INTO dbo.tblProjectTask(Attachments,Billable,Comments,EndDate,Fk_ProjectId,PlannedHours,Priority,ProjectPhase,StartDate,Status,TaskDetails,TaskName,Fk_TaskStatusId,CreatedDate,CreatedEmpID,ModifiedDate,ModifiedEmpID)
			VALUES(@Attachments,@Billable,@Comments,@EndDate,@Fk_ProjectId,@PlannedHours,@Priority,@ProjectPhase,@StartDate,@Status,@TaskDetails,@TaskName,@TaskStatusId,@CreatedDate,@CreatedEmpID,@ModifiedDate,@ModifiedEmpID)
			Select @Returnvalue=SCOPE_IDENTITY();
			COMMIT TRAN
			select @Returnvalue as TasKId
		END
		if @Operation=2
		BEGIN
			BEGIN TRAN 
				 Update tblProjectTask SET				
				Fk_ProjectId=@Fk_ProjectId,
				TaskName=@TaskName,
				StartDate=@StartDate,
				EndDate=@EndDate,
				PlannedHours=@PlannedHours,
				ProjectPhase=@ProjectPhase,
				Fk_TaskStatusId=@TaskStatusId,
				TaskDetails=@TaskDetails,
				Comments=@Comments,
				Priority=@Priority,
				Billable=@Billable,
				Attachments=@Attachments,
				Status=@Status,
				TaskCompletedDate=@CompletedDate

				 WHERE TaskId=@TaskId
				 select @@ROWCOUNT as RowC
		COMMIT TRAN

		END

		if @Operation=3
		BEGIN
			BEGIN TRAN
				Update tblProjectTask SET	
				Fk_TaskStatusId=@TaskStatusId,
				Comments=@Comments,
				Attachments=@Attachments,
				TaskCompletedDate=@CompletedDate
				WHERE TaskId=@TaskId
				select @@ROWCOUNT as RowC
		COMMIT TRAN

		END
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
	
END


GO