GO
/****** Object:  Table [dbo].[MemberStatusChangeReason]    Script Date: 07-Dec-18 4:10:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberStatusChangeReason](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ChangeReason] [nvarchar](max) NULL,
	[fkiMemberId] [int] NULL,
	[ParlourID] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[ChangedBy] [int] NULL,
	[CurrentStatus] [nvarchar](100) NULL,
	[NewStatus] [nvarchar](100) NULL,
 CONSTRAINT [PK_MemberStatusChangeReason] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
