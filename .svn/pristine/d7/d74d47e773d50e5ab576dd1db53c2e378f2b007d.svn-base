GO
/****** Object:  Table [dbo].[tblProjectDocument]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProjectDocument](
	[DocumentId] [int] IDENTITY(1,1) NOT NULL,
	[FK_ProjectId] [int] NULL,
	[DocumentName] [varchar](50) NULL,
	[FK_SharedTypeId] [int] NULL,
	[FK_RoleId] [int] NULL,
	[Description] [varchar](max) NULL,
	[Attachments] [varchar](max) NULL,
	[Status] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NULL,
	[ModifiedEmpID] [int] NULL,
 CONSTRAINT [PK_tblProjectDocument] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
