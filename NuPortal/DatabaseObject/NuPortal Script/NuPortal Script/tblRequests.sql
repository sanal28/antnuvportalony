GO
/****** Object:  Table [dbo].[tblRequests]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRequests](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[RequestType] [int] NULL,
	[RequestText] [varchar](max) NULL,
	[RequestStatusId] [int] NULL,
	[RequestedDate] [datetime] NULL,
	[RequestedToDate] [datetime] NULL,
	[Attachments] [varchar](max) NULL,
	[FK_RespondedBy] [int] NULL,
	[Status] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedEmpID] [int] NOT NULL,
	[ModifiedEmpID] [int] NOT NULL,
 CONSTRAINT [PK_tblRequests] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
