GO
/****** Object:  Table [dbo].[tblRequestTypes]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRequestTypes](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](100) NULL,
	[GroupId] [int] NULL,
	[DeptId] [int] NULL,
	[FK_CompanyId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NOT NULL,
	[ModifiedEmpID] [int] NOT NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblRequestTypes] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
