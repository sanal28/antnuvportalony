
GO
/****** Object:  Table [dbo].[tblEmpType]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmpType](
	[EmpTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NULL,
	[FK_CompanyId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NOT NULL,
	[ModifiedEmpID] [int] NOT NULL,
 CONSTRAINT [PK_tblEmpType] PRIMARY KEY CLUSTERED 
(
	[EmpTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
