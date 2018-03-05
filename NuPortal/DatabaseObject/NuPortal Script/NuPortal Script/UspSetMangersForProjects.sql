/****** Object:  StoredProcedure [dbo].[UspSetMangersForProjects]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspSetMangersForProjects]
@FK_Managers int,
@FK_ProjectId int,
@MFPId int,
@Status bit,
@Operation Tinyint
As
BEGIN
DECLARE @Returnvalue int
	BEGIN TRY
		if @Operation=1
		BEGIN
			BEGIN TRAN
			INSERT INTO dbo.tblMangersForProjects(FK_Managers,FK_ProjectId,Status)
			VALUES(@FK_Managers,@FK_ProjectId,@Status)
			Select @Returnvalue=SCOPE_IDENTITY();
			COMMIT TRAN
		END
		if @Operation=2
		BEGIN
			BEGIN TRAN
				 Update tblMangersForProjects SET				FK_ProjectId=@FK_ProjectId,
				FK_Managers=@FK_Managers,
				Status=@Status
				 WHERE MFPId=@MFPId
		COMMIT TRAN
		END
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
	return @Returnvalue
END


GO