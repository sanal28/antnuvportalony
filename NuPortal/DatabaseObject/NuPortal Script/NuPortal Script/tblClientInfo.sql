

GO
/****** Object:  Table [dbo].[tblClientInfo]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblClientInfo](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[FK_CompanyId] [int] NOT NULL,
	[CompanyName] [varchar](50) NULL,
	[Website] [varchar](50) NULL,
	[PurchaseOrderNumber] [varchar](50) NULL,
	[CompanyLogo] [varchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NULL,
	[ModifiedEmpID] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblClientInfo] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
