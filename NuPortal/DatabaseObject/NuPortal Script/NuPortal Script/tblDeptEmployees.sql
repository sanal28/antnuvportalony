
GO
/****** Object:  Table [dbo].[tblDeptEmployees]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDeptEmployees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FK_EmployeeId] [int] NULL,
	[FK_DeptId] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblDeptEmployees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
