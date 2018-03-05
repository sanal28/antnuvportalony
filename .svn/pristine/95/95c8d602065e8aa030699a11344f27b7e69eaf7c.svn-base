/****** Object:  StoredProcedure [dbo].[UspUpdateEmployeeInfo]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspUpdateEmployeeInfo] 
	-- Add the parameters for the stored procedure here
	 @FK_EmpId int,
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
     @ModifiedDate datetime,
     @ModifiedEmpID int,
	 @WeekOffDays int,
	 @StartTime varchar(15),
	 @EndTime varchar(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @ReturnVal int
	SET @ConfirmationDate=case when @ConfirmationDate ='1753-01-01 12:00:00 AM' THEN NULL ELSE @ConfirmationDate END;
	SET @RelievingDate=case when @RelievingDate ='1753-01-01 12:00:00 AM' THEN NULL ELSE @RelievingDate END;
    -- Insert statements for procedure here
	 Update tblEmployee SET				FirstName=@FirstName,
				LastName=@LastName,
				EmployeeCode=@EmployeeCode,
				Title=@Title,
				FK_DesignationId=@JobTitle,
				Manager=@Manager,
				ProfilePicUrl=@ProfilePicUrl,
				BackGroundPicUrl=@BackGroundPicUrl,
				QuotesPictureUrl=@QuotesPictureUrl,
				HireDate=@HireDate,
				ConfirmationDate=@ConfirmationDate,
				WorkEmail=@WorkEmail,
				OfficeLocation=@OfficeLocation,
				WorkLocation=@WorkLocation,
				FK_EmptTypeId=@EmptTypeId,
				RelievingDate=@RelievingDate,	
				ModifiedDate=@ModifiedDate,
				ModifiedEmpID=@ModifiedEmpID,
				WeekOffDays=@WeekOffDays,
				StartTime=@StartTime,
				EndTime=@EndTime
				 WHERE EmpId=@FK_EmpId
				 select @@ROWCOUNT
END

GO