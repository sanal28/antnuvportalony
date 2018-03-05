
GO
/****** Object:  Table [dbo].[tblCompany]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCompany](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](100) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[FK_CountryId] [int] NULL,
	[Zip] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[TimeOffset] [varchar](10) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NOT NULL,
	[ModifiedEmpID] [int] NOT NULL,
 CONSTRAINT [PK_tblCompany] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
