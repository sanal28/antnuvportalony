

GO
/****** Object:  Table [dbo].[tblLeaveSettings]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLeaveSettings](
	[LeaveSettingId] [int] IDENTITY(1,1) NOT NULL,
	[FK_LeaveTypeId] [int] NULL,
	[FK_CompanyId] [int] NULL,
	[LeaveEffectDate] [datetime] NULL,
	[PeriodFrom] [int] NULL,
	[PeriodTo] [int] NULL,
	[ProbationPeriodInMonths] [int] NULL,
	[LeavePerMonth] [int] NULL,
	[CanTakeAnyTime] [bit] NOT NULL,
	[NoOfMonthsForAdditionalLeave] [int] NULL,
	[NoOfAdditionalLeave] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NULL,
	[ModifiedEmpID] [int] NULL,
 CONSTRAINT [PK_tblLeaveSettings] PRIMARY KEY CLUSTERED 
(
	[LeaveSettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
