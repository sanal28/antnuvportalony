
GO
/****** Object:  Table [dbo].[tblExperience]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblExperience](
	[ExperienceId] [int] IDENTITY(1,1) NOT NULL,
	[FK_EmpId] [int] NOT NULL,
	[CompanyName] [varchar](50) NULL,
	[Desgination] [varchar](50) NULL,
	[TeamSize] [int] NULL,
	[Roles] [varchar](50) NULL,
	[NoOfMonths] [int] NULL,
	[ReasonForLeaving] [varchar](50) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Technologies] [varchar](50) NULL,
	[Domain] [varchar](50) NULL,
	[Attachments] [varchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NOT NULL,
	[ModifiedEmpID] [int] NOT NULL,
 CONSTRAINT [PK_tblExperience] PRIMARY KEY CLUSTERED 
(
	[ExperienceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]