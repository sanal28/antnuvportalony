

GO
/****** Object:  Table [dbo].[tblProjectContactPerson]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProjectContactPerson](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[FK_ClientId] [int] NULL,
	[ContactPerson] [varchar](50) NULL,
	[ContactNumber] [varchar](50) NULL,
	[Extension] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[Designation] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[Department] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NULL,
	[ModifiedEmpID] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblProjectContactPerson] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]