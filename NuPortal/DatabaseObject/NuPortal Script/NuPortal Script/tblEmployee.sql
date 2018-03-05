
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[EmpId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[EmployeeCode] [varchar](30) NULL,
	[Title] [varchar](10) NULL,
	[FK_DesignationId] [int] NULL,
	[Manager] [int] NULL,
	[ProfilePicUrl] [varchar](200) NULL,
	[BackGroundPicUrl] [varchar](200) NULL,
	[QuotesPictureUrl] [varchar](200) NULL,
	[HireDate] [datetime] NULL,
	[ConfirmationDate] [datetime] NULL,
	[WorkEmail] [varchar](50) NULL,
	[OfficeLocation] [int] NULL,
	[WorkLocation] [varchar](50) NULL,
	[FK_EmptTypeId] [int] NULL,
	[RelievingDate] [datetime] NULL,
	[FK_CompanyId] [int] NULL,
	[Status] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NULL,
	[ModifiedEmpID] [int] NULL,
	[WeekOffDays] [int] NULL,
	[StartTime] [varchar](50) NULL,
	[EndTime] [varchar](50) NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
