/****** Object:  StoredProcedure [dbo].[UspEmployeeProfileCompleted]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[UspEmployeeProfileCompleted]
@Id int 
AS
--Declare @Id int 
--SET @Id=18

DECLARE @NoColumns smallint,@Columnentered smallint,@ProfileCompleted decimal(6,2) 
SET @NoColumns=0; SET @Columnentered=0;SET @ProfileCompleted=0.0;

select @NoColumns=count(1) 
   from INFORMATION_SCHEMA.COLUMNS c where 
  C.TABLE_NAME IN('tblEmployee','tblEmployeeAddress','tblExperience','tblIdentityDetails','tblAcademic','tblCompetency' )
 AND COLUMN_NAME NOT IN ('EmpId','CreatedDate','ModifiedDate','CreatedEmpID','ModifiedEmpID','Status','FK_EmpId','AcademicId','CompetencyId','ExperienceId',
 'IdentityId','FK_EmptTypeId','StartTime','EndTime','EmpAddressID')

 
---tblEmployee 

select @Columnentered= 
case when FirstName IS NOT NULL or len(FirstName)>0 then 1 else 0 end + 
case when LastName  IS NOT NULL or len(LastName)>0 then 1 else 0 end +
case when EmployeeCode  IS NOT NULL or len(EmployeeCode)>0 then 1 else 0 end +
case when Title  IS NOT NULL or len(Title)>0 then 1 else 0 end +
case when FK_DesignationId  IS NOT NULL or len(FK_DesignationId)>0 then 1 else 0 end +
case when Manager  IS NOT NULL or len(Manager)>0 then 1 else 0 end +
case when ProfilePicUrl  IS NOT NULL or len(ProfilePicUrl)>0 then 1 else 0 end +
case when BackGroundPicUrl  IS NOT NULL or len(BackGroundPicUrl)>0 then 1 else 0 end +
case when QuotesPictureUrl  IS NOT NULL or len(QuotesPictureUrl)>0 then 1 else 0 end +
case when ConfirmationDate  IS NOT NULL or len(ConfirmationDate)>0 then 1 else 0 end 
+ case when HireDate   IS NOT NULL or len(HireDate)>0 then 1 else 0 end 
+ case when WorkEmail  IS NOT NULL or len(WorkEmail)>0 then 1 else 0 end +
case when OfficeLocation  IS NOT NULL or len(OfficeLocation)>0 then 1 else 0 end +
case when WorkLocation  IS NOT NULL or len(WorkLocation)>0 then 1 else 0 end +
case when RelievingDate  IS NOT NULL or len(RelievingDate)>0 then 1 else 0 end +
case when FK_CompanyId  IS NOT NULL or len(FK_CompanyId)>0 then 1 else 0 end +
case when WeekOffDays   IS NOT NULL or len(WeekOffDays)>0 then 1 else 0 end 

  from dbo.tblEmployee  where EmpId=@Id
  ---tblEmployeeAddress

  SELECT  @Columnentered= @Columnentered+case  when Address1 IS NOT NULL or len(Address1)>0 then 1 else 0 end + 
case when City1  IS NOT NULL or len(City1)>0 then 1 else 0 end +
case when State1  IS NOT NULL or len(State1)>0 then 1 else 0 end +
case when Country1  IS NOT NULL or len(Country1)>0 then 1 else 0 end +
case when ZipCode1  IS NOT NULL or len(ZipCode1)>0 then 1 else 0 end +
case when Phone1  IS NOT NULL or len(Phone1)>0 then 1 else 0 end +
case when Address2  IS NOT NULL or len(Address2)>0 then 1 else 0 end +
case when City2  IS NOT NULL or len(City2)>0 then 1 else 0 end +
case when State2  IS NOT NULL or len(State2)>0 then 1 else 0 end +
case when Country2  IS NOT NULL or len(Country2)>0 then 1 else 0 end +
case when ZipCode2  IS NOT NULL or len(ZipCode2)>0 then 1 else 0 end +
case when Phone2  IS NOT NULL or len(Phone2)>0 then 1 else 0 end +
case when EmergencyPhone  IS NOT NULL or len(EmergencyPhone)>0 then 1 else 0 end +
case when EmailId  IS NOT NULL or len(EmailId)>0 then 1 else 0 end +
case when DOB  IS NOT NULL or len(DOB)>0 then 1 else 0 end +
case when Gender  IS NOT NULL or len(Gender)>0 then 1 else 0 END
+ case when Nationality  IS NOT NULL or len(Nationality)>0 then 1 else 0 END
+ case when BloodGroup  IS NOT NULL or len(BloodGroup)>0 then 1 else 0 end 
from dbo.tblEmployeeAddress  where FK_EmpId =@Id



--tblExperience

SELECT TOP 1 @Columnentered= @Columnentered+  case when CompanyName IS NOT NULL or len(CompanyName)>0 then 1 else 0 end + 
case when Desgination  IS NOT NULL or len(Desgination)>0 then 1 else 0 end +
case when TeamSize  IS NOT NULL or len(TeamSize)>0 then 1 else 0 end +
case when Roles  IS NOT NULL or len(Roles)>0 then 1 else 0 end +
case when NoOfMonths  IS NOT NULL or len(NoOfMonths)>0 then 1 else 0 end +
case when ReasonForLeaving  IS NOT NULL or len(ReasonForLeaving)>0 then 1 else 0 end +
case when StartDate  IS NOT NULL or len(StartDate)>0 then 1 else 0 end +
case when EndDate  IS NOT NULL or len(EndDate)>0 then 1 else 0 end +
case when Technologies  IS NOT NULL or len(Technologies)>0 then 1 else 0 end +
case when Domain  IS NOT NULL or len(Domain)>0 then 1 else 0 end +
case when Attachments  IS NOT NULL or len(Attachments)>0 then 1 else 0 end 
  from dbo.tblExperience   where [FK_EmpID]  =@Id

  --tblIdentityDetails

 
SELECT TOP 1 @Columnentered= @Columnentered+case when FKIdentityTypeId IS NOT NULL or len(FKIdentityTypeId)>0 then 1 else 0 end + 
case when IdentityNumber  IS NOT NULL or len(IdentityNumber)>0 then 1 else 0 end +
case when Attachments  IS NOT NULL or len(Attachments)>0 then 1 else 0 end 
  from dbo.tblIdentityDetails    where FK_EmpId =@Id


  --tblAcademic
  SELECT TOP 1 @Columnentered= @Columnentered+case when School IS NOT NULL or len(School)>0 then 1 else 0 end + 
case when Course  IS NOT NULL or len(Course)>0 then 1 else 0 end +
case when Major  IS NOT NULL or len(Major)>0 then 1 else 0 end +
case when Minor  IS NOT NULL or len(Minor)>0 then 1 else 0 end +
case when PerMarks  IS NOT NULL or len(PerMarks)>0 then 1 else 0 end +
case when University  IS NOT NULL or len(University)>0 then 1 else 0 end +
case when CourseCompletion  IS NOT NULL or len(CourseCompletion)>0 then 1 else 0 end +
case when YearofPassing  IS NOT NULL or len(YearofPassing)>0 then 1 else 0 end +
case when Grade  IS NOT NULL or len(Grade)>0 then 1 else 0 end 
  from dbo.tblAcademic    where FK_EmpID =@Id
 


  --tblCompetency
    SELECT TOP 1 @Columnentered= @Columnentered+case when CompetencyType IS NOT NULL or len(CompetencyType)>0 then 1 else 0 end + 
case when CompetencyValue  IS NOT NULL or len(CompetencyValue)>0 then 1 else 0 end 
  from dbo.tblCompetency    where FK_Empid =@Id

SET @ProfileCompleted=cast(cast(@Columnentered  as decimal(6,2))/ cast(@NoColumns  as decimal(6,2)) *100 as decimal(6,2)) 
select @ProfileCompleted'ProfileCompleted'--,@Columnentered'Columnentered',@NoColumns'@NoColumns'




GO