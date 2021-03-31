USE [ShortTermCar]
GO

/****** Object:  StoredProcedure [dbo].[DebitOrderMemberSelectAllByPage]    Script Date: 24-Jan-19 3:52:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Faisal
-- Create date: 24-January-2019
-- Description:	Select Members By Id
-- =============================================
CREATE PROCEDURE [dbo].[DebitOrderMemberSelectAllByPage]
@ParlourId uniqueIdentifier='00000000-0000-0000-0000-000000000000',
	@pagesize int=10,
	@pagenum int=1,
	@keyword nvarchar(max)='',
	@field nvarchar(max)='PkiDebitOrdersMemberID',
	@orderby varchar(255)='ASC'
	-- Add the parameters for the stored procedure here
AS
BEGIN

DECLARE @Init int ,@LastRow int, @query nvarchar(4000)
SET NOCOUNT ON;


IF @pagenum <=0  
BEGIN
 SET @pagenum=1
END 

SET @Init=(@pagesize*(@pagenum-1))+1
SET @LastRow=(@pagenum*@pagesize)



SET @query='SELECT * FROM (SELECT top 30 [PkiDebitOrdersMemberID],
			[fkiMemberID],
		   [CreateDate]
           ,[Full Names] as FullNames
           ,[Surname]
           ,[ID Number] as IDNumber
           ,[Date Of Birth] as DateOfBirth
			,[parlourid]
           ,[AccountHolder]
           ,[Bank]
           ,[BranchCode]
           ,[AccountNumber]
           ,[AccountType]
           ,[DebitDate]
	  ,ROW_NUMBER() OVER (ORDER BY [PkiDebitOrdersMemberID] asc) as RowNo
  FROM [dbo].[DebitOrdersMembers]
    WHERE [parlourid]='''+cast(@ParlourId as nvarchar(100))+''' '
  if @keyword !=''
  BEGIN
 SET @query = @query +' AND ( [ID Number] like ''%'+@keyword+'%''
  OR ( [ID Number] like ''%'+@keyword+'%'')
  OR ( [Cellphone] like ''%'+@keyword+'%'')
  OR  [MemeberNumber] like ''%'+@keyword+'%'')'
  END 
 SET @query = @query +' ) TB where TB.[parlourid]='''+cast(@ParlourId as nvarchar(100))+''''

 print @query
  EXECUTE( @query)

select 0 as TotalRecord
END

GO

