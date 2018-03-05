GO
/****** Object:  StoredProcedure [dbo].[UspClientInfoOper]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspClientInfoOper]
@CompanyLogo varchar(50),
@CompanyName varchar(50),
@CreatedDate datetime,
@CreatedEmpID int,
@FK_CompanyId int,
@ModifiedDate datetime,
@ModifiedEmpID int,
@PurchaseOrderNumber varchar(50),
@Status bit,
@Website varchar(50)

As
BEGIN
DECLARE @Returnvalue int
	BEGIN TRY
		
			BEGIN TRAN
			INSERT INTO dbo.tblClientInfo(CompanyLogo,CompanyName,CreatedDate,CreatedEmpID,FK_CompanyId,ModifiedDate,ModifiedEmpID,PurchaseOrderNumber,Status,Website)
			VALUES(@CompanyLogo,@CompanyName,@CreatedDate,@CreatedEmpID,@FK_CompanyId,@ModifiedDate,@ModifiedEmpID,@PurchaseOrderNumber,@Status,@Website)
			Select @Returnvalue=SCOPE_IDENTITY();
			COMMIT TRAN
	select @Returnvalue as clientId
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		select @Returnvalue as clientId
	END CATCH
	
END
