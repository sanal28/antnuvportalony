GO
/****** Object:  Table [dbo].[tblAcademic]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAcademic](
	[AcademicId] [int] IDENTITY(1,1) NOT NULL,
	[FK_EmpID] [int] NOT NULL,
	[School] [varchar](50) NULL,
	[Course] [varchar](50) NULL,
	[Major] [varchar](50) NULL,
	[Minor] [varchar](50) NULL,
	[PerMarks] [float] NULL,
	[University] [varchar](50) NULL,
	[CourseCompletion] [varchar](50) NULL,
	[YearofPassing] [bigint] NULL,
	[Grade] [varchar](10) NULL,
	[Attachments] [varchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NOT NULL,
	[ModifiedEmpID] [int] NOT NULL,
 CONSTRAINT [PK_tblAcademic] PRIMARY KEY CLUSTERED 
(
	[AcademicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]