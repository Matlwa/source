
GO
/****** Object:  StoredProcedure [dbo].[UpdateMemberStatus]    Script Date: 07-Dec-18 3:56:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UpdateMemberStatus]
	-- Add the parameters for the stored procedure here
	@memberId int,
@status varchar(100),
@parlourId uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update Members set PolicyStatus=@status where pkiMemberID=@memberId and parlourid=@parlourId
END

--============================================================Statuses For Member===================================
GO
/****** Object:  StoredProcedure [dbo].[StatusSelectByAssociatedTable]    Script Date: 07-Dec-18 3:57:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[StatusSelectByAssociatedTable]
	-- Add the parameters for the stored procedure here
	@AssociatedTable varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * From Statuses where AssociatedTable=@AssociatedTable and IsActive=1
Order by [Status]	
END

