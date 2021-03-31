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
    public class ToolsSetingBAL
    {
        public static int UploadApplicationLogo(ApplicationSettingsModel model)
        {
            return ToolsSetingDAL.UploadApplicationLogo(model);
        }
        public static ApplicationSettingsModel SaveApplication(ApplicationSettingsModel model)
        {
           SqlDataReader dr = ToolsSetingDAL.SaveApplication(model);
           return FuneralHelper.DataReaderMapToList<ApplicationSettingsModel>(dr).FirstOrDefault();
        }
        public static AdditionalApplicationSettingsModel SaveAdditionalApplication(AdditionalApplicationSettingsModel model)
        {
            SqlDataReader dr = ToolsSetingDAL.SaveAdditionalApplication(model);
            return FuneralHelper.DataReaderMapToList<AdditionalApplicationSettingsModel>(dr).FirstOrDefault();
        }

        public static AgentInfoSetupModel SaveAgentInfo(AgentInfoSetupModel model)
        {
            SqlDataReader dr = ToolsSetingDAL.SaveAgentInfo(model);
            return FuneralHelper.DataReaderMapToList<AgentInfoSetupModel>(dr).FirstOrDefault();
        }
        public static BankingDetailSending SaveBankingDetail(BankingDetailSending Model)
        {
            SqlDataReader dr = ToolsSetingDAL.SaveBankingDetail(Model);
            return FuneralHelper.DataReaderMapToList<BankingDetailSending>(dr).FirstOrDefault();
        }
        public static ApplicationSettingsModel GetApplictionByParlourID(Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetApplictionByParlourID(ParlourId);
            return FuneralHelper.DataReaderMapToList<ApplicationSettingsModel>(dr).FirstOrDefault();
        }

        public static ApplicationSettingsModel GetApplictionByID(int ID)
        {
            SqlDataReader dr = ToolsSetingDAL.GetApplictionByID(ID);
            return FuneralHelper.DataReaderMapToList<ApplicationSettingsModel>(dr).FirstOrDefault();
        }
        public static BankingDetailSending GetBankingByID(Guid ID)
        {
            SqlDataReader dr = ToolsSetingDAL.GetBankingByID(ID);
            return FuneralHelper.DataReaderMapToList<BankingDetailSending>(dr).FirstOrDefault();
        }
        public static AgentInfoSetupModel GetAgentByID(int ID)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAgentByID(ID);
            return FuneralHelper.DataReaderMapToList<AgentInfoSetupModel>(dr).FirstOrDefault();
        }
        public static SecureUserGroupsModel GetUserAccessByID(int ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetUserAccessByID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<SecureUserGroupsModel>(dr).FirstOrDefault();
        }
        public static List<ApplicationSettingsModel> GetAllCompanys(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAllCompanys(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder);
            return FuneralHelper.DataReaderMapToList<ApplicationSettingsModel>(dr);
        }
        public static List<AgentInfoSetupModel> GetAllAgentInfo(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAllAgentInfo(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder);
            return FuneralHelper.DataReaderMapToList<AgentInfoSetupModel>(dr);
        }
       
        public static int DeleteCompany(int ID)
        {
            return ToolsSetingDAL.DeleteCompany(ID);
        }
        public static int DeleteAgent(int ID)
        {
            return ToolsSetingDAL.DeleteAgent(ID);
        }
        public static List<smsSendingGroupModel> EditsmsGroupbyID(int ID)
        {
            SqlDataReader dr = ToolsSetingDAL.EditsmsGroupbyID(ID);
            return FuneralHelper.DataReaderMapToList<smsSendingGroupModel>(dr);
        }
        public static smsSendingGroupModel GetsmsGroupbyID(int ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetsmsGroupbyID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<smsSendingGroupModel>(dr).FirstOrDefault();
        }
        public static int SaveSmsGroupDetails(smsSendingGroupModel model)
        {
            return ToolsSetingDAL.SaveSmsGroupDetails(model);
        }
        public static List<SecureGroupModel> GetSecureGrouList()
        {
            SqlDataReader dr = ToolsSetingDAL.GetSecureGrouList();
            return FuneralHelper.DataReaderMapToList<SecureGroupModel>(dr);
        }
        public static SecureUsersModel GetUserByID(string ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetUserByID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<SecureUsersModel>(dr).FirstOrDefault();
        }
        public static int SaveUserDetails(SecureUsersModel model)
        {
            return ToolsSetingDAL.SaveUserDetails(model);
        }
        public static int SaveUserGroupDetails(SecureUserGroupsModel model)
        {
            return ToolsSetingDAL.SaveUserGroupDetails(model);
        }
        public static List<SecureUsersModel> GetAllUsers(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAllUsers(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder);
            //MembersViewModel objViewModel = new MembersViewModel();
            return FuneralHelper.DataReaderMapToList<SecureUsersModel>(dr);
            //dr.NextResult();
            //dr.Read();
            //objViewModel.TotalRecord = Convert.ToInt64(dr["TotalRecord"]);
            //return objViewModel;
        }
        public static int DeleteUser(int ID)
        {
            return ToolsSetingDAL.DeleteUser(ID);
        }
        public static SecureUsersModel EditUserbyID(int ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.EditUserbyID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<SecureUsersModel>(dr).FirstOrDefault();
        }
        public static List<SecureUserGroupsModel> EditSecurUserbyID(int ID)
        {
            SqlDataReader dr = ToolsSetingDAL.EditSecurUserbyID(ID);
            return FuneralHelper.DataReaderMapToList<SecureUserGroupsModel>(dr);
        }
        public static BranchModel GetBranchByID(string ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetBranchByID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<BranchModel>(dr).FirstOrDefault();
        }
        public static Guid SaveBranchDetails(BranchModel model)
        {
            return ToolsSetingDAL.SaveBranchDetails(model);
        }
        public static List<BranchModel> GetAllBranches(Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAllBranches(ParlourId);
            return FuneralHelper.DataReaderMapToList<BranchModel>(dr);
        }
        public static BranchModel EditBranchbyID(Guid ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.EditBranchbyID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<BranchModel>(dr).FirstOrDefault();
        }
        public static int DeleteBranch(Guid ID)
        {
            return ToolsSetingDAL.DeleteBranch(ID);
        }
        public static int DeleteBank(Int32 ID)
        {
            return ToolsSetingDAL.DeleteBank(ID);
        }
        public static List<SocietyModel> GetAllSocietyes(Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAllSocietyes(ParlourId);
            return FuneralHelper.DataReaderMapToList<SocietyModel>(dr);
        }
        public static List<SocietyModel> GetAllSocietye(Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAllSocietye(ParlourId);
            return FuneralHelper.DataReaderMapToList<SocietyModel>(dr);
        }
        public static SocietyModel EditSocietybyID(int ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.EditSocietybyID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<SocietyModel>(dr).FirstOrDefault();
        }
        public static SocietyModel GetSocietyByID(string ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetSocietyByID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<SocietyModel>(dr).FirstOrDefault();
        }
        public static int SaveSocietyDetails(SocietyModel model)
        {
            return ToolsSetingDAL.SaveSocietyDetails(model);
        }
        public static int DeleteSociety(int ID)
        {
            return ToolsSetingDAL.DeleteSociety(ID);
        }
        public static List<VendorModel> GetAllVendores(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAllVendores(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder);
            return FuneralHelper.DataReaderMapToList<VendorModel>(dr);
        }
        public static VendorModel EditVendorbyID(int ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.EditVendorbyID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<VendorModel>(dr).FirstOrDefault();
        }
        public static VendorModel GetVendorByID(string ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetVendorByID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<VendorModel>(dr).FirstOrDefault();
        }
        public static int SaveVendorDetails(VendorModel model)
        {
            return ToolsSetingDAL.SaveVendorDetails(model);
        }
        public static int DeleteVendor(int ID)
        {
            return ToolsSetingDAL.DeleteVendor(ID);
        }
        public static List<ExpensesModel> GetAllExpenseses(Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAllExpenseses(ParlourId);
            return FuneralHelper.DataReaderMapToList<ExpensesModel>(dr);
        }
        public static ExpensesModel EditExpensesbyID(int ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.EditExpensesbyID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<ExpensesModel>(dr).FirstOrDefault();
        }
        public static ExpensesModel GetExpensesByID(string ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetExpensesByID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<ExpensesModel>(dr).FirstOrDefault();
        }
        public static int SaveExpensesDetails(ExpensesModel model)
        {
            return ToolsSetingDAL.SaveExpensesDetails(model);
        }
        public static int DeleteExpenses(int ID)
        {
            return ToolsSetingDAL.DeleteExpenses(ID);
        }

        public static AddonProductsModal GetAddonProductByID(string ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAddonProductByID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<AddonProductsModal>(dr).FirstOrDefault();
        }
        public static Guid SaveAddonProductDetails(AddonProductsModal model)
        {
            return ToolsSetingDAL.SaveAddonProductDetails(model);
        }
        public static List<AddonProductsModal> GetAllAddonProductes(Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAllAddonProductes(ParlourId);
            return FuneralHelper.DataReaderMapToList<AddonProductsModal>(dr);
        }
        public static AddonProductsModal EditAddonProductbyID(Guid ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.EditAddonProductbyID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<AddonProductsModal>(dr).FirstOrDefault();
        }
        public static int DeleteAddonProduct(Guid ID)
        {
            return ToolsSetingDAL.DeleteAddonProduct(ID);
        }

        public static List<PlanModel> GetAllPlans(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAllPlans(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder);
            return FuneralHelper.DataReaderMapToList<PlanModel>(dr);
        }
        public static PlanModel EditPlanbyID(int ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.EditPlanbyID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<PlanModel>(dr).FirstOrDefault();
        }
        public static PlanModel GetPlanByID(string ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetPlanByID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<PlanModel>(dr).FirstOrDefault();
        }
        public static int SavePlanDetails(PlanModel model)
        {
            return ToolsSetingDAL.SavePlanDetails(model);
        }
        public static int DeletePlan(int ID)
        {
            return ToolsSetingDAL.DeletePlan(ID);
        }

        public static List<MembersModel> GetAllMemberCellphon(Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAllMemberCellphon(ParlourId);
            return FuneralHelper.DataReaderMapToList<MembersModel>(dr);
        }

        public static List<smsTempletModel> GetTemplateList(Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetTemplateList(ParlourId);
            return FuneralHelper.DataReaderMapToList<smsTempletModel>(dr);
        }
        public static smsTempletModel GetEmailTemplateByID(int ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetEmailTemplateByID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<smsTempletModel>(dr).FirstOrDefault();
        }
        public static int UpdatesmsTemplate(smsTempletModel model)
        {
            return ToolsSetingDAL.UpdatesmsTemplate(model);
        }
        public static int SaveTermsAndCondition(ApplicationTnCModel Model1)
        {
            return ToolsSetingDAL.SaveTermsAndCondition(Model1);
        }
        public static ApplicationTnCModel SelectApplicationTermsAndCondition(Guid parlourid)
        {
            SqlDataReader dr = ToolsSetingDAL.SelectApplicationTermsAndCondition(parlourid);
            return FuneralHelper.DataReaderMapToList<ApplicationTnCModel>(dr).FirstOrDefault();
        }
        public static int UpdateAutoPolicyNo(ApplicationSettingsModel Model1)
        {
            return ToolsSetingDAL.UpdateAutoPolicyNo(Model1);
        }
        public static List<FuneralServiceManageModel> SelectFuneralManageServiceByParlID(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder)
        {
            SqlDataReader dr = ToolsSetingDAL.SelectFuneralManageServiceByParlID(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder);
            return FuneralHelper.DataReaderMapToList<FuneralServiceManageModel>(dr);
        }
        public static int SaveFuneralManageService(FuneralServiceManageModel Model1)
        {
            return ToolsSetingDAL.SaveFuneralManageService(Model1);
        }
        public static FuneralServiceManageModel SelectFuneralManageServiceByParlANdID(int pkiServiceID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.SelectFuneralManageServiceByParlANdID(pkiServiceID, ParlourId);
            return FuneralHelper.DataReaderMapToList<FuneralServiceManageModel>(dr).FirstOrDefault();
        }
        public static int DeleteFuneralManageServiceById(int pkiServiceID)
        {
            return ToolsSetingDAL.DeleteFuneralManageServiceById(pkiServiceID);
        }
        public static List<ApplicationSettingsModel> GetAllApplicationList(Guid parlourid, int param, int AppID)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAllApplicationList(parlourid, param, AppID);
            return FuneralHelper.DataReaderMapToList<ApplicationSettingsModel>(dr);
        }
        public static ApplicationSettingsModel GetAllApplicationList2(Guid parlourid, int param, int AppID)
        {
            SqlDataReader dr = ToolsSetingDAL.GetAllApplicationList(parlourid, param, AppID);
            return FuneralHelper.DataReaderMapToList<ApplicationSettingsModel>(dr).FirstOrDefault();
        }

        public static List<SecureUserGroupsModel> GetSuperUserAccessByID(int ID, Guid ParlourId)
        {
            SqlDataReader dr = ToolsSetingDAL.GetSuperUserAccessByID(ID, ParlourId);
            return FuneralHelper.DataReaderMapToList<SecureUserGroupsModel>(dr);
        }
      
    }
}
