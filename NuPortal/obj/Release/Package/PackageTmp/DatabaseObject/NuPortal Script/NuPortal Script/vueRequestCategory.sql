GO
/****** Object:  View [dbo].[vueRequestCategory]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vueRequestCategory]
as 
select 1 as RequestCategoryId,'Allowance' as TypeName
union
select 2 as RequestCategoryId,'Reimbursement' as TypeName
union
select 3 as RequestCategoryId,'Requests' as TypeName
union
select 4 as RequestCategoryId,'Leave' as TypeName
union
select 5 as RequestCategoryId,'TimeSheet' as TypeName
GO