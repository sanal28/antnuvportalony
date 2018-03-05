/****** Object:  StoredProcedure [dbo].[UspUpdateCancelLeaves]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspUpdateCancelLeaves]
	-- Add the parameters for the stored procedure here
	@Id int,
	@EmpId int,
	@CompanyId int,
	@FK_LeaveTypeId int,
	@Operation int,
	@statusId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--Operation 1 - Cancel
	--Operation 2 - Update
	SET NOCOUNT ON;

	declare @GroupId int,@ToAddress Varchar(50)
	select @GroupId=CCGroupId from tblLeaveWFSettings where FK_LeaveTypeId= @FK_LeaveTypeId and [FK_CompanyId] = @CompanyId

	create table #tblTemp([LeaveTransId] int,FK_LEAVETYPEID int,FK_EmpIdRequester int,FK_EmpAssignedTo int);

	WITH CteLeaveTrans([LeaveTransId],FK_LEAVETYPEID,FK_EmpIdRequester,FK_EmpAssignedTo)
		As
		(SELECT [LeaveTransId],FK_LEAVETYPEID,FK_EmpIdRequester,FK_EmpAssignedTo FROM tblLeaveTransaction
		 WHERE LeaveTransId=@Id
		 UNION ALL
		 SELECT T.LeaveTransId,T.FK_LEAVETYPEID,T.FK_EmpIdRequester,T.FK_EmpAssignedTo FROM tblLeaveTransaction T
		 INNER JOIN  CteLeaveTrans C ON C.LeaveTransId= T.FK_LeaveTransId 
		)
		
		insert into #tblTemp ([LeaveTransId],FK_LEAVETYPEID,FK_EmpIdRequester,FK_EmpAssignedTo)
		select * from CteLeaveTrans
		
		if(@Operation=1)
		begin
		update l set FK_StatusId = @statusId,ModifiedDate=GETDATE(),ModifiedEmpID=@EmpId
		from tblLeaveTransaction  l 
		inner join #tblTemp t  on l.LeaveTransId=t.LeaveTransId 
		end
		if(@Operation=2)
		begin
		
		update l set FK_StatusId=@statusId,
		ModifiedEmpID=@EmpId,ModifiedDate=getdate()
		from tblLeaveTransaction  l 
		inner join #tblTemp t  on l.LeaveTransId=t.LeaveTransId
		update tblLeaveTransaction set FK_RespondedBy = case when @statusId in (2,4) then @EmpId else NULL end where LeaveTransId=@Id
		end
		SELECT @ToAddress= emp.WorkEmail FROM #tblTemp a  
		join tblEmployee emp on a.FK_EmpIdRequester = emp.EmpId
		
		SELECT emp.WorkEmail as ToAddress,emp1.WorkEmail as ccAddress,leave.LeaveName as TypeName,'' as Name FROM #tblTemp a  
		join tblEmployee emp on a.FK_EmpIdRequester = emp.EmpId
		join tblEmployee emp1 on a.FK_EmpAssignedTo=emp1.EmpId
		join tblLeaveConfig leave on leave.LeaveTypeId=a.FK_LEAVETYPEID
		union
		select @ToAddress as ToAddress,emp.WorkEmail as ccAddress,''  as TypeName,'' as Name from tblGroupMembers grp 
		join tblEmployee emp on grp.FK_EmployeeId=emp.EmpId 
		where grp.FK_GroupId=@GroupId
		
		drop table #tblTemp

END


GO