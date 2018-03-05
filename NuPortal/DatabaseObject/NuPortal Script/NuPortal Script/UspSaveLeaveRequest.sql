/****** Object:  StoredProcedure [dbo].[UspSaveLeaveRequest]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspSaveLeaveRequest]
	-- Add the parameters for the stored procedure here
@CreatedEmpID int,
@FK_EmpAssignedTo int,
@FK_EmpId int,
@FK_EmpIdRequester int,
@FK_LeaveTransId int,
@FK_LeaveTypeId int,
@FK_StatusId int,
@CompanyId int,
@LeaveAppliedDays int,
@LeaveEndDate datetime,
@LeaveStartDate datetime,
@Reason varchar(max),
@ModifiedEmpID int,
@IsCreate int

--@FK_LeaveSettingsId int,

AS
BEGIN
DECLARE @Returnvalue int
	BEGIN TRY
		BEGIN
		Declare @ToAddress varchar(100),
	    @ccAddress varchar(100),
		@FirstName varchar(100),
		@FK_LeaveSettingsId int,@GroupId int,
		@HireDate Datetime,@NoofMonthsWorked smallint
	 
	    --initial insert
		--@FK_LeaveTransId - 0
		--@FK_StatusId - 1
		--@FK_EmpAssignedTo = 0
		--@IsCreate - 1

		if(@IsCreate=1)
			select @FK_EmpAssignedTo = Manager from tblEmployee where EmpId= @FK_EmpIdRequester

		select @GroupId=CCGroupId from tblLeaveWFSettings where FK_LeaveTypeId= @FK_LeaveTypeId and [FK_CompanyId] = @CompanyId

		select @ToAddress=b.WorkEmail,@FK_EmpAssignedTo = b.EmpId,@ccAddress=a.WorkEmail,@FirstName=a.FirstName,
		@HireDate=a.HireDate 
		from tblEmployee a join tblEmployee b on a.Manager=b.EmpId where a.EmpId=@FK_EmpId
		
		SET @NoofMonthsWorked=DATEDIFF(m,@HireDate, @LeaveStartDate)

		select @FK_LeaveSettingsId=coalesce(leavesettingid,0) from dbo.tblLeavesettings 
		where leaveeffectdate<=@LeaveStartDate and fk_leavetypeid=@FK_LeaveTypeId 
		and @NoofMonthsWorked between [PeriodFrom] and [PeriodTo]
		
		order by leavesettingid desc

			BEGIN TRAN
			INSERT INTO dbo.tblLeaveTransaction
			(
			FK_EmpId,
			FK_EmpIdRequester,
			FK_EmpAssignedTo,
			FK_LeaveSettingsId,
			FK_LeaveTransId,
			FK_LeaveTypeId,
			FK_StatusId,
			LeaveAppliedDays,
			LeaveEndDate,
			LeaveStartDate,
			CreatedEmpID,
			ModifiedEmpID,
			Reason
			)
			VALUES
			(
			@FK_EmpId,
			@FK_EmpId,
			@FK_EmpAssignedTo,
			@FK_LeaveSettingsId,
			@FK_LeaveTransId,
			@FK_LeaveTypeId,
			@FK_StatusId,
			@LeaveAppliedDays,
			@LeaveEndDate,
			@LeaveStartDate,
			@CreatedEmpID,
			@ModifiedEmpID,
			@Reason
			)
			Select @Returnvalue=SCOPE_IDENTITY();
			COMMIT TRAN
		END

		select @ToAddress as ToAddress,@ccAddress as ccAddress,LeaveName as TypeName,@FirstName as Name from [tblLeaveConfig] 
		where [LeaveTypeId]=@FK_LeaveTypeId
		union
		select @ToAddress as ToAddress,emp.WorkEmail as ccAddress,''  as TypeName,@FirstName as Name from tblGroupMembers grp 
		join tblEmployee emp on grp.FK_EmployeeId=emp.EmpId 
		where grp.FK_GroupId=@GroupId

		END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
END

GO