/****** Object:  StoredProcedure [dbo].[UspGridOperations]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[UspGridOperations]
	-- Add the parameters for the stored procedure here
	--Operation=0 Insert
	--Operation=1 Update
	--Operation=1 Select
	--Operation=2 Delete

	 @Id int,
	 @Operation Tinyint
AS
BEGIN

		--Note:- Priority Types:  1-Low, 2-Medium, 3-High
		--select all my tasks except completed
		if @Operation=1
		begin
		 select tsk.TaskId,tsk.TaskName,prj.ProjectId,prj.Name as ProjectName,tsk.StartDate,tsk.EndDate,tsk.Priority,
		 tsk.Fk_TaskStatusId,stat.[StatusText] as TaskStatus,tsk.PlannedHours,tsk.Billable,
		 tsk.Attachments,emp.FirstName as FNameAssignedBy,emp.LastName as LNameAssignedBy
		 from tblProjectTaskResources res 
		 join tblProjectTask tsk on res.FK_TaskId=tsk.TaskId
		 join tblProjects prj on prj.ProjectId=tsk.Fk_ProjectId
		 join [dbo].[tblProjectTaskStatus] stat on stat.ProjectStatusId=tsk.Fk_TaskStatusId
		 join tblEmployee emp on tsk.CreatedEmpID=emp.EmpId
		 where res.FK_TaskResources=@Id and prj.Status=1 and tsk.Status=1 and res.Status=1 and tsk.Fk_TaskStatusId not in (3)
		end

		--select all my completed tasks
		if @Operation=2
		begin
		 select tsk.TaskId,tsk.TaskName,prj.ProjectId,prj.Name as ProjectName,tsk.StartDate,tsk.EndDate,tsk.Priority,
		 tsk.Fk_TaskStatusId,stat.[StatusText] as TaskStatus,tsk.PlannedHours,tsk.Billable,
		 tsk.Attachments,emp.FirstName as FNameAssignedBy,emp.LastName as LNameAssignedBy
		 from tblProjectTaskResources res 
		 join tblProjectTask tsk on res.FK_TaskId=tsk.TaskId
		 join tblProjects prj on prj.ProjectId=tsk.Fk_ProjectId
		 join [dbo].[tblProjectTaskStatus] stat on stat.ProjectStatusId=tsk.Fk_TaskStatusId
		 join tblEmployee emp on tsk.CreatedEmpID=emp.EmpId
		 where res.FK_TaskResources=@Id and prj.Status=1 and tsk.Status=1 and res.Status=1 and tsk.Fk_TaskStatusId = 3
		end

		--select my project task details based on id
		if @Operation=3
		begin
		 select TaskId,TaskName,StartDate,EndDate,Priority,PlannedHours,ProjectPhase,TaskDetails,Comments,
		 Fk_TaskStatusId,Attachments from tblProjectTask tsk
		 where TaskId=@Id
		end

		--select my ticket details based on id
		if @Operation=4
		begin
			select tbl.*,rqstcat.TypeName as RequestType from(
			select rqst.RequestId as RowId,3 as RequestTypeId,rqst.CreatedEmpID as RequestedById,emp.FirstName as RequestedByFname,emp.LastName as RequestedByLname,
			rqst.RequestedDate,
			--rqTypes.TypeName as CategoryName,
			--'Requests' as CategoryName,
			stat.TicketStatus
			from tblRequests rqst
			join tblRequestTypes rqTypes on rqst.RequestType=rqTypes.TypeId
			join tblEmployee emp on rqst.CreatedEmpID=emp.EmpId
			join tblTicketStatus stat on rqst.RequestStatusId = stat.StatusId
			left outer join tblGroupMembers grpMem on rqTypes.GroupId = grpMem.FK_GroupId
			where case when rqTypes.GroupId = 0 then emp.Manager else grpMem.FK_EmployeeId  end = @Id and rqst.RequestStatusId not in (2,3,4)
			union
			select AllorReim.RowId,AllorReim.RequestTypeId,AllorReim.RequestedById,emp.FirstName as RequestedByFname,emp.LastName as RequestedByLname,
			AllorReim.RequestedDate,--AllorReim.CategoryName,
			--categ.CategoryName,
			stat.TicketStatus from 
			(select allo.AllowanceId as RowId,1 as RequestTypeId,allo.CreatedEmpID as RequestedById,allo.CreatedDate as RequestedDate,
			allo.FK_CategoryId as CatergoryId,allo.TicketStatusId as TicketStatusId--,'Allowance' as CategoryName
			 from tblAllowance allo
			 union
			 select reim.ReimbursementId as RowId,2 as RequestTypeId,reim.CreatedEmpID as RequestedById,reim.CreatedDate as RequestedDate,
			 reim.FK_CategoryId as CategoryId,reim.TicketStatusId as TicketStatusId--,'Reimbursement' as CategoryName
			 from tblReimbursement reim)as AllorReim
			join tblCategory categ on AllorReim.CatergoryId=categ.CategoryId
			join tblEmployee emp on AllorReim.RequestedById=emp.EmpId
			join tblTicketStatus stat on AllorReim.TicketStatusId = stat.StatusId
			left outer join tblGroupMembers grpMem on categ.GroupId = grpMem.FK_GroupId
			where grpMem.FK_EmployeeId = @Id and AllorReim.TicketStatusId not in (2,3,4)
			union
			select leave.LeaveTransId as RowId,4 as RequestTypeId,leave.FK_EmpId as RequestedById,emp.FirstName as RequestedByFname,emp.LastName as RequestedByLname,
			leave.CreatedDate as RequestedDate,--'Leave' as CategoryName,
			stat.TicketStatus as TicketStatus
			from tblLeaveTransaction leave
			join tblEmployee emp on leave.FK_EmpIdRequester=emp.EmpId
			join tblTicketStatus stat on leave.FK_StatusId=stat.StatusId
			where leave.FK_EmpAssignedTo=@Id and leave.FK_StatusId not in (2,3,4))tbl
			join vueRequestCategory rqstcat on tbl.RequestTypeId = rqstcat.RequestCategoryId order by RequestedDate desc
		end

		--select Document Grid
		if @Operation=5
		BEGIN
		Declare @Managerid varchar(max)
		create table #DocumentGrid(DocumentId int,DocumentsName varchar(Max),Description varchar(Max),
		CreatedBy varchar(Max),CreatedDate varchar(Max),SharedWith varchar(Max),Attachments varchar(Max))
		
			IF EXISTS(SELECT 1 from dbo.tblProjectDocument where FK_ProjectId =@Id AND FK_SharedTypeId=1 and Status=1)
			BEGIN
				SET @Managerid=''
				SELECT @Managerid=CONCAT(@Managerid,e.FirstName ,',')  from 
				(SELECT p.FK_Managers  as id FROM dbo.tblMangersForProjects p where p.FK_ProjectId =@Id
				UNION
				SELECT p.FK_Resources  as id FROM dbo.tblResourcesForProjects p where p.FK_ProjectId=@Id) b	
				inner join dbo.tblEmployee e on e.EmpId=b.id 	
				INSERT INTO #DocumentGrid(DocumentId,DocumentsName,Description,CreatedBy,CreatedDate,Attachments
				,SharedWith) 							
				SELECT 
				DocumentId,DocumentName,[Description],e.FirstName ,s.CreatedDate,Attachments,@Managerid AS ShareWith
				from tblProjectDocument s
				inner join dbo.tblEmployee e on e.EmpId=s.CreatedEmpID 
				 where FK_ProjectId =@Id	AND FK_SharedTypeId=1 and s.Status=1					
			END
			IF EXISTS(SELECT 1 from dbo.tblProjectDocument where FK_ProjectId =@Id AND FK_SharedTypeId=2 and Status=1)
			BEGIN
				SET @Managerid=''
				SELECT @Managerid=CONCAT(@Managerid,e.FirstName  ,',')  FROM dbo.tblMangersForProjects p
				inner join dbo.tblEmployee e on e.EmpId=p.FK_Managers 
				 where p.FK_ProjectId =@Id
				INSERT INTO #DocumentGrid(DocumentId,DocumentsName,Description,CreatedBy,CreatedDate,Attachments
				,SharedWith) 							 				
				SELECT 
				DocumentId,DocumentName,[Description],e.FirstName ,s.CreatedDate,Attachments,@Managerid AS ShareWith
				from tblProjectDocument s
				inner join dbo.tblEmployee e on e.EmpId=s.CreatedEmpID 
				 where FK_ProjectId =@Id	  AND FK_SharedTypeId=2 and s.Status=1				
			END
			IF EXISTS(SELECT 1 from dbo.tblProjectDocument where FK_ProjectId =@Id AND FK_SharedTypeId=3 and Status=1)
			BEGIN
				SET @Managerid=''
				SELECT @Managerid=CONCAT(@Managerid,e.FirstName  ,',') 
				FROM tblProjectDocument s				
				INNER JOIN dbo.tblResourcesForProjects rs on rs.FK_RoleId=s.FK_RoleId 
				INNER JOIN dbo.tblEmployee e on e.EmpId =rs.FK_Resources 
				 
				INSERT INTO #DocumentGrid(DocumentId,DocumentsName,Description,CreatedBy,CreatedDate,Attachments
				,SharedWith) 	
				SELECT DocumentId,DocumentName,[Description],E.FirstName, s.CreatedDate,Attachments,@Managerid AS ShareWith
				FROM tblProjectDocument s
				INNER JOIN dbo.tblEmployee e on e.EmpId=s.CreatedEmpID 
				WHERE S.FK_ProjectId=@Id    AND FK_SharedTypeId=3 and s.Status=1
			END
			IF EXISTS(SELECT 1 from dbo.tblProjectDocument where FK_ProjectId =@Id AND FK_SharedTypeId=4 and Status=1)
			BEGIN
				SET @Managerid=''
				SELECT @Managerid=CONCAT(@Managerid,mgr.FirstName  ,',') 
				FROM tblProjectDocument s				
				INNER JOIN dbo.tblCustomResources cr on cr.FK_DocumentId=s.DocumentId 
				INNER JOIN dbo.tblEmployee mgr on mgr.EmpId=cr.FK_SharedResource
				 
				INSERT INTO #DocumentGrid(DocumentId,DocumentsName,Description,CreatedBy,CreatedDate,Attachments
				,SharedWith) 	
				SELECT DocumentId,DocumentName,[Description],E.FirstName, s.CreatedDate,Attachments,@Managerid  AS ShareWith
				FROM tblProjectDocument s			
				
				INNER JOIN dbo.tblEmployee e on e.EmpId=s.CreatedEmpID 
				WHERE S.FK_ProjectId=@Id    AND FK_SharedTypeId=4 and s.Status=1
			END
			SELECT * FROM #DocumentGrid
			DROP TABLE #DocumentGrid
		end

		--Get all tickets approved by me
		if @Operation=6
		BEGIN
		select tbl1.*,emp.FirstName as RequestedFname,emp.LastName as RequestedLname,stat.TicketStatus,rqstcat.TypeName as RequestType from 
			(select RequestId as RowId,3 as RequestTypeId,CreatedEmpID as RequestedById,CreatedDate as RequestedDate,RequestStatusId as TicketStatusId,FK_RespondedBy
		    from tblRequests
			union
			select AllowanceId as RowId,1 as RequestTypeId,CreatedEmpID as RequestedById,CreatedDate as RequestedDate,TicketStatusId as TicketStatusId,FK_RespondedBy
			from tblAllowance
			union
			select ReimbursementId as RowId,2 as RequestTypeId,CreatedEmpID as RequestedById,CreatedDate as RequestedDate,TicketStatusId as TicketStatusId,FK_RespondedBy
			from tblReimbursement
			union
			select LeaveTransId as RowId,4 as RequestTypeId,FK_EmpId as RequestedById,CreatedDate as RequestedDate,FK_StatusId as TicketStatusId,FK_RespondedBy
			from tblLeaveTransaction)tbl1
			join tblEmployee emp on tbl1.RequestedById=emp.EmpId
			join tblTicketStatus stat on stat.StatusId=tbl1.TicketStatusId
			join vueRequestCategory rqstcat on tbl1.RequestTypeId = rqstcat.RequestCategoryId
			where tbl1.TicketStatusId=2 and FK_RespondedBy = @Id
			order by RequestedDate desc
		END

		--Get allowance by id
		if @Operation=7
		BEGIN
		 select * from tblAllowance where AllowanceId=@id
		END

		--Get reimbursement by id
		if @Operation=8
		BEGIN
		 select * from tblReimbursement where ReimbursementId=@id
		END

		--Get Requests by id
		if @Operation=9
		BEGIN
		 select req.*,reqT.TypeName from tblRequests req
		 join tblRequestTypes reqT on req.RequestType=reqT.TypeId
		 where RequestId=@id
		END

		--Get Leave by id
		if @Operation=10
		BEGIN
		 select * from tblLeaveTransaction where LeaveTransId=@id
		END


				--select tasks except completed
		if @Operation=11
		begin
		 select tsk.TaskId,tsk.TaskName,prj.ProjectId,prj.Name as ProjectName,tsk.StartDate,tsk.EndDate,tsk.Priority,
		 tsk.Fk_TaskStatusId,stat.[StatusText] as TaskStatus,tsk.PlannedHours,tsk.Billable,
		 tsk.Attachments,emp.FirstName as FNameAssignedBy,emp.LastName as LNameAssignedBy
		 from tblProjectTaskResources res 
		 join tblProjectTask tsk on res.FK_TaskId=tsk.TaskId
		 join tblProjects prj on prj.ProjectId=tsk.Fk_ProjectId
		 join [dbo].[tblProjectTaskStatus] stat on stat.ProjectStatusId=tsk.Fk_TaskStatusId
		 join tblEmployee emp on tsk.CreatedEmpID=emp.EmpId
		 where tsk.Fk_ProjectId=@Id and prj.Status=1 and tsk.Status=1 and res.Status=1 and tsk.Fk_TaskStatusId not in (3)
		end

		--select   completed tasks
		if @Operation=12
		begin
		 select tsk.TaskId,tsk.TaskName,prj.ProjectId,prj.Name as ProjectName,tsk.StartDate,tsk.EndDate,tsk.Priority,
		 tsk.Fk_TaskStatusId,stat.[StatusText] as TaskStatus,tsk.PlannedHours,tsk.Billable,
		 tsk.Attachments,emp.FirstName as FNameAssignedBy,emp.LastName as LNameAssignedBy
		 from tblProjectTaskResources res 
		 join tblProjectTask tsk on res.FK_TaskId=tsk.TaskId
		 join tblProjects prj on prj.ProjectId=tsk.Fk_ProjectId
		 join [dbo].[tblProjectTaskStatus] stat on stat.ProjectStatusId=tsk.Fk_TaskStatusId
		 join tblEmployee emp on tsk.CreatedEmpID=emp.EmpId
		 where tsk.Fk_ProjectId=@Id and prj.Status=1 and tsk.Status=1 and res.Status=1 and tsk.Fk_TaskStatusId = 3
		end

		--select to leave calender
		if @Operation=13
		begin
		SELECT * FROM tblLeaveTransaction --LeaveTransId as Id,FK_EmpIdRequester as RequesterId,LeaveStartDate,LeaveEndDate
		WHERE fk_respondedby=@Id
		UNION
		SELECT lv.* FROM tblLeaveTransaction lv
		join tblEmployee emp on lv.FK_EmpIdRequester=emp.EmpId WHERE Manager=@Id
		AND Lv.FK_StatusId=2 AND Lv.FK_LeaveTransId=0
		UNION
		SELECT L.* from tblLeaveTransaction L
		WHERE EXISTS( SELECT 1 FROM  tblMangersForProjects mgr
		INNER JOIN tblResourcesForProjects res on mgr.FK_ProjectId=res.FK_ProjectId
		WHERE mgr.FK_Managers=@Id AND
		L.FK_EmpIdRequester=res.FK_Resources  )  AND L.FK_StatusId=2 AND L.FK_LeaveTransId=0 
		end
		--SELECT * FROM tblLeaveTransaction --LeaveTransId as Id,FK_EmpIdRequester as RequesterId,LeaveStartDate,LeaveEndDate
		-- WHERE fk_respondedby=@Id
		--  UNION 
		--select lv.* from tblLeaveTransaction lv
		--INNER JOIN  tblEmployee emp ON lv.FK_EmpIdRequester=emp.EmpId WHERE Manager=@Id
		--AND 
		--EXISTS ( SELECT 1 FROM dbo.tblMangersForProjects   mgr
		--INNER JOIN tblResourcesForProjects res ON mgr.FK_ProjectId=res.FK_ProjectId WHERE   mgr.FK_Managers=emp.Manager      )
		--		end

		--select to get managers and client info based on project id
		if @Operation=14
		begin
		select prj.ProjectId,prj.FK_ClientId,mgr.FK_Managers,emp.FirstName,emp.LastName,desig.Designation,client.CompanyName,emp.ProfilePicUrl from tblMangersForProjects mgr
		join tblProjects prj on mgr.FK_ProjectId=prj.ProjectId
		join tblEmployee emp on mgr.FK_Managers=emp.EmpId 
		join tblClientInfo client on client.ClientId=prj.FK_ClientId
		join tblDesignation desig on emp.FK_DesignationId=desig.DesignationId
		where prj.ProjectId=@id
		end

END


GO