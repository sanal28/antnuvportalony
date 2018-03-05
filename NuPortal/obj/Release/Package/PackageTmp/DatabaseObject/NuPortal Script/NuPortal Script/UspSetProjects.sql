/****** Object:  StoredProcedure [dbo].[UspSetProjects]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspSetProjects]
@Attachments varchar(Max)=null,
@CostCenter varchar(50),
@Description varchar(Max),
@EndDate datetime,
@FK_ClientId int,
@FK_CompanyId int,
@FK_ContactId int,
@FK_Department int,
@Name varchar(50),
@PlannedHours int,
@Priority varchar(50),
@ProjectCategory varchar(50),
@ProjectStatus varchar(50),
@ProjectType varchar(50),
@StartDate datetime,
@Status bit,
@Technologies varchar(Max),
@URL varchar(50),
@CreatedDate datetime,
@CreatedEmpID int,
@ModifiedDate datetime,
@ModifiedEmpID int

As
BEGIN
DECLARE @Returnvalue int
	BEGIN TRY
		
			BEGIN TRAN
			INSERT INTO dbo.tblProjects(Attachments,CostCenter,Description,EndDate,FK_ClientId,FK_CompanyId,FK_ContactId,FK_Department,Name,PlannedHours,Priority,ProjectCategory,ProjectStatus,ProjectType,StartDate,Status,Technologies,URL,CreatedDate,CreatedEmpID,ModifiedDate,ModifiedEmpID)
			VALUES(@Attachments,@CostCenter,@Description,@EndDate,@FK_ClientId,@FK_CompanyId,@FK_ContactId,@FK_Department,@Name,@PlannedHours,@Priority,@ProjectCategory,@ProjectStatus,@ProjectType,@StartDate,@Status,@Technologies,@URL,@CreatedDate,@CreatedEmpID,@ModifiedDate,@ModifiedEmpID)
			Select @Returnvalue=SCOPE_IDENTITY();
			COMMIT TRAN
		select @Returnvalue as ProjectId
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		select @Returnvalue as ProjectId
	END CATCH
	
END


GO