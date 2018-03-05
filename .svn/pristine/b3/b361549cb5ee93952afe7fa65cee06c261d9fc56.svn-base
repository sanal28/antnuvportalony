/****** Object:  StoredProcedure [dbo].[UspProjectDocumentOper]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspProjectDocumentOper]
@Attachments varchar(Max),
@CreatedDate datetime,
@CreatedEmpID int,
@Description varchar(Max),
@DocumentId int=null,
@DocumentName varchar(50),
@FK_ProjectId int,
@FK_RoleId int,
@FK_SharedTypeId int,
@ModifiedDate datetime,
@ModifiedEmpID int,
@Status bit,
@Operation Tinyint
As
BEGIN
DECLARE @Returnvalue int
	BEGIN TRY
		if @Operation=1
		BEGIN
			BEGIN TRAN
			INSERT INTO dbo.tblProjectDocument(Attachments,CreatedDate,CreatedEmpID,Description,DocumentName,FK_ProjectId,FK_RoleId,FK_SharedTypeId,ModifiedDate,ModifiedEmpID,Status)
			VALUES(@Attachments,@CreatedDate,@CreatedEmpID,@Description,@DocumentName,@FK_ProjectId,@FK_RoleId,@FK_SharedTypeId,@ModifiedDate,@ModifiedEmpID,@Status)
			Select @Returnvalue=SCOPE_IDENTITY();
			COMMIT TRAN
			select @Returnvalue as DocumentId
		END
		if @Operation=2
		BEGIN
			BEGIN TRAN
				Update tblProjectDocument SET				
				FK_ProjectId=@FK_ProjectId,
				DocumentName=@DocumentName,
				FK_SharedTypeId=@FK_SharedTypeId,
				FK_RoleId=@FK_RoleId,
				Description=@Description,
				Attachments=@Attachments,
				Status=@Status,
				CreatedDate=@CreatedDate,
				ModifiedDate=@ModifiedDate,
				CreatedEmpID=@CreatedEmpID,
				ModifiedEmpID=@ModifiedEmpID
				 WHERE DocumentId=@DocumentId
				 select @@ROWCOUNT as RowC
		COMMIT TRAN
		END
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
	return @Returnvalue
END


GO