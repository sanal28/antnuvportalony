
GO
/****** Object:  Table [dbo].[tblEmploymentType]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmploymentType](
	[EmptTypeId] [int] IDENTITY(1,1) NOT NULL,
	[EmploymentType] [varchar](50) NULL,
	[Status] [bit] NULL,
	[FK_CompanyId] [int] NULL,
 CONSTRAINT [PK_tblEmploymentType] PRIMARY KEY CLUSTERED 
(
	[EmptTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
