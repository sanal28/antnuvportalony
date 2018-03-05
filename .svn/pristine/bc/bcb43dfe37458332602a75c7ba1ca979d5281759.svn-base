

GO
/****** Object:  Table [dbo].[tblLeaveConfig]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLeaveConfig](
	[LeaveTypeId] [int] IDENTITY(1,1) NOT NULL,
	[LeaveName] [varchar](100) NULL,
	[FK_CompanyId] [int] NULL,
	[NoOfDays] [int] NULL,
	[Status] [bit] NULL,
	[AdditionalLeavePeriod] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NULL,
	[ModifiedEmpID] [int] NULL,
 CONSTRAINT [PK_tblLeaveConfig] PRIMARY KEY CLUSTERED 
(
	[LeaveTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]