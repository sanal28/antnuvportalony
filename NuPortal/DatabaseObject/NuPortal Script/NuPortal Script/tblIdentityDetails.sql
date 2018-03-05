

GO
/****** Object:  Table [dbo].[tblIdentityDetails]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblIdentityDetails](
	[IdentityId] [int] IDENTITY(1,1) NOT NULL,
	[FK_EmpId] [int] NOT NULL,
	[FKIdentityTypeId] [int] NOT NULL,
	[IdentityNumber] [varchar](50) NULL,
	[Attachments] [varchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NOT NULL,
	[ModifiedEmpID] [int] NOT NULL,
 CONSTRAINT [PK_tblIdentityDetails] PRIMARY KEY CLUSTERED 
(
	[IdentityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]