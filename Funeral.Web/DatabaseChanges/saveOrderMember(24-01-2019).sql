USE [ShortTermCar]
GO

/****** Object:  StoredProcedure [dbo].[SaveOrderMember]    Script Date: 24-Jan-19 4:47:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SaveOrderMember]
	-- Add the parameters for the stored procedure here
	--Tab 1 Data
	@surname nvarchar(255),
	@FullNames nvarchar(255),
	@IDNumber nvarchar(255),
	@DateOfBirth  datetime,	
	@AccountHolder nvarchar(255),
	@Bank nvarchar(255),
	@BranchCode nvarchar(255),
	@AccountNumber nvarchar(255),
	@Accounttype nvarchar(255),
	@DebitDate  datetime=null,
	@parlourid uniqueidentifier,
	@Passport nvarchar(255)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @PkiDebitOrdersMemberID INT
	DECLARE @lpkiMemberID INT
    -- Insert statements for procedure here
	BEGIN	

	INSERT INTO [dbo].[Members]
           ([Full Names]
           ,[Surname]
           ,[ID Number]
           ,[Date Of Birth]
		   ,[fkiPlanID]
           ,[parlourid]
           ,[AccountHolder]
           ,[Bank]
           ,[BranchCode]
           ,[AccountNumber]
           ,[AccountType]
           ,[DebitDate]
		   ,[Passport]
		   )
     VALUES
			(@FullNames
           ,@surname
           ,@IDNumber
		   ,@DateOfBirth
		   ,NULL
		   ,@parlourid
           ,@AccountHolder
           ,@Bank
			,@BranchCode
           ,@AccountNumber
           ,@AccountType
           ,@DebitDate
		   ,@Passport
		   )
		  set @lpkiMemberID=( Select SCOPE_IDENTITY() as ID)

		INSERT INTO [dbo].[DebitOrdersMembers]
           ([fkiMemberID],
		   [CreateDate]
           ,[Full Names]
           ,[Surname]
           ,[ID Number]
		   ,[parlourid]
           ,[Date Of Birth]
           ,[AccountHolder]
           ,[Bank]
           ,[BranchCode]
           ,[AccountNumber]
           ,[AccountType]
           ,[DebitDate])
     VALUES
			(@lpkiMemberID,
			GETDATE()
           ,@FullNames
           ,@surname
           ,@IDNumber
			,@parlourid
			,@DateOfBirth
           ,@AccountHolder
           ,@Bank
			,@BranchCode
           ,@AccountNumber
           ,@AccountType
           ,@DebitDate)
		  set @PkiDebitOrdersMemberID=( Select SCOPE_IDENTITY() as ID)	
		  	 
  END	
END
GO

