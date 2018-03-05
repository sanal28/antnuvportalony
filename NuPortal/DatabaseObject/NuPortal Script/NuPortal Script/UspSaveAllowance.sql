/****** Object:  StoredProcedure [dbo].[UspSaveAllowance]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspSaveAllowance]
	-- Add the parameters for the stored procedure here
@Amount float,
@Attachments varchar(MAX),
@CreatedDate datetime,
@CreatedEmpID int,
@Date datetime,
@EndDate datetime,
@Description varchar(MAX),
@FK_CategoryId int,
@ModifiedDate datetime,
@ModifiedEmpID int,
@CategoryTypeId int,
@Status int

AS
BEGIN
DECLARE @Returnvalue int
	BEGIN TRY
		BEGIN
			BEGIN TRAN
			if(@CategoryTypeId=1)
			begin
			INSERT INTO [dbo].[tblAllowance]
			(
			Amount,
			Attachments,
			CreatedDate,
			CreatedEmpID,
			Date,
			Description,
			FK_CategoryId,
			ModifiedDate,
			ModifiedEmpID,
			Status,
			TicketStatusId
			)
			VALUES
			(
			@Amount,
			@Attachments,
			@CreatedDate,
			@CreatedEmpID,
			@Date,
			@Description,
			@FK_CategoryId,
			@ModifiedDate,
			@ModifiedEmpID,
			@Status,
			1
			)
			end
			else if(@CategoryTypeId=2)
			begin
			INSERT INTO [dbo].[tblReimbursement]
			(
			Amount,
			Attachments,
			CreatedDate,
			CreatedEmpID,
			Description,
			EndDate,
			FK_CategoryId,
			ModifiedDate,
			ModifiedEmpID,
			StartDate,
			Status,
			TicketStatusId
			)
			VALUES
			(
			@Amount,
			@Attachments,
			@CreatedDate,
			@CreatedEmpID,
			@Description,
			@EndDate,
			@FK_CategoryId,
			@ModifiedDate,
			@ModifiedEmpID,
			@Date,
			@Status,
			1
			)
			end
			Select @Returnvalue=SCOPE_IDENTITY();
			COMMIT TRAN
		END

		
		declare @groupId int
		--declare @CategoryName varchar(100)
		declare @ccAddress varchar(50)
		declare @Name varchar(50)

		select @groupId = GroupId from [dbo].[tblCategory] where CategoryId=@FK_CategoryId and CategoryTypeId=@CategoryTypeId

		select @ccAddress=e.WorkEmail,@Name = e.FirstName from tblEmployee e where e.EmpId=@CreatedEmpID

		select emp.WorkEmail as ToAddress,@ccAddress as ccAddress,req.CategoryName as TypeName,@Name as Name from [dbo].[tblCategory] req 
		join [dbo].[tblGroupMembers] grpEmp on req.GroupId=grpEmp.FK_GroupId 
		join tblEmployee emp on emp.EmpId=grpEmp.FK_EmployeeId 
		where req.CategoryId=@FK_CategoryId and req.CategoryTypeId=@CategoryTypeId
		
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
END
GO