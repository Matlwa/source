using Funeral.DAL;
using Funeral.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.BAL
{
    public class CommonBAL
    {
        public static List<PolicyModel> GetPolicyByParlourId(Guid parlourid)
        {
            SqlDataReader dr = MembersDAL.GetPolicyByParlourId(parlourid);
            return FuneralHelper.DataReaderMapToList<PolicyModel>(dr);
        }

        public static List<SocietyModel> GetSocietyByParlourId(Guid parlourid)
        {
            SqlDataReader dr = MembersDAL.GetSocietyByParlourId(parlourid);
            return FuneralHelper.DataReaderMapToList<SocietyModel>(dr);
        }
        public static List<SocietyModel> GetAllSociety(Guid parlourid)
        {
            SqlDataReader dr = MembersDAL.GetAllSociety(parlourid);
            return FuneralHelper.DataReaderMapToList<SocietyModel>(dr);
        }
        public static List<BranchModel> GetBranchByParlourId(Guid parlourid)
        {
            SqlDataReader dr = MembersDAL.GetBranchByParlourId(parlourid);
            return FuneralHelper.DataReaderMapToList<BranchModel>(dr);
        }
        public static List<BranchModel> GetAllBranch(Guid Parlourid)
        {
            SqlDataReader dr = MembersDAL.GetAllBranch(Parlourid);
            return FuneralHelper.DataReaderMapToList<BranchModel>(dr);
        }
        public static List<PlanModel> GetAllPlanName(Guid ParlourId)
        {
            SqlDataReader dr = MembersDAL.GetAllPlanName(ParlourId);
            return FuneralHelper.DataReaderMapToList<PlanModel>(dr);
        }
        public static List<PolicyModel> GetPlanSubscriptionByPlanId(int pkiPlanID)
        {
            SqlDataReader dr = MembersDAL.GetPlanSubscriptionByPlanId(pkiPlanID);
            return FuneralHelper.DataReaderMapToList<PolicyModel>(dr);
        }
        public static int GetWaitingPeriodByPlanId(int pkiPlanID)
        {
            SqlDataReader dr = MembersDAL.GetWaitingPeriodByPlanId(pkiPlanID);
            if (dr != null && dr.HasRows)
            {
                dr.Read();
                return Convert.ToInt32(dr["WaitingPeriod"].ToString());
            }
            else return 0;
        }

        
        public static string GetPlanUnderwriterByPlanId(int pkiPlanID)
        {
            SqlDataReader dr = MembersDAL.GetPlanUnderwriterByPlanId(pkiPlanID);
            if (dr != null && dr.HasRows)
            {
                dr.Read();
                return dr["PlanUnderWriter"].ToString();
            }
            else return string.Empty;
        }
        public static string GetMemberNumber(Guid ParlourId)
        {
            SqlDataReader dr = MembersDAL.GetMemberNumber(ParlourId);
            if (dr != null && dr.HasRows)
            {
                dr.Read();
                return dr["MemberNo"].ToString();
            }
            else return string.Empty;
        }
    }
}
