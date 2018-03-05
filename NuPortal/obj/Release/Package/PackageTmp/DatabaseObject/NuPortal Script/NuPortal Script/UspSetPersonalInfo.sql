/****** Object:  StoredProcedure [dbo].[UspSetPersonalInfo]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspSetPersonalInfo]
	-- Add the parameters for the stored procedure here
	 @FK_EmpId int,
@Address1 varchar (50),
@City1 varchar (50),
@State1 varchar (50),
@Country1 varchar (50),
@ZipCode1 varchar (50),
@Phone1 varchar (50),
@Address2 varchar (50),
@City2 varchar (50),
@State2 varchar (50),
@Country2 varchar (50),
@ZipCode2 varchar (50),
@Phone2 varchar (50),
@EmergencyPhone varchar (50),
@EmailId varchar (50),
@DOB date,
@Gender varchar (10),
@Nationality varchar (50),
@BloodGroup varchar (50),
@CreatedDate datetime,
@ModifiedDate datetime,
@CreatedEmpID int,
@ModifiedEmpID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY

	BEGIN TRANSACTION
	if not exists (select 1 from tblEmployeeAddress where FK_EmpId=@FK_EmpId ) 
	BEGIN
    Insert into tblEmployeeAddress(
		FK_EmpId,
		Address1,
		City1,
		State1,
		Country1,
		ZipCode1,
		Phone1,
		Address2,
		City2,
		State2,
		Country2,
		ZipCode2,
		Phone2,
		EmergencyPhone,
		EmailId,
		DOB,
		Gender,
		Nationality,
		BloodGroup,
		CreatedDate,
		ModifiedDate,
		CreatedEmpID,
		ModifiedEmpID		)
	values(		@FK_EmpId,
		@Address1,
		@City1,
		@State1,
		@Country1,
		@ZipCode1,
		@Phone1,
		@Address2,
		@City2,
		@State2,
		@Country2,
		@ZipCode2,
		@Phone2,
		@EmergencyPhone,
		@EmailId,
		@DOB,
		@Gender,
		@Nationality,
		@BloodGroup,
		@CreatedDate,
		@ModifiedDate,
		@CreatedEmpID,
		@ModifiedEmpID
	)
	SELECT SCOPE_IDENTITY() ReturnValue
	END
	else
	BEGIN
		update tblEmployeeAddress set 
			Address1=@Address1,
			City1=@City1,
			State1=@State1,
			Country1=@Country1,
			ZipCode1=@ZipCode1,
			Phone1=@Phone1,
			Address2=@Address2,
			City2=@City2,
			State2=@State2,
			Country2=@Country2,
			ZipCode2=@ZipCode2,
			Phone2=@Phone2,
			EmergencyPhone=@EmergencyPhone,
			EmailId=@EmailId,
			DOB=@DOB,
			Gender=@Gender,
			Nationality=@Nationality,
			BloodGroup=@BloodGroup,
			--CreatedDate=@CreatedDate,
			ModifiedDate=@ModifiedDate,
			--CreatedEmpID=@CreatedEmpID,
			ModifiedEmpID=@ModifiedEmpID
			where FK_EmpId=@FK_EmpId
			select @@ROWCOUNT  ReturnValue
	END
	COMMIT TRANSACTION
 
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		select -1 ReturnValue
	END CATCH
	
END


GO