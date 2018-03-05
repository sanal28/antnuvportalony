GO
/****** Object:  Table [dbo].[tblProjectTask]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProjectTask](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[Fk_ProjectId] [int] NULL,
	[TaskName] [varchar](max) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[PlannedHours] [float] NULL,
	[ProjectPhase] [varchar](max) NULL,
	[Fk_TaskStatusId] [int] NULL,
	[HoursPattern] [varchar](500) NULL,
	[TaskDetails] [varchar](max) NULL,
	[Comments] [varchar](max) NULL,
	[Priority] [int] NULL,
	[Billable] [bit] NULL,
	[Attachments] [varchar](max) NULL,
	[Status] [bit] NULL,
	[TaskCompletedDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NULL,
	[ModifiedEmpID] [int] NULL,
 CONSTRAINT [PK_tblProjectTask] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]