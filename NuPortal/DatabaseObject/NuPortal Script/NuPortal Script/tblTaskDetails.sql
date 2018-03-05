GO
/****** Object:  Table [dbo].[tblTaskDetails]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTaskDetails](
	[TaskDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[FK_TaskId] [int] NOT NULL,
	[FK_EmpId] [int] NOT NULL,
	[Hour] [float] NULL,
	[IsApproved] [bit] NULL,
	[Date] [datetime] NULL,
	[WeekEndDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblTaskDetails] PRIMARY KEY CLUSTERED 
(
	[TaskDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
