/****** Object:  StoredProcedure [dbo].[UspUpdateProjectContactPerson]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspUpdateProjectContactPerson]
@ContactId int,
@ContactNumber varchar(50),
@ContactPerson varchar(50),
@Department varchar(50),
@Designation varchar(50),
@Email varchar(50),
@Extension varchar(50),
@Fax varchar(50),
@Mobile varchar(50),
@ModifiedDate datetime,
@ModifiedEmpID int,
@Status bit
As
BEGIN
DECLARE @Returnvalue int
	BEGIN TRY
			BEGIN TRAN
				Update tblProjectContactPerson SET				
				ContactPerson=@ContactPerson,
				ContactNumber=@ContactNumber,
				Extension=@Extension,
				Mobile=@Mobile,
				Designation=@Designation,
				Email=@Email,
				Fax=@Fax,
				Department=@Department,
				ModifiedDate=@ModifiedDate,
				ModifiedEmpID=@ModifiedEmpID,
				Status=@Status
				 WHERE ContactId=@ContactId
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