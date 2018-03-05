/****** Object:  StoredProcedure [dbo].[UspSaveRequests]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspSaveRequests]
@CreatedDate datetime,
@CreatedEmpID int,
@ModifiedDate datetime,
@ModifiedEmpID int,
@RequestedDate datetime,
@RequestedToDate datetime,
@RequestText varchar(MAX),
@Attachments varchar(MAX),
@RequestType int,
@Status bit

As
BEGIN
DECLARE @Returnvalue int
	BEGIN TRY
		BEGIN
			BEGIN TRAN
			INSERT INTO dbo.tblRequests
			(
			CreatedDate,
			CreatedEmpID,
			ModifiedDate,
			ModifiedEmpID,
			RequestedDate,
			RequestedToDate,
			RequestStatusId,
			RequestText,
			RequestType,
			Attachments,
			Status
			)
			VALUES
			(
			@CreatedDate,
			@CreatedEmpID,
			@ModifiedDate,
			@ModifiedEmpID,
			@RequestedDate,
			@RequestedToDate,
			1,
			@RequestText,
			@RequestType,
			@Attachments,
			@Status
			)
			Select @Returnvalue=SCOPE_IDENTITY();
			COMMIT TRAN
		END

		
		declare @groupId int
		declare @RequestName varchar(100)
		
		select @groupId = GroupId, @RequestName=TypeName from tblRequestTypes where TypeId=@RequestType
		if(@groupId=0)
			begin
			select b.WorkEmail as ToAddress,a.WorkEmail as ccAddress,@RequestName as TypeName,a.FirstName as Name from tblEmployee a 
			join tblEmployee b on a.Manager=b.EmpId where a.EmpId=@CreatedEmpID
			end
		else
			begin
			declare @ccAddress varchar(50)
			declare @Name varchar(50)
			select @ccAddress=e.WorkEmail,@Name = e.FirstName from tblEmployee e where e.EmpId=@CreatedEmpID
			select emp.WorkEmail as ToAddress,@ccAddress as ccAddress,req.TypeName as TypeName,@Name as Name from tblRequestTypes req 
			join [dbo].[tblGroupMembers] grpEmp on req.GroupId=grpEmp.FK_GroupId 
			join tblEmployee emp on emp.EmpId=grpEmp.FK_EmployeeId 
			where req.TypeId=@RequestType
			end
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
END

GO