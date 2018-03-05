/****** Object:  StoredProcedure [dbo].[UspSelectTaskDetails]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspSelectTaskDetails]
	-- Add the parameters for the stored procedure here
	@EmpId int,
	@WeekEnd datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select tskD.*,PrjTsk.TaskName from tblTaskDetails tskD 
	join tblProjectTask PrjTsk on tskD.FK_TaskId=PrjTsk.TaskId
	where tskD.Status=1 and FK_EmpId=@EmpId and 
	cast(WeekEndDate as date)  = cast(@WeekEnd as date) 
END

GO