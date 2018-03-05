/****** Object:  StoredProcedure [dbo].[UspUpdateClientInfo]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspUpdateClientInfo]
@ClientId int,
@CompanyLogo varchar(50),
@CompanyName varchar(50),
@ModifiedDate datetime,
@ModifiedEmpID int,
@PurchaseOrderNumber varchar(50),
@Status bit,
@Website varchar(50)

As
BEGIN
DECLARE @Returnvalue int
	BEGIN TRY	
		BEGIN
			BEGIN TRAN
				Update tblClientInfo SET				
				CompanyName=@CompanyName,
				Website=@Website,
				PurchaseOrderNumber=@PurchaseOrderNumber,
				CompanyLogo=@CompanyLogo,
				ModifiedDate=@ModifiedDate,
				ModifiedEmpID=@ModifiedEmpID,
				Status=@Status
				 WHERE ClientId=@ClientId
		COMMIT TRAN
		select @Returnvalue= @@RowCount
		select @Returnvalue
		END
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		select @Returnvalue= @@RowCount
		select @Returnvalue
	END CATCH
	return @Returnvalue
END

GO