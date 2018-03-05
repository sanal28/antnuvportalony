
GO
/****** Object:  Table [dbo].[tblLeaveTransaction]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLeaveTransaction](
	[LeaveTransId] [int] IDENTITY(1,1) NOT NULL,
	[FK_EmpId] [int] NULL,
	[FK_EmpIdRequester] [int] NULL,
	[FK_EmpAssignedTo] [int] NULL,
	[LeaveStartDate] [datetime] NULL,
	[LeaveEndDate] [datetime] NULL,
	[FK_LeaveTypeId] [int] NULL,
	[FK_LeaveSettingsId] [int] NULL,
	[FK_StatusId] [int] NULL,
	[FK_LeaveTransId] [int] NULL,
	[FK_RespondedBy] [int] NULL,
	[Reason] [varchar](max) NULL,
	[LeaveAppliedDays] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NOT NULL,
	[ModifiedEmpID] [int] NULL,
 CONSTRAINT [PK_tblLeaveTransaction] PRIMARY KEY CLUSTERED 
(
	[LeaveTransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
