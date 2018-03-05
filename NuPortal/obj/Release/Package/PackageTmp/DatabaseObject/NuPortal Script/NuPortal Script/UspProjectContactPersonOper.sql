/****** Object:  StoredProcedure [dbo].[UspProjectContactPersonOper]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspProjectContactPersonOper]
@ContactNumber varchar(50),
@ContactPerson varchar(50),
@CreatedDate datetime,
@CreatedEmpID int,
@Department varchar(50),
@Designation varchar(50),
@Email varchar(50),
@Extension varchar(50),
@Fax varchar(50),
@FK_ClientId int,
@Mobile varchar(50),
@ModifiedDate datetime,
@ModifiedEmpID int,
@Status bit

As
BEGIN
DECLARE @Returnvalue int
	BEGIN TRY		
			BEGIN TRAN
			INSERT INTO dbo.tblProjectContactPerson(ContactNumber,ContactPerson,CreatedDate,CreatedEmpID,Department,Designation,Email,Extension,Fax,FK_ClientId,Mobile,ModifiedDate,ModifiedEmpID,Status)
			VALUES(@ContactNumber,@ContactPerson,@CreatedDate,@CreatedEmpID,@Department,@Designation,@Email,@Extension,@Fax,@FK_ClientId,@Mobile,@ModifiedDate,@ModifiedEmpID,@Status)
			Select @Returnvalue=SCOPE_IDENTITY();
			COMMIT TRAN		
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
	return @Returnvalue
END


GO