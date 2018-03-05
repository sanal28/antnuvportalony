

GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[FK_CompanyId] [int] NULL,
	[CategoryName] [varchar](100) NULL,
	[CategoryType] [varchar](100) NULL,
	[CategoryTypeId] [int] NULL,
	[GroupId] [int] NULL,
	[Status] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NOT NULL,
	[ModifiedEmpID] [int] NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]