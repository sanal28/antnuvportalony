USE [NuPortal]
GO

/****** Object:  StoredProcedure [dbo].[UspGetTimeSheetReport]    Script Date: 09/06/2017 07:15:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspGetTimeSheetReport]
	-- Add the parameters for the stored procedure here
	 @XmlInputString xml,
	 @StartDate datetime = null,
	 @EndDate datetime = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		select td.*,pt.TaskId,pt.TaskName,pts.StatusText,emp.EmpId,emp.FirstName,emp.LastName,emp.ProfilePicUrl,desig.Designation,
		DATENAME(DW,td.Date) as Day,pt.StartDate,pt.EndDate from tblTaskDetails td
		join tblProjectTask pt on td.FK_TaskId=pt.TaskId
		join tblProjectTaskStatus pts on pt.Fk_TaskStatusId=pts.ProjectStatusId
		join tblEmployee emp on td.FK_EmpId = emp.EmpId
		join tblDesignation desig on emp.FK_DesignationId=desig.DesignationId
		cross apply (select M.value('.','int') as val  from @XmlInputString.nodes('/TimeSheet/FK_EmpId') as Ma(M) where M.value('.','int')=td.FK_EmpId  ) as g
		where pt.Fk_TaskStatusId in (2,3) 
		 and StartDate >= case when @startDate is null then StartDate else @StartDate end
		 and EndDate <= case when @EndDate is null then EndDate else @EndDate end 
		 and IsApproved=1 order by pt.StartDate desc
END

GO

