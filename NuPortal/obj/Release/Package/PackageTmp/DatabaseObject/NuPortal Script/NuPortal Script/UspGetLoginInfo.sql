USE [NuPortal]
GO

/****** Object:  StoredProcedure [dbo].[UspGetLoginInfo]    Script Date: 09/06/2017 07:16:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Snowlin Jose
-- Create date: 04-05-2017
-- Description:	Login information 
-- =============================================
CREATE PROCEDURE [dbo].[UspGetLoginInfo]
	-- Add the parameters for the stored procedure here
	 @UserName VARCHAR(20),  
     @Password varchar(20),
	 @Operation  int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	-- 0 'User Does not Exists'
	-- 1 'Success'
	-- 2 'Incorrect Password'
  if @Operation=1
  begin
     IF EXISTS(SELECT * FROM [dbo].[tblLogin] WHERE UserName = @UserName)  

		BEGIN  

		IF EXISTS(SELECT * FROM tblLogin WHERE UserName = @UserName AND Password  = @Password COLLATE SQL_Latin1_General_CP1_CS_AS) 
		 
			BEGIN
				SELECT 1 AS UserExists, LoginType ,FK_EmpId FROM tblLogin 
				WHERE UserName = @UserName AND 
				Password  = @Password COLLATE SQL_Latin1_General_CP1_CS_AS

				Update [dbo].[tblLogin] set LastLoginDate=GETDATE()  
				WHERE UserName = @UserName  
			END
		ELSE
			SELECT 2 AS UserExists
		END
	ELSE
		SELECT 0 AS UserExists
	end

	--Forgot Password
	if @Operation = 2
	begin
	select top 1 Password from tblLogin where UserName=@UserName
	end
END

GO

