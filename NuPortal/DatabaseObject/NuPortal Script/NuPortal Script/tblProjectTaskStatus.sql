GO
/****** Object:  Table [dbo].[tblProjectTaskStatus]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProjectTaskStatus](
	[ProjectStatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusText] [varchar](50) NULL,
	[FK_CompanyId] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblProjectTaskStatus] PRIMARY KEY CLUSTERED 
(
	[ProjectStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
