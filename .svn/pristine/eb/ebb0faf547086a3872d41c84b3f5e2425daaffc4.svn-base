/****** Object:  StoredProcedure [dbo].[UspSetEmployeeInfo]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspSetEmployeeInfo] 
	-- Add the parameters for the stored procedure here
	@FirstName VARCHAR(50),  
     @LastName varchar(50) ,
	 @EmployeeCode varchar(30) ,
     @Title varchar(10) ,
	 @JobTitle int,  
     @Manager varchar(50),
	 @ProfilePicUrl VARCHAR(200),  
	 @QuotesPictureUrl VARCHAR(200),  
	 @BackGroundPicUrl VARCHAR(200),  
     @HireDate datetime,
	 @ConfirmationDate datetime ,  
     @WorkEmail varchar(50),
	 @OfficeLocation int ,  
	 @WorkLocation VARCHAR(50),  
     @EmptTypeId int,
     @RelievingDate datetime ,
     @CompanyId int,
     @CreatedDate datetime,
     @ModifiedDate datetime,
     @CreatedEmpID int,
     @ModifiedEmpID int,
	 @WeekOffDays int,
	 @StartTime varchar(15),
	 @EndTime varchar(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @EmpInserted Table (FK_EmpId int NULL,WorkEmail varchar(50) NULL)
	DECLARE @LoginInserted Table (FK_EmpId int NULL,UserName varchar(50) NULL,UserPassword varchar(50) NULL)
	Declare @ReturnVal int
	SET NOCOUNT ON;
	BEGIN TRY
	BEGIN TRANSACTION
    Insert into tblEmployee(
		FirstName,
		LastName,
		EmployeeCode,
		Title,
		FK_DesignationId,
		Manager,
		ProfilePicUrl,
	    QuotesPictureUrl,
	    BackGroundPicUrl,
		HireDate,
		ConfirmationDate,
		WorkEmail,
		OfficeLocation,
		WorkLocation,
		FK_EmptTypeId,
		RelievingDate,
		FK_CompanyId,
		Status,
		CreatedDate,
		ModifiedDate,
		CreatedEmpID,
		ModifiedEmpID,
		WeekOffDays,
		StartTime,
		EndTime
	)
	OUTPUT inserted.EmpId,inserted.WorkEmail INTO @EmpInserted 
	values(
		@FirstName,
		@LastName,
		@EmployeeCode,
		@Title,
		@JobTitle,
		@Manager,
		@ProfilePicUrl,
	    @QuotesPictureUrl,
	    @BackGroundPicUrl,
		@HireDate,
		case when @ConfirmationDate ='1753-01-01 12:00:00 AM' THEN NULL ELSE @ConfirmationDate END ,
		@WorkEmail,
		@OfficeLocation,
		@WorkLocation,
		@EmptTypeId,
		case when @RelievingDate='1753-01-01 12:00:00 AM' then NULL ELSE @RelievingDate END,
		@CompanyId,
		1,
		@CreatedDate,
		@ModifiedDate,
		@CreatedEmpID,
		@ModifiedEmpID,
		@WeekOffDays,
		@StartTime,
		@EndTime
	)
	set @ReturnVal = SCOPE_IDENTITY()
	DECLARE @random varchar(8)

exec [dbo].[UspGenarateRandomString] @random output


	insert into tblLogin
	(
	FK_EmpId,
UserName,
Password,
CreatedDate,
ModifiedDate,
CreatedEmpID,
ModifiedEmpID,
LoginType
	)
	OUTPUT inserted.FK_EmpId,inserted.[UserName],inserted.[Password] INTO @LoginInserted  
	values
	(
	@ReturnVal,
@WorkEmail,
@random,
@CreatedDate,
@ModifiedDate,
@CreatedEmpID,
@ModifiedEmpID,
1
	)	
	
--select WorkEmail from tblEmployee where EmpId=@CreatedEmpID
--select username,password from tblLogin where FK_EmpId=@ReturnVal

--select username,password from tblLogin where FK_EmpId=@ReturnVal

	COMMIT TRANSACTION
	--select a.WorkEmail,b.username,b.password,@ReturnVal as ReturnVal from tblEmployee a, tblLogin b 
	--where a.EmpId=@CreatedEmpID and b.FK_EmpId=@ReturnVal
	SELECT E.WorkEmail,L.UserName,L.UserPassWord as [password],e.FK_EmpId  as ReturnVal     
	FROM @EmpInserted E
	INNER JOIN @LoginInserted L ON L.FK_EmpId=E.FK_EmpId 
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH

END

GO