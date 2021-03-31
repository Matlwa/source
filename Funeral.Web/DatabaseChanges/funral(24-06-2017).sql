GO
DROP TABLE [dbo].[tblPages]
Go
GO
/****** Object:  Table [dbo].[tblPages]    Script Date: 24-06-2017 6.50.19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PageName] [nvarchar](100) NULL,
	[PageTitle] [nvarchar](100) NULL,
	[URL] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsExcludedRight] [bit] NULL,
	[ParentRoleId] [int] NULL,
	[IconClass] [nvarchar](100) NULL,
	[MenuOrder] [int] NULL,
	[MenuLevel] [int] NULL,
	[IsMenu] [bit] NULL,
 CONSTRAINT [PK_tblPages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tblPages] ON 

GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (1, N'Car Track', N'Car Track', N'/Admin/CarTrack.aspx', 1, 0, 0, N'fa  fa-car', 10, 0, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (2, N'Member', N'Member', N'#', 1, 0, 0, N'fa  fa-home', 2, 0, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (3, N'New Member', N'New Member', N'/Admin/ManageMember.aspx', 1, 0, 2, N'', 1, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (4, N'Find Member', N'Find Member', N'/Admin/Members.aspx', 1, 0, 2, N'', 2, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (5, N'Payments', N'Payments', N'#', 1, 0, 0, N'fa fa-money', 3, 0, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (6, N'Policy payments', N'Policy payments', N'/Admin/MemberPayment.aspx', 1, 0, 5, N'', 1, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (7, N'Group payments', N'Group payments', N'/Admin/GroupPayment.aspx', 1, 0, 5, N'', 2, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (8, N'Reports', N'Reports', N'/Admin/Reports/Reports.aspx', 1, 0, 0, N'fa  fa-car', 4, 0, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (9, N'Quotation', N'Quotation', N'/Admin/Qoutation.aspx', 1, 0, 0, N'fa fa-calculator', 5, 0, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (10, N'Funeral', N'Funeral', N'/Admin/Funeral.aspx', 1, 0, 0, N'', 6, 0, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (11, N'Tombstones', N'Tombstones', N'/Admin/Tombstone.aspx', 1, 0, 0, N'glyphicon glyphicon-king', 7, 0, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (12, N'Claims', N'Claims', N'/Admin/Claims.aspx', 1, 0, 0, N'fa fa-file-zip-o', 8, 0, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (13, N'Tools', N'Tools', N'#', 1, 0, 0, N'fa  fa-cogs', 11, 0, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (14, N'AddonProduct Setup', N'AddonProduct Setup', N'/Tools/AddonProductSetup.aspx', 1, 0, 13, N'', 1, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (15, N'Branch Setup', N'Branch Setup', N'/Tools/BranchSetup.aspx', 1, 0, 13, N'', 2, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (16, N'Company Setup', N'Company Setup', N'/Tools/CompanySetup.aspx', 1, 0, 13, N'', 3, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (17, N'Agent Setup', N'Agent Setup', N'/Tools/AgentInfoSetup.aspx', 1, 0, 13, N'', 4, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (18, N'Expenses Category Setup', N'Expenses Category Setup', N'Tools/ExpensesCategorySetup.aspx', 1, 0, 13, N'', 5, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (19, N'Plan Setup', N'Plan Setup', N'/Tools/PlanSetup.aspx', 1, 0, 13, N'', 6, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (20, N'Society Setup', N'Society Setup', N'/Tools/SocietySetup.aspx', 1, 0, 13, N'', 7, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (21, N'User Setup', N'User Setup', N'/Tools/UserSetup.aspx', 1, 0, 13, N'', 8, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (22, N'Vendor Setup', N'Vendor Setup', N'/Tools/VendorSetup.aspx', 1, 0, 13, N'', 9, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (23, N'SMS Sending', N'SMS Sending', N'/Tools/smsSendingSetup.aspx', 1, 0, 13, N'', 10, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (24, N'SMS Templete Setup', N'SMS Templete Setup', N'/Tools/smsTempletSetup.aspx', 1, 0, 13, N'', 11, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (25, N'Funeral Services', N'Funeral Services', N'/Tools/FuneralServices.aspx', 1, 0, 13, N'', 12, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (26, N'Funeral Package', N'Funeral Package', N'/Tools/FuneralPackage.aspx', 1, 0, 13, N'', 13, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (27, N'Tombstone Package', N'Tombstone Package', N'/Tools/TombstonePackage.aspx', 1, 0, 13, N'', 14, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (28, N'Custom Details', N'Custom Details', N'/Tools/CustomManagement.aspx', 1, 0, 13, N'', 15, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (29, N'Manage Rights', N'Manage Rights', N'/Tools/Rights.aspx', 1, 0, 13, N'', 16, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (30, N'Other Payments', N'Other Payments', N'/Admin/OtherPayments.aspx', 1, 0, 5, N'', 3, 1, 1)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (31, N'Deshboard', N'Deshboard', N'NULL/Admin/Funeral.aspx', 1, 0, 0, N'fa fa-th-large', 0, 0, 0)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (32, N'FuneralPayment', N'FuneralPayment', N'/Admin/FuneralPayment.aspx', 1, 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (33, N'Funeral Services Select', N'Funeral Services Select', N'/Admin/FuneralServicesSelect.aspx', 1, 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (34, N'Manage Member', N'Manage Member', N'/Admin/ManageMember.aspx', 1, 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (35, N'Manage Members Payment', N'Manage Members Payment', N'/Admin/ManageMembersPayment.aspx', 1, 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (36, N'Print Quotation,Funral,Tombston', N'PrintForm', N'/Admin/PrintForm.aspx', 1, 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (37, N'Print Payment Receipt', N'PrintPaymentReceipt', N'/Admin/PrintPaymentReceipt.aspx', 1, 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (38, N'Quotation Services', N'QuotationServices', N'/Admin/QuotationServices.aspx', 1, 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (39, N'Tombstone Payment', N'TombstonePayment', N'/Admin/TombstonePayment.aspx', 1, 0, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[tblPages] ([ID], [PageName], [PageTitle], [URL], [IsActive], [IsExcludedRight], [ParentRoleId], [IconClass], [MenuOrder], [MenuLevel], [IsMenu]) VALUES (40, N'TombStone Service Select', N'TombStoneServiceSelect', N'/Admin/TombStoneServiceSelect', 1, 0, NULL, NULL, NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[tblPages] OFF
GO

GO
/****** Object:  StoredProcedure [dbo].[LoadSideMenu]    Script Date: 24-06-2017 6.50.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[LoadSideMenu]
	@ParlourId Uniqueidentifier,
	@UserId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	if EXISTS (select fkiSecureGroupID from [dbo].[SecureUserGroups] where fkiSecureUserID=@UserId and fkiSecureGroupID in (4,12))
	begin 
		select 
			tp.ID,
			tp.PageName,
			tp.PageTitle,
			tp.URL,
			tp.IsActive,
			tp.IsExcludedRight,
			tp.ParentRoleId,
			tp.IconClass,
			tp.MenuOrder,
			tp.MenuLevel,
			tp.IsMenu
		 from [dbo].[tblPages] tp
		 Where tp.IsActive = 1
		-- and tp.IsMenu=1
		 order by tp.MenuOrder
	end
	 
	Else
	begin
		select 
			tp.ID,
			tp.PageName,
			tp.PageTitle,
			tp.URL,
			tp.IsActive,
			tp.IsExcludedRight,
			tp.ParentRoleId,
			tp.IconClass,
			tp.MenuOrder,
			tp.MenuLevel,
			tp.IsMenu,
			tr.GroupId,
			tr.HasAccess,
			tr.IsRead,
			tr.IsWrite,
			tr.IsDelete,
			tr.IsUpdate
		from [dbo].[tblPages] tp
		left join [dbo].[tblRights] tr on tr.PageId=tp.ID
		Where tp.IsActive = 1
		--and tp.IsMenu=1
		and tr.HasAccess = 1
		and tr.ParlourId=@ParlourId
		and tr.GroupId in (select fkiSecureGroupID from [dbo].[SecureUserGroups] where fkiSecureUserID=@UserId)
		order by tp.MenuOrder
		
	end
END