USE [NuPortal]
GO

/****** Object:  StoredProcedure [dbo].[UspEmployeeOper]    Script Date: 09/06/2017 07:17:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[UspEmployeeOper]
	-- Add the parameters for the stored procedure here
	--Operation=0 Insert
	--Operation=1 Update
	--Operation=1 Select
	--Operation=2 Delete

	 @Id int,
	 @Operation Tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
		declare @groupid int,@RequestType int,@CreatedEmpID int
		declare @RequestName varchar(100)
		declare @FK_CategoryId int
		Declare @WeekOffDays int,@Wekdays varchar(20)
		Declare @WkDays Table(Dno int,DName varchar(50))
	--select tblEmployee
	if @Operation=0
	begin
		select @WeekOffDays=e.WeekOffDays   from tblEmployee e where e.EmpId=@Id 
		if @WeekOffDays & power(2,1) >0  
		insert into @WkDays(Dno,DName) Values(1,'Sunday' )
		if @WeekOffDays & power(2,2) >0
		insert into @WkDays(Dno,DName) Values(2,'Monday' )
		if @WeekOffDays & power(2,3) >0  
		insert into @WkDays(Dno,DName) Values(3,'Tuesday' )
		if @WeekOffDays & power(2,4) >0
		insert into @WkDays(Dno,DName) Values(4,'Wednesday' )
		if @WeekOffDays & power(2,5) >0  
		insert into @WkDays(Dno,DName) Values(5,'ThursDay' )
		if @WeekOffDays & power(2,6) >0
		insert into @WkDays(Dno,DName) Values(6,'Friday' )
		if @WeekOffDays & power(2,7) >0  
		insert into @WkDays(Dno,DName) Values(7,'Saturday' )
		select @Wekdays=CONCAT(Dno,'|',@Wekdays) from  @WkDays
	
		select 
		emp.FirstName,
		emp.LastName,
		emp.EmployeeCode,
		emp.Title,
		desig.DesignationId,
		desig.Designation,
		emp.Manager as ManagerId,
		emp1.FirstName as Manager,
		emp.ProfilePicUrl,
	    emp.QuotesPictureUrl,
	    emp.BackGroundPicUrl,
		emp.HireDate,
		emp.FK_EmptTypeId,
		CASE WHEN emp.ConfirmationDate='1753-01-01 12:00:00 AM' THEN ''ELSE emp.ConfirmationDate END AS ConfirmationDate,
		emp.WorkEmail,
		loc.Location as Location,
		emp.WorkLocation,
		CASE WHEN emp.RelievingDate='1753-01-01 12:00:00 AM' THEN ''ELSE emp.RelievingDate END AS RelievingDate,
		emp.FK_CompanyId,
		@Wekdays as WeekOffDays,
		emp.StartTime,
		emp.EndTime
		 from tblEmployee emp 
		 join tblEmployee emp1 on emp.Manager=emp1.EmpId
		 join tblLocation loc on emp.OfficeLocation=loc.LocationId
		 join tblDesignation desig on emp.FK_DesignationId= desig.DesignationId 
		 where emp.EmpId=@Id
		 end

		 --select tblEmployeeAddress
		 if @Operation=1
		 begin
			select * from tblEmployeeAddress  where FK_EmpId=@Id
		 end

		 --select tblAcademic
		 if @Operation=2
		 begin
			select * from tblAcademic  where FK_EmpId=@Id
		 end

		 --select tblIdentityDetails
		 if @Operation=3
		 begin
			select tId.*,tIdm.IdentityType from tblIdentityDetails tId 
			join tblIdentityMaster tIdm on tId.FKIdentityTypeId=tIdm.IdentityTypeId
			where FK_EmpId=@Id
		 end

		 --select tblExperience
		  if @Operation=4
		begin
		select * from tblExperience  where FK_EmpId=@Id
		 end

		  --select tblCompetency
		  if @Operation=5
		begin
		select * from tblCompetency  where FK_EmpId=@Id
		 end

		 --delete tblAcademic
		 if @Operation=6
		begin
		if exists( select 1 from tblAcademic where FK_EmpId=@Id)
		begin
		Delete from tblAcademic where FK_EmpId=@Id
		end
		 end

		 --delete tblIdentityDetails
		 if @Operation=7
		begin
		if exists( select 1 from tblIdentityDetails where FK_EmpId=@Id)
		begin
		Delete from tblIdentityDetails where FK_EmpId=@Id
		end
		 end

		 --delete tblExperience
		 if @Operation=8
		begin
		if exists( select 1 from tblExperience where FK_EmpId=@Id)
		begin
		Delete from tblExperience where FK_EmpId=@Id
		end
		 end

		 --delete tblCompetency
		 if @Operation=9
		begin
		if exists( select 1 from tblCompetency where FK_EmpId=@Id)
		begin
		Delete from tblCompetency where FK_EmpId=@Id
		end
		 end

		 --Select for request
		 if @Operation=10
		begin
		select req.*,reqTypes.TypeName,ticket.TicketStatus,grp.GroupName as Department from [dbo].[tblRequests] req join [dbo].[tblRequestTypes] reqTypes on req.RequestType=reqTypes.TypeId
		join [dbo].[tblTicketStatus] ticket on req.RequestStatusId=ticket.StatusId join [dbo].[tblGroups] grp on 
		reqTypes.GroupId=grp.GroupId
		 where req.CreatedEmpID = @Id-- and req.Status=1
		 end

		 --delete ClientAddress
		  if @Operation=11
		begin
		if exists( select 1 from tblClientAddress where FK_ClientId=@Id)
		begin
		Delete from tblClientAddress where FK_ClientId=@Id
		end
		end

		--delete ResourcesForProjects
		if @Operation=12
		begin
		if exists( select 1 from tblResourcesForProjects where FK_ProjectId=@Id)
		begin
		Delete from tblResourcesForProjects where FK_ProjectId=@Id
		end
		 end

		 --delete MangersForProjects
		if @Operation=13
		begin
		if exists( select 1 from tblMangersForProjects where FK_ProjectId=@Id)
		begin
		Delete from tblMangersForProjects where FK_ProjectId=@Id
		end
		 end
		
		--select Project name
		 if @Operation=14
		begin
		select proj.ProjectId,proj.Name,MR.ManagerFlag from (								
		select FK_Resources,FK_ProjectId,0 as ManagerFlag from [dbo].[tblResourcesForProjects] where FK_Resources=@Id
		union 
		select FK_Managers,FK_ProjectId,1 as ManagerFlag from [dbo].[tblMangersForProjects] where FK_Managers=@Id) as MR
		inner join [dbo].[tblProjects] proj on MR.FK_ProjectId=proj.ProjectId
		 end

		 --select Project details
		  if @Operation=15
		begin
		select proj.*,client.*,cPer.* from tblProjects proj
		join tblClientInfo client on proj.FK_ClientId=client.ClientId
		join tblProjectContactPerson cPer on cPer.ContactId=proj.FK_ContactId 
		where ProjectId=@Id
		 end

		  --select MangersForProjects
		  if @Operation=16
		begin
		select mgr.*,emp.FirstName,emp.LastName from tblMangersForProjects mgr join tblEmployee emp on mgr.FK_Managers=emp.EmpId
		 where FK_ProjectId=@Id
		 end

		 --select ResourcesForProjects
		  if @Operation=17
		begin
		  select res.*,emp.FirstName,emp.LastName from tblResourcesForProjects res join tblEmployee emp on res.FK_Resources=emp.EmpId
		   where FK_ProjectId=@Id
		   end

		   --select ClientAddress
		if @Operation=18
		begin
		 select * from tblClientAddress CAdd
		 join tblProjects proj on proj.FK_ClientId=CAdd.FK_ClientId 
		 where proj.ProjectId=@Id
		   end

		--cancel request
		if @Operation=19
		begin
		select @RequestType = RequestType,@CreatedEmpID = CreatedEmpID from tblRequests where RequestId=@Id
		 Update tblRequests set Status=0, RequestStatusId = 4 where RequestId=@Id
		 select @groupId = GroupId, @RequestName=TypeName from tblRequestTypes where TypeId=@RequestType

		if(@groupId=0)
			begin
			select b.WorkEmail as ccAddress,a.WorkEmail as ToAddress,@RequestName as TypeName,a.FirstName as Name from tblEmployee a 
			join tblEmployee b on a.Manager=b.EmpId where a.EmpId=@CreatedEmpID
			end
		else
			begin
			declare @ccAddress varchar(50)
			declare @ToAddress varchar(50)
			select @ToAddress = e.WorkEmail from tblEmployee e where e.EmpId=@CreatedEmpID
			select emp.WorkEmail as ccAddress, @ToAddress as ToAddress ,req.TypeName as TypeName, '' as Name from tblRequestTypes req 
			join [dbo].[tblGroupMembers] grpEmp on req.GroupId=grpEmp.FK_GroupId 
			join tblEmployee emp on emp.EmpId=grpEmp.FK_EmployeeId 
			where req.TypeId=@RequestType
			end
		end

		--select allowance requests
		  if @Operation=20
		begin
		 select req.*,categTypes.CategoryName,ticket.TicketStatus from [dbo].[tblAllowance] req join [dbo].[tblCategory] categTypes on req.FK_CategoryId=categTypes.CategoryId
		 join [dbo].[tblTicketStatus] ticket on req.TicketStatusId=ticket.StatusId
		 where req.CreatedEmpID = @Id and categTypes.CategoryTypeId=1
		end

		--select reimbursement requests
		if @Operation=21
		begin
		 select req.*,categTypes.CategoryName,ticket.TicketStatus from [dbo].[tblReimbursement] req join [dbo].[tblCategory] categTypes on req.FK_CategoryId=categTypes.CategoryId
		 join [dbo].[tblTicketStatus] ticket on req.TicketStatusId=ticket.StatusId
		 where req.CreatedEmpID = @Id and categTypes.CategoryTypeId=2
		end

		--cancel allowance ticket
		if @Operation=22
		begin
		Update tblAllowance set Status=0,TicketStatusId = 4  where AllowanceId=@Id

		select @FK_CategoryId = FK_CategoryId,@CreatedEmpID=CreatedEmpID from tblAllowance where AllowanceId=@Id
		select @groupId = GroupId from [dbo].[tblCategory] where CategoryId=@FK_CategoryId and CategoryTypeId=1

		select @ccAddress=e.WorkEmail from tblEmployee e where e.EmpId=@CreatedEmpID

		select emp.WorkEmail as ccAddress,@ccAddress as ToAddress,req.CategoryName as TypeName,'' as Name from [dbo].[tblCategory] req 
		join [dbo].[tblGroupMembers] grpEmp on req.GroupId=grpEmp.FK_GroupId 
		join tblEmployee emp on emp.EmpId=grpEmp.FK_EmployeeId 
		where req.CategoryId=@FK_CategoryId and req.CategoryTypeId=1
		end

		--cancel reimbursement ticket
		if @Operation=23
		begin
		Update tblReimbursement set Status = 0,TicketStatusId = 4 where ReimbursementId=@Id

		select @FK_CategoryId = FK_CategoryId,@CreatedEmpID=CreatedEmpID from tblReimbursement where ReimbursementId=@Id
		select @groupId = GroupId from [dbo].[tblCategory] where CategoryId=@FK_CategoryId and CategoryTypeId=2

		select @ccAddress=e.WorkEmail from tblEmployee e where e.EmpId=@CreatedEmpID

		select emp.WorkEmail as ccAddress,@ccAddress as ToAddress,req.CategoryName as TypeName,'' as Name from [dbo].[tblCategory] req 
		join [dbo].[tblGroupMembers] grpEmp on req.GroupId=grpEmp.FK_GroupId 
		join tblEmployee emp on emp.EmpId=grpEmp.FK_EmployeeId 
		where req.CategoryId=@FK_CategoryId and req.CategoryTypeId=2
		end

		--select Projects
		if @Operation=24
		begin
		 select Name from tblProjects where FK_CompanyId=@id and Status=1
		end

		--select my leave requests
		if @Operation=25
		begin
		 SELECT T.LeaveTransId,T.FK_LeaveTypeId, C.LeaveName,T.LeaveStartDate AS FromDate ,T.LeaveEndDate AS ToDate,t.Reason,T.LeaveAppliedDays,S.TicketStatus  
			FROM tblLeaveTransaction T 
			INNER JOIN tblLeaveConfig C ON C.LeaveTypeId=T.FK_LeaveTypeId 
			INNER JOIN tblTicketStatus S ON S.StatusId=T.FK_StatusId 
		WHERE T.Fk_empid=@Id --and (T.FK_StatusId = 1 or T.FK_StatusId = 5) 
		end

		--select allowance by Id
		if @Operation=26
		begin
		 select allow.*,categ.CategoryName from tblAllowance allow 
		 join tblCategory categ on allow.FK_CategoryId=categ.CategoryId
		 where AllowanceId=@Id
		end

		--select Managers & Resource in Project
		if @Operation=27
		begin
		select e.EmpId,e.FirstName As EmployeeName  from
(select FK_Managers from tblMangersForProjects
	union 
	select FK_Resources from tblResourcesForProjects
	where FK_ProjectId=@Id ) As EmpID
	cross apply
	(select e.FirstName,e.EmpId   from dbo.tblEmployee e  where e.EmpId=EmpID.FK_Managers ) e
		end

		--Delete tasks 
		if @Operation=28
		begin
		 update tblProjectTask set Status=0 where TaskId=@Id
		 update tblProjectTaskResources set Status=0 where FK_TaskId=@Id
		end

		--select task Resources
		if @Operation=29
		begin
		 select emp.EmpId,emp.FirstName from tblProjectTaskResources tskr
		 join tblEmployee emp on emp.EmpId=tskr.FK_TaskResources
		 where tskr.FK_TaskId=@Id
		end

		--Delete documents 
		if @Operation=30
		begin
		 update tblProjectDocument set Status=0 where DocumentId=@Id
		end

		--get week off days for leave calculation
		if @Operation=31
		begin
		select @WeekOffDays=e.WeekOffDays   from tblEmployee e where e.EmpId=@Id 
		if @WeekOffDays & power(2,1) >0  
		insert into @WkDays(Dno,DName) Values(1,'Sunday' )
		if @WeekOffDays & power(2,2) >0
		insert into @WkDays(Dno,DName) Values(2,'Monday' )
		if @WeekOffDays & power(2,3) >0  
		insert into @WkDays(Dno,DName) Values(3,'Tuesday' )
		if @WeekOffDays & power(2,4) >0
		insert into @WkDays(Dno,DName) Values(4,'Wednesday' )
		if @WeekOffDays & power(2,5) >0  
		insert into @WkDays(Dno,DName) Values(5,'ThursDay' )
		if @WeekOffDays & power(2,6) >0
		insert into @WkDays(Dno,DName) Values(6,'Friday' )
		if @WeekOffDays & power(2,7) >0  
		insert into @WkDays(Dno,DName) Values(7,'Saturday' )
		select @Wekdays=CONCAT(Dno,'|',@Wekdays) from  @WkDays
		select @Wekdays as WeekOffDays
		end

		if @Operation=32
		begin
		if exists( select 1 from tblCustomResources where FK_DocumentId=@Id)
		begin
		Delete from tblCustomResources where FK_DocumentId=@Id
		end
		 end

END


GO

