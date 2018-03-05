/****** Object:  StoredProcedure [dbo].[UspAutoComplete]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspAutoComplete] 
	-- Add the parameters for the stored procedure here
	@empName varchar(50)=null,
	@compId int,
	@Operation tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if @Operation=1
	begin
	SELECT @empName = RTRIM(@empName)+'%' ; 
    -- Insert statements for procedure here
	select EmpId,FirstName from tblEmployee where FirstName like @empName and FK_CompanyId=@compId
	end

	if @Operation=2
	begin
	SELECT @empName = RTRIM(@empName)+'%' ; 
    -- Insert statements for procedure here
	select e.EmpId,e.FirstName As FirstName  from
(select FK_Managers from tblMangersForProjects
	union 
	select FK_Resources from tblResourcesForProjects
	where FK_ProjectId=@compId ) As EmpID
	cross apply
	(select e.FirstName,e.EmpId   from dbo.tblEmployee e  where e.EmpId=EmpID.FK_Managers ) e
	where e.FirstName like @empName
	end
END
