/****** Object:  StoredProcedure [dbo].[UspUpdateProjects]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspUpdateProjects]
@Attachments varchar(max),
@CostCenter varchar(50),
@Description varchar(max),
@EndDate datetime,
@FK_ClientId int,
@FK_ContactId int,
@FK_Department int,
@ModifiedDate datetime,
@ModifiedEmpID int,
@Name varchar(50),
@PlannedHours int,
@Priority varchar(50),
@ProjectCategory varchar(50),
@ProjectId int,
@ProjectStatus varchar(50),
@ProjectType varchar(50),
@StartDate datetime,
@Status bit,
@Technologies varchar(max),
@URL varchar(50)
As
BEGIN
DECLARE @Returnvalue int
	BEGIN TRY

		
			BEGIN TRAN
				 Update tblProjects SET				
				FK_ClientId=@FK_ClientId,
				FK_ContactId=@FK_ContactId,
				Name=@Name,
				Description=@Description,
				StartDate=@StartDate,
				EndDate=@EndDate,
				URL=@URL,
				Priority=@Priority,
				ProjectStatus=@ProjectStatus,
				ProjectType=@ProjectType,
				ProjectCategory=@ProjectCategory,
				PlannedHours=@PlannedHours,
				FK_Department=@FK_Department,
				CostCenter=@CostCenter,
				Technologies=@Technologies,
				Attachments=@Attachments,
				Status=@Status,				
				ModifiedDate=@ModifiedDate,				
				ModifiedEmpID=@ModifiedEmpID
				 WHERE ProjectId=@ProjectId
		COMMIT TRAN
	    select @Returnvalue= @@RowCount
		select @Returnvalue
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		select @Returnvalue= @@RowCount
		select @Returnvalue
	END CATCH
	return @Returnvalue
END


GO