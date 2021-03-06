GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 07-Dec-18 4:08:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Statuses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](100) NULL,
	[AssociatedTable] [varchar](200) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Statuses] ON 

INSERT [dbo].[Statuses] ([ID], [Status], [AssociatedTable], [IsActive]) VALUES (1, N'New', N'Claims', 1)
INSERT [dbo].[Statuses] ([ID], [Status], [AssociatedTable], [IsActive]) VALUES (2, N'Supporting Documents missing ', N'Claims', 1)
INSERT [dbo].[Statuses] ([ID], [Status], [AssociatedTable], [IsActive]) VALUES (3, N'Paid', N'Claims', 1)
INSERT [dbo].[Statuses] ([ID], [Status], [AssociatedTable], [IsActive]) VALUES (4, N'Rejected', N'Claims', 1)
INSERT [dbo].[Statuses] ([ID], [Status], [AssociatedTable], [IsActive]) VALUES (5, N'Active', N'Members', 1)
INSERT [dbo].[Statuses] ([ID], [Status], [AssociatedTable], [IsActive]) VALUES (6, N'Cancelled', N'Members', 1)
INSERT [dbo].[Statuses] ([ID], [Status], [AssociatedTable], [IsActive]) VALUES (7, N'Deceased', N'Members', 1)
INSERT [dbo].[Statuses] ([ID], [Status], [AssociatedTable], [IsActive]) VALUES (8, N'Deleted', N'Members', 1)
INSERT [dbo].[Statuses] ([ID], [Status], [AssociatedTable], [IsActive]) VALUES (9, N'Lapsed', N'Members', 1)
INSERT [dbo].[Statuses] ([ID], [Status], [AssociatedTable], [IsActive]) VALUES (10, N'NTU', N'Members', 1)
INSERT [dbo].[Statuses] ([ID], [Status], [AssociatedTable], [IsActive]) VALUES (11, N'On Trial', N'Members', 1)
SET IDENTITY_INSERT [dbo].[Statuses] OFF



