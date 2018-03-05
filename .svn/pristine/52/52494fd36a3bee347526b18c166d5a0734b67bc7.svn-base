

GO
/****** Object:  Table [dbo].[tblClientAddress]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblClientAddress](
	[ClientAddressId] [int] IDENTITY(1,1) NOT NULL,
	[FK_ClientId] [nchar](10) NULL,
	[AddressType] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[Zip] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
 CONSTRAINT [PK_tblClientAddress] PRIMARY KEY CLUSTERED 
(
	[ClientAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]