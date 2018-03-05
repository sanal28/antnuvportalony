GO
/****** Object:  Table [dbo].[tblResourcesForProjects]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblResourcesForProjects](
	[RFPId] [int] IDENTITY(1,1) NOT NULL,
	[FK_ProjectId] [int] NULL,
	[FK_Resources] [int] NULL,
	[FK_RoleId] [int] NULL,
	[RatePerHour] [float] NULL,
	[Allocation] [int] NULL,
	[BillingStatus] [bit] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblResourcesForProjects] PRIMARY KEY CLUSTERED 
(
	[RFPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
