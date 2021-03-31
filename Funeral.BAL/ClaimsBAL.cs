using Funeral.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeral.DAL;
using System.Data.SqlClient;

namespace Funeral.BAL
{
    public class ClaimsBAL
    {
        public ClaimsBAL()
        { }

        public static int SaveClaims(ClaimsModel model)
        {
            return ClaimsDAL.SaveClaims(model);
        }
        public static List<ClaimsModel> SelectAllClaimsByParlourId(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder,DateTime DateFrom,DateTime DateTo)
        {
            SqlDataReader dr = ClaimsDAL.SelectAllClaimsByParlourId(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder,DateFrom,DateTo);
            return FuneralHelper.DataReaderMapToList<ClaimsModel>(dr);
        }
        public static int ClaimsDelete(int ID, string UserName)
        {
            return ClaimsDAL.ClaimsDelete(ID, UserName);
        }
        public static ClaimsViewModel SelectAllClaimsBySearch(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder, bool ClaimingForMember, bool ApplyWaitingPeriod)
        {
            SqlDataReader dr = ClaimsDAL.SelectAllClaimsBySearch(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder, ClaimingForMember, ApplyWaitingPeriod);
            ClaimsViewModel objViewModel = new ClaimsViewModel();
            objViewModel.ClaimsList = FuneralHelper.DataReaderMapToList<ClaimsModel>(dr,true);
            dr.NextResult();
            dr.Read();
            objViewModel.TotalRecord = Convert.ToInt64(dr["TotalRecord"]);
            dr.Close();
            dr.Dispose();
            return objViewModel;
        }
        public static List<ClaimsModel> GetClaimsbyMemeberNumber(int MemeberNo)
        {
            SqlDataReader dr = ClaimsDAL.GetClaimsbyMemeberNumber(MemeberNo);
            return FuneralHelper.DataReaderMapToList<ClaimsModel>(dr);
        }
        public static ClaimsModel SelectClaimsBypkid(int ID, Guid ParlourId)
        {
            SqlDataReader dr = ClaimsDAL.SelectClaimsBypkid(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<ClaimsModel>(dr).FirstOrDefault();
        }
        public static int SaveClaimSupportedDocument(ClaimDocumentModel model)
        {
            return ClaimsDAL.SaveClaimSupportedDocument(model);
        }
        public static List<MembersModel> SelectMembersAndDependencies1(Guid ParlourId, bool MainMem, string Keyword)
        {
            SqlDataReader dr = ClaimsDAL.SelectMembersAndDependencies(ParlourId, MainMem, Keyword);
            return FuneralHelper.DataReaderMapToList<MembersModel>(dr);
        }
        public static List<FamilyDependencyModel> SelectMembersAndDependencies2(Guid ParlourId, bool MainMem, string Keyword)
        {
            SqlDataReader dr = ClaimsDAL.SelectMembersAndDependencies(ParlourId, MainMem, Keyword);
            return FuneralHelper.DataReaderMapToList<FamilyDependencyModel>(dr);
        }
        public static MembersModel selectMemberByPkidAndParlor(Guid ParlourId, int MemId)
        {
            SqlDataReader dr = ClaimsDAL.selectMemberByPkidAndParlor(ParlourId, MemId);
            return FuneralHelper.DataReaderMapToList<MembersModel>(dr).FirstOrDefault();
        }
        public static PlanModel GetPlanDetailsByPlanId(int planid)
        {
            SqlDataReader dr = ClaimsDAL.GetPlanDetailsByPlanId(planid);
            return FuneralHelper.DataReaderMapToList<PlanModel>(dr).FirstOrDefault();
        }
        public static int UpdateMemberNumber(int ID, string MemberNumber, string Claimnumber)
        {
            return ClaimsDAL.UpdateMemberNumber(ID, MemberNumber, Claimnumber);
        }
        public static List<ClaimDocumentModel> SelectClaimDocumentsByClaimId(int fkiClaimID)
        {
            SqlDataReader dr = ClaimsDAL.SelectClaimDocumentsByClaimId(fkiClaimID);
            return FuneralHelper.DataReaderMapToList<ClaimDocumentModel>(dr);
        }
        public static int DeleteClaimsdocumentById(int pkiClaimPictureID)
        {
            return ClaimsDAL.DeleteClaimsdocumentById(pkiClaimPictureID);
        }
        public static ClaimDocumentModel SelectClaimsDocumentsByPKId(int DocumentId)
        {
            return FuneralHelper.DataReaderMapToList<ClaimDocumentModel>(ClaimsDAL.SelectClaimsDocumentsByPKId(DocumentId)).FirstOrDefault();
        }
        public static int UpdateClaimStatus(int ID, string status)
        {
            return ClaimsDAL.UpdateClaimStatus(ID, status);
        }
    }
}
