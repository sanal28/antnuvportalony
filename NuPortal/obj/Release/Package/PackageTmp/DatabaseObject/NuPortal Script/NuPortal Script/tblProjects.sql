GO
/****** Object:  Table [dbo].[tblProjects]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProjects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[FK_CompanyId] [int] NULL,
	[FK_ClientId] [int] NULL,
	[FK_ContactId] [int] NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](max) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[URL] [varchar](50) NULL,
	[Priority] [varchar](50) NULL,
	[ProjectStatus] [varchar](50) NULL,
	[ProjectType] [varchar](50) NULL,
	[ProjectCategory] [varchar](50) NULL,
	[PlannedHours] [int] NULL,
	[FK_Department] [int] NULL,
	[CostCenter] [varchar](50) NULL,
	[Technologies] [varchar](max) NULL,
	[Attachments] [varchar](max) NULL,
	[Status] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NULL,
	[ModifiedEmpID] [int] NULL,
 CONSTRAINT [PK_tblProjects] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
