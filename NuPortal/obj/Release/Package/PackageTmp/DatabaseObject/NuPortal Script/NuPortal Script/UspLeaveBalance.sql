/****** Object:  StoredProcedure [dbo].[UspLeaveBalance]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---Leave Calculation
CREATE PROCEDURE [dbo].[UspLeaveBalance]
@FK_Companyid int,@EmpId int
AS
declare @TransDate DateTime
set @TransDate = GETDATE()
--DECLARE @FK_Companyid int,@FK_EmpidRequester int,@TransDate DateTime
--SET @FK_Companyid =1
--SET @FK_EmpidRequester=31
--SET @TransDate='2021-12-02 00:00:00.000'

CREATE TABLE #tmpLeaves(FK_EMPID INT,LeaveCount int,LeaveTypeID int)
CREATE TABLE #tmpLeaveConFig(ID INT IDENTITY(1,1), LeaveTypeId INT,[NoOfDays] INT,AdditionalLeavePeriod int)
CREATE TABLE #tmpLeavesApplied(FK_EMPID INT,AppliedLeaveCount int,LeaveTypeID int)
INSERT INTO #tmpLeaveConFig(LeaveTypeId,NoOfDays,AdditionalLeavePeriod)   
SELECT LeaveTypeId,NoOfDays,COALESCE(AdditionalLeavePeriod,0)  FROM DBO.tblLeaveConfig WHERE FK_CompanyId=@FK_Companyid  --AND LeaveTypeId=2

Declare @HireDate Datetime,@NoofMonthsWorked int,@AdditionalLeavePeriod int ,
@LeaverPerMonth int,@joinedYear bit,@CalenderStartDate Datetime,@CasualleaveMonths SMALLint,@ProbationPeriodEndDate datetime ,
@CalenderEndDate Datetime,@casualLeaveStartDate datetime,@CasualLeaveCalculation bit,@LeaveTypeId int 
,@MinId int, @MaxID int,@NoOfDays INT,@cantakeAnytime BIT,@NoOfAdditionalLeave INT,@NoOfMonthsForAdditionalLeave INT

SELECT @HireDate=e.HireDate  from dbo.tblEmployee e where e.EmpId=@EmpId and e.HireDate <=@TransDate 


SELECT @MinId =MIN(ID),@MaxID =MAX(ID) FROM #tmpLeaveConFig
WHILE(@MinId <=@MaxID)
BEGIN
	SELECT @LeaveTypeId=C.LeaveTypeId,@AdditionalLeavePeriod=C.AdditionalLeavePeriod,@NoOfDays=C.NoOfDays 
	
	   FROM #tmpLeaveConFig C 
	WHERE ID=@MinId 
	
	IF YEAR(@HireDate)=Year(@TransDate) SET  @joinedYear =1

	SET @CalenderEndDate=DATEADD(yy, DATEDIFF(yy, 0, @TransDate) + 1, -1);
	SELECT @ProbationPeriodEndDate=DATEADD(M,S.ProbationPeriodInMonths ,@HireDate),@cantakeAnytime=S.CanTakeAnyTime,
	@NoOfAdditionalLeave=S.NoOfAdditionalLeave ,@NoOfMonthsForAdditionalLeave =NoOfMonthsForAdditionalLeave 
	     FROM dbo.tblLeavesettings S 	
	WHERE S.FK_LeaveTypeId =@LeaveTypeId -- cantakeAnytime=0 AND
	
	--SELECT @HireDate'@HireDate',@ProbationPeriodEndDate'@ProbationPeriodEndDate',@LeaveTypeId'@LeaveTypeId',@cantakeAnytime'@cantakeAnytime'
	IF @joinedYear=1
	BEGIN
		SET @CalenderStartDate=@HireDate
		SET @CasualleaveMonths=DATEDIFF(m,@ProbationPeriodEndDate, @TransDate) 
	END
	ELSE
		SET @CalenderStartDate=DATEADD(yy, DATEDIFF(yy, 0, @TransDate), 0)

	IF YEAR(@ProbationPeriodEndDate)=year(@HireDate) AND YEAR(@ProbationPeriodEndDate)=YEAR(@TransDate)
	SET @casualLeaveStartDate=@ProbationPeriodEndDate
	
	IF YEAR(@ProbationPeriodEndDate)=year(@HireDate) AND YEAR(@ProbationPeriodEndDate)<YEAR(@TransDate)
	SET @casualLeaveStartDate=@CalenderStartDate 
			
	IF YEAR(@ProbationPeriodEndDate)=year(@HireDate) AND YEAR(@ProbationPeriodEndDate) = YEAR(DATEADD(YY,1,@HireDate))
	SET @casualLeaveStartDate=@ProbationPeriodEndDate
	
	--SELECT @casualLeaveStartDate'@casualLeaveStartDate',@ProbationPeriodEndDate'@ProbationPeriodEndDate',@HireDate'@HireDate',@TransDate 'TransDate',@CalenderStartDate'@CalenderStartDate'

	IF @TransDate>DATEADD(YY,1,@HireDate)
	SET @casualLeaveStartDate=@CalenderStartDate

	SET @NoofMonthsWorked=DATEDIFF(m,@HireDate, @TransDate)	
	
	
	IF YEAR(@ProbationPeriodEndDate) =YEAR(@TransDate)
	SET @CasualleaveMonths=CASE WHEN @casualLeaveStartDate>@TransDate THEN 0  ELSE DATEDIFF(M,@casualLeaveStartDate,@TransDate )+1 END
	IF YEAR(@ProbationPeriodEndDate) <YEAR(@TransDate)
	SET @CasualleaveMonths= DATEPART(MM,@TransDate )

	--SELECT @NoofMonthsWorked '@NoofMonthsWorked ',@AdditionalLeavePeriod'@AdditionalLeavePeriod',@CasualleaveMonths'@CasualleaveMonths'
	if @NoofMonthsWorked > @AdditionalLeavePeriod AND @AdditionalLeavePeriod>0
	begin
		SET @CasualleaveMonths=@CasualleaveMonths+ (@CasualleaveMonths /@NoOfMonthsForAdditionalLeave * @NoOfAdditionalLeave)
	end
	--SELECT @NoofMonthsWorked'@NoofMonthsWorked',@TransDate'@TransDate', @ProbationPeriodEndDate'@ProbationPeriodEndDate',@AdditionalLeavePeriod'@AdditionalLeavePeriod',
	--@LeaveTypeId'@LeaveTypeId',@HireDate 'HireDate',@CasualleaveMonths'@CasualleaveMonths'

	IF @AdditionalLeavePeriod>0 AND EXISTS(SELECT 1 FROM dbo.tblLeaveSettings S WHERE S.FK_LeaveTypeId=@LeaveTypeId AND S.CanTakeAnyTime =0)
	INSERT INTO #tmpLeaves(FK_EMPID ,LeaveCount,LeaveTypeID) VALUES(@EmpId,@CasualleaveMonths,@LeaveTypeId)									
	--IF @AdditionalLeavePeriod=0 
	IF @TransDate< @ProbationPeriodEndDate AND @AdditionalLeavePeriod=0
	BEGIN
		INSERT INTO #tmpLeaves(FK_EMPID ,LeaveCount,LeaveTypeID) 
		SELECT DISTINCT @EmpId,S.LeavePerMonth ,@LeaveTypeId
		FROM DBO.tblLeaveSettings S WHERE S.FK_LeaveTypeId=@LeaveTypeId AND @NoofMonthsWorked BETWEEN S.PeriodFrom AND S.PeriodTo --AND S.CanTakeAnyTime =0
	END

	IF @TransDate> @ProbationPeriodEndDate AND @AdditionalLeavePeriod=0
	INSERT INTO #tmpLeaves(FK_EMPID ,LeaveCount,LeaveTypeID) SELECT DISTINCT @EmpId,S.LeavePerMonth ,@LeaveTypeId
	FROM DBO.tblLeaveSettings S WHERE S.FK_LeaveTypeId=@LeaveTypeId AND @NoofMonthsWorked BETWEEN S.PeriodFrom AND S.PeriodTo --AND S.CanTakeAnyTime =1
	

	INSERT INTO #tmpLeavesApplied(FK_EMPID,AppliedLeaveCount,LeaveTypeID) 
	SELECT FK_EmpIdRequester,[LeaveAppliedDays],FK_LeaveTypeId  FROM [dbo].[tblLeaveTransaction] WHERE [FK_EmpIdRequester]=@EmpId 
	AND [FK_StatusId] = 2 AND FK_EmpId=@EmpId
	AND [FK_LeaveTypeId] = @LeaveTypeId  AND LeaveStartDate >= @CalenderStartDate AND LeaveEndDate <= @CalenderEndDate 

	SET @MinId=@MinId+1
END  


SELECT L.*,COALESCE(A.AppliedLeaveCount,0) AppliedLeaveCount
,CASE WHEN L.LeaveCount-COALESCE(A.AppliedLeaveCount,0)<0 THEN 0 ELSE L.LeaveCount-COALESCE(A.AppliedLeaveCount,0) end AS Balance
  FROM #tmpLeaves L
LEFT OUTER JOIN #tmpLeavesApplied A ON A.LeaveTypeID=L.LeaveTypeID  


DROP TABLE  #tmpLeaveConFig
DROP TABLE #tmpLeaves
DROP TABLE #tmpLeavesApplied


GO