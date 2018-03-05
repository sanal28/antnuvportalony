GO
/****** Object:  StoredProcedure [dbo].[UspDeleteTaskDetails]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspDeleteTaskDetails]
	-- Add the parameters for the stored procedure here
	@deleteXml XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

		delete TD
		from tblTaskDetails TD
		INNER JOIN (select M.value('.','int') as TaskID  from @deleteXml.nodes('/TimeSheet/TaskId') as Ma(M)) XmlD on
		TD.TaskDetailsId =XmlD.TaskID 
		select @@ROWCOUNT;
END

GO