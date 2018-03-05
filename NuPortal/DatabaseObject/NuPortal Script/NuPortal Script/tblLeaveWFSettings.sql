
GO
/****** Object:  Table [dbo].[tblLeaveWFSettings]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLeaveWFSettings](
	[LeaveWFSettingsId] [int] IDENTITY(1,1) NOT NULL,
	[FK_CompanyId] [int] NULL,
	[FK_LeaveTypeId] [int] NULL,
	[CCGroupId] [int] NULL,
	[Status] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NOT NULL,
	[ModifiedEmpID] [int] NULL,
 CONSTRAINT [PK_tblWFSettings] PRIMARY KEY CLUSTERED 
(
	[LeaveWFSettingsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]