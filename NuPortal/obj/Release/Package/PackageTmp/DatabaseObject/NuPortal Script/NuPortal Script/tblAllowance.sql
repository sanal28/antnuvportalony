

GO
/****** Object:  Table [dbo].[tblAllowance]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAllowance](
	[AllowanceId] [int] IDENTITY(1,1) NOT NULL,
	[FK_CategoryId] [int] NULL,
	[Date] [datetime] NULL,
	[Amount] [float] NULL,
	[Description] [varchar](max) NULL,
	[Attachments] [varchar](max) NULL,
	[TicketStatusId] [int] NULL,
	[FK_RespondedBy] [int] NULL,
	[Status] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NOT NULL,
	[ModifiedEmpID] [int] NULL,
 CONSTRAINT [PK_tblAllowance] PRIMARY KEY CLUSTERED 
(
	[AllowanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]