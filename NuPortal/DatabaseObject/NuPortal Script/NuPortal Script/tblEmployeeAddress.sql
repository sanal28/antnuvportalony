
GO
/****** Object:  Table [dbo].[tblEmployeeAddress]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployeeAddress](
	[EmpAddressID] [int] IDENTITY(1,1) NOT NULL,
	[FK_EmpId] [int] NOT NULL,
	[Address1] [varchar](50) NULL,
	[City1] [varchar](50) NULL,
	[State1] [varchar](50) NULL,
	[Country1] [varchar](50) NULL,
	[ZipCode1] [varchar](50) NULL,
	[Phone1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[City2] [varchar](50) NULL,
	[State2] [varchar](50) NULL,
	[Country2] [varchar](50) NULL,
	[ZipCode2] [varchar](50) NULL,
	[Phone2] [varchar](50) NULL,
	[EmergencyPhone] [varchar](50) NULL,
	[EmailId] [varchar](50) NULL,
	[DOB] [datetime] NULL,
	[Gender] [varchar](10) NULL,
	[Nationality] [varchar](50) NULL,
	[BloodGroup] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NOT NULL,
	[ModifiedEmpID] [int] NOT NULL,
 CONSTRAINT [PK_tblEmployeeAddress] PRIMARY KEY CLUSTERED 
(
	[FK_EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]