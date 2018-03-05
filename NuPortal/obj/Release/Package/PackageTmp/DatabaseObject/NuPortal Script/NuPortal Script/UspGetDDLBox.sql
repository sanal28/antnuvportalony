USE [NuPortal]
GO

/****** Object:  StoredProcedure [dbo].[UspGetDDLBox]    Script Date: 12/06/2017 00:43:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspGetDDLBox]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Operation tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--tblDesignation
	if @Operation=0
	begin
	select DesignationId,Designation from tblDesignation 
	where FK_CompanyId=@Id and Status=1
	end

	--tblLocation
	if @Operation=1
	begin 
	select LocationId,Location from tblLocation 
	where FK_CompanyId=@Id and Status=1
	end

	--tblEmploymentType
	if @Operation=2
	begin 
	select EmptTypeId,EmploymentType from tblEmploymentType 
	where FK_CompanyId=@Id and Status=1
	end

	--tblIdentityMaster
	if @Operation=3
	begin 
	select IdentityTypeId,IdentityType from tblIdentityMaster 
	where FK_CompanyId=@Id and Status=1
	end

	--ddlRequest Types
	if @Operation=4
	begin 
	select TypeId,TypeName from tblRequestTypes 
	where (FK_CompanyId=@Id or FK_CompanyId=0) and Status=1
	end

	--ddlClientInfo
	if @Operation=5
	begin 
	select ClientId,CompanyName,CompanyLogo from tblClientInfo 
	where FK_CompanyId=@Id  and Status=1
	end

	--ddlProjectContactPerson 
	if @Operation=6
	begin 
	select ContactId,ContactPerson from tblProjectContactPerson 
	where FK_ClientId=@Id and Status=1
	end

	--ddlDepartment
	if @Operation=7
	begin 
	select DepartmentId,DepartmentName from tblDepartment 
	where FK_CompanyId=@Id and Status=1
	end

	--ddlAllowanceTypes
	if @Operation=8
	begin 
	select CategoryId,CategoryName from [dbo].[tblCategory] 
	where FK_CompanyId=@Id and Status=1 and CategoryTypeId=1
	end

	--ddlReimbursementTypes
	if @Operation=9
	begin 
	select CategoryId,CategoryName from [dbo].[tblCategory]
	where FK_CompanyId=@Id and Status=1 and CategoryTypeId=2
	end

	--ddlRole
	if @Operation=10
	begin 
	select RoleId,RoleName from tblRole
	where FK_CompanyId=@Id and Status=1 
	end

	--ddlLeaveRole
	if @Operation=11
	begin 
	select LeaveTypeId,LeaveName from [dbo].[tblLeaveConfig]
	where FK_CompanyId=@Id and Status=1 
	end

	--ddlTaskStatus
	if @Operation=12
	begin 
	select ProjectStatusId,StatusText from [dbo].[tblProjectTaskStatus]
	where FK_CompanyId=@Id and Status=1 
	end

	--ddlTaskName
	if @Operation=13
	begin 
	select TaskId,TaskName from [dbo].[tblProjectTask]
	where Fk_ProjectId=@Id and Status=1 and (Fk_TaskStatusId =2 OR
		TaskCompletedDate >=CASE  WHEN Fk_TaskStatusId =3 THEN DATEADD(WK,-2,GETDATE()) END  )	
	end

	--ddlRole
	if @Operation=13
	begin 
	select SharedTypeId,SharedTypeName from vueSharedType where SharedTypeId!=3
	union
	select RoleId,RoleName from tblRole
	end
END


GO

