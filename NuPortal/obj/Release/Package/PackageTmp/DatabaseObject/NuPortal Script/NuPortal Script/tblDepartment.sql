

GO
/****** Object:  Table [dbo].[tblDepartment]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDepartment](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[FK_CompanyId] [int] NOT NULL,
	[DepartmentName] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblDepartment] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
