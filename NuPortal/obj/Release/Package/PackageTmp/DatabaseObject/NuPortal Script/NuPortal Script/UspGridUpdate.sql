/****** Object:  StoredProcedure [dbo].[UspGridUpdate]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspGridUpdate]
	-- Add the parameters for the stored procedure here
	 @Id int,
	 @statusId int,
	 @EmpId int,
	 @Operation int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	declare @groupId int,@CreatedEmpID int,@RequestType int, @FK_CategoryId int
	declare @RequestName varchar(100), @ccAddress varchar(50),@Name varchar(100)
	
	select @Name= FirstName from tblEmployee where EmpId=@EmpId

	if @Operation=1
		begin
			update tblAllowance set TicketStatusId=@statusId, FK_RespondedBy = case when @statusId in (2,4) then @EmpId else NULL end,
			ModifiedEmpID=@EmpId,ModifiedDate=getdate() where AllowanceId=@id
		if(@statusId in (2,4))
		begin
			select @FK_CategoryId = FK_CategoryId,@CreatedEmpID=CreatedEmpID from tblAllowance where AllowanceId=@Id
			select @groupId = GroupId from [dbo].[tblCategory] where CategoryId=@FK_CategoryId and CategoryTypeId=1

			select @ccAddress=e.WorkEmail from tblEmployee e where e.EmpId=@CreatedEmpID

			select emp.WorkEmail as ccAddress,@ccAddress as ToAddress,req.CategoryName as TypeName,@Name as Name from [dbo].[tblCategory] req 
			join [dbo].[tblGroupMembers] grpEmp on req.GroupId=grpEmp.FK_GroupId 
			join tblEmployee emp on emp.EmpId=grpEmp.FK_EmployeeId 
			where req.CategoryId=@FK_CategoryId and req.CategoryTypeId=1
		end
	end
	if @Operation=2
		begin
			update tblReimbursement set TicketStatusId=@statusId, FK_RespondedBy = case when @statusId in (2,4) then @EmpId else NULL end,
			ModifiedEmpID=@EmpId,ModifiedDate=getdate() where ReimbursementId=@id
		if(@statusId in (2,4))
		begin
			select @FK_CategoryId = FK_CategoryId,@CreatedEmpID=CreatedEmpID from tblReimbursement where ReimbursementId=@Id
			select @groupId = GroupId from [dbo].[tblCategory] where CategoryId=@FK_CategoryId and CategoryTypeId=2

			select @ccAddress=e.WorkEmail from tblEmployee e where e.EmpId=@CreatedEmpID

			select emp.WorkEmail as ccAddress,@ccAddress as ToAddress,req.CategoryName as TypeName,@Name as Name from [dbo].[tblCategory] req 
			join [dbo].[tblGroupMembers] grpEmp on req.GroupId=grpEmp.FK_GroupId 
			join tblEmployee emp on emp.EmpId=grpEmp.FK_EmployeeId 
			where req.CategoryId=@FK_CategoryId and req.CategoryTypeId=2
		end
	end
	if @Operation=3
		begin
			update tblRequests set RequestStatusId=@statusId, FK_RespondedBy = case when @statusId in (2,4) then @EmpId else NULL end,
			ModifiedEmpID=@EmpId,ModifiedDate=getdate() where RequestId=@id
		if(@statusId in (2,4))
		begin
			select @RequestType = RequestType,@CreatedEmpID = CreatedEmpID from tblRequests where RequestId=@Id
		    select @groupId = GroupId, @RequestName=TypeName from tblRequestTypes where TypeId=@RequestType

			if(@groupId=0)
				begin
				select b.WorkEmail as ccAddress,a.WorkEmail as ToAddress,@RequestName as TypeName,@Name as Name from tblEmployee a 
				join tblEmployee b on a.Manager=b.EmpId where a.EmpId=@CreatedEmpID
				end
			else
				begin
				declare @ToAddress varchar(50)
				select @ToAddress = e.WorkEmail from tblEmployee e where e.EmpId=@CreatedEmpID
				select emp.WorkEmail as ccAddress, @ToAddress as ToAddress ,req.TypeName as TypeName, @Name as Name from tblRequestTypes req 
				join [dbo].[tblGroupMembers] grpEmp on req.GroupId=grpEmp.FK_GroupId 
				join tblEmployee emp on emp.EmpId=grpEmp.FK_EmployeeId 
				where req.TypeId=@RequestType
				end
			end
	end
END

GO