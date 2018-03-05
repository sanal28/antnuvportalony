

GO
/****** Object:  Table [dbo].[tblMangersForProjects]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMangersForProjects](
	[MFPId] [int] IDENTITY(1,1) NOT NULL,
	[FK_ProjectId] [int] NULL,
	[FK_Managers] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblMangersForProject] PRIMARY KEY CLUSTERED 
(
	[MFPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]