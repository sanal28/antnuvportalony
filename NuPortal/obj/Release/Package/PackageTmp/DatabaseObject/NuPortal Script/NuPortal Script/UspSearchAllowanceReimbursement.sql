/****** Object:  StoredProcedure [dbo].[UspSearchAllowanceReimbursement]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <2017-05-27>
-- Description:	<@CategoryTypeId=1 Allowance,@CategoryTypeId=2 Reimbursement>
-- =============================================
CREATE PROC [dbo].[UspSearchAllowanceReimbursement]
@Category varchar(50),@amount float,@DATE DATETIME,
@TicketStatus VARCHAR(50),@Description VARCHAR(MAX),@EndDate DATETIME,
@CategoryTypeId tinyint
As
IF @CategoryTypeId=1 
BEGIN
	SELECT A.* FROM dbo.tblAllowance A
	INNER JOIN dbo.tblCategory C ON C.CategoryId=A.FK_CategoryId 
	WHERE C.CategoryName=CASE WHEN @Category IS NULL THEN C.CategoryName ELSE @Category END
	AND A.Amount = CASE WHEN  @amount is null THEN a.Amount ELSE @amount END
	AND A.[Date]=CASE WHEN @DATE IS NULL THEN A.[Date] ELSE @DATE END
	AND A.TicketStatusId =CASE WHEN @TicketStatus IS NULL THEN A.TicketStatusId ELSE @TicketStatus END 
	AND A.[Description]  =CASE WHEN @Description IS NULL THEN A.[Description] ELSE @Description END 
END
IF @CategoryTypeId=2
BEGIN
	SELECT A.* FROM dbo.tblReimbursement A
	INNER JOIN dbo.tblCategory C ON C.CategoryId=A.FK_CategoryId 
	WHERE C.CategoryName=CASE WHEN @Category IS NULL THEN C.CategoryName ELSE @Category END
	AND A.Amount = CASE WHEN  @amount is null THEN a.Amount ELSE @amount END
	AND A.StartDate=CASE WHEN @DATE IS NULL THEN A.StartDate ELSE @DATE END
	AND A.EndDate=CASE WHEN @DATE IS NULL THEN A.EndDate ELSE @EndDate END
	AND A.TicketStatusId =CASE WHEN @TicketStatus IS NULL THEN A.TicketStatusId ELSE @TicketStatus END 
	AND A.[Description]  =CASE WHEN @Description IS NULL THEN A.[Description] ELSE @Description END 
	AND A.EndDate =CASE WHEN  @EndDate IS NULL THEN A.EndDate ELSE @EndDate END
END
GO