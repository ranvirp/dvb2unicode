USE [lrc]
GO
/****** Object:  UserDefinedFunction [dbo].[conv2unicode]    Script Date: 12/5/2014 9:39:16 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create FUNCTION [dbo].[conv2unicode](@x [nvarchar](200))
RETURNS [nvarchar](200) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [dvb2unicode].[UserDefinedFunctions].[Dvb2unicode]