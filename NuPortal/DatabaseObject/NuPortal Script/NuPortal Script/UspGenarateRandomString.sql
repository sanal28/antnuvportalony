/****** Object:  StoredProcedure [dbo].[UspGenarateRandomString]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspGenarateRandomString](@OUTMESSAGE VARCHAR(10) OUTPUT)  
AS   
BEGIN  
SET NOCOUNT ON  
declare @LENGTH INT,@CharPool varchar(26),@PoolLength varchar(26),@LoopCount  INT  
DECLARE @RandomString VARCHAR(10),@CHARPOOLINT VARCHAR(9)  
  
    
SET @CharPool = 'A!B@C!D#E@FG#H$IJ$K%LM%N*PQR%ST&U*V(W)X_YZ'  
DECLARE @TMPSTR VARCHAR(3)  

SET @PoolLength = DataLength(@CharPool)  
SET @LoopCount = 0  
SET @RandomString = ''  
  
    WHILE (@LoopCount <10)  
    BEGIN  
        SET @TMPSTR =   SUBSTRING(@Charpool, CONVERT(int, RAND() * @PoolLength), 1)           
        SELECT @RandomString  = @RandomString + CONVERT(VARCHAR(5), CONVERT(INT, RAND() * 10))  
        IF(DATALENGTH(@TMPSTR) > 0)  
        BEGIN   
            SELECT @RandomString = @RandomString + @TMPSTR    
            SELECT @LoopCount = @LoopCount + 1  
        END  
    END  
    SET @LOOPCOUNT = 0    
    SET @OUTMESSAGE=@RandomString  
END  

GO