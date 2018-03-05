

GO
/****** Object:  Table [dbo].[tblLogin]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLogin](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[FK_EmpId] [int] NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[LastLoginDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NOT NULL,
	[ModifiedEmpID] [int] NOT NULL,
	[LoginType] [int] NULL,
 CONSTRAINT [PK_tblLogin] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]