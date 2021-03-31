using Funeral.DAL;
using Funeral.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace Funeral.BAL
{
    public class MembersBAL
    {

        public static int SaveMembers(MembersModel model)
        {
            return MembersDAL.SelectMember(model);
        }

        public static int GetMember(int pkiMemberID )
        {
            return MembersDAL.UpdateMemberByID(pkiMemberID);
        }
        public static string SaveOrderMember(MembersModel model)
        {
            return MembersDAL.SaveOrderMember(model);
        }
        public static int DeleteMember(int ID)
        {
            return MembersDAL.DeleteMember(ID);
        }
        public static int MemberDeleteLogical(int id, string UserName)
        {
            return MembersDAL.MemberDeleteLogical(id, UserName);
        }
        public static MembersModel GetMemberByID(int ID, Guid ParlourId)
        {
            //SqlDataReader dr = MembersDAL.GetMemberByID(ID, ParlourId);
            //return FuneralHelper.DataReaderMapToList<MembersModel>(dr).FirstOrDefault();
            DataTable dr = MembersDAL.GetMemberByIDdt(ID, ParlourId);
            return FuneralHelper.DataTableMapToList<MembersModel>(dr).FirstOrDefault();

        }
        public static MembersModel GetMemberByIDNum(string ID, Guid ParlourId)
        {
            DataTable dr = MembersDAL.GetMemberByIDNumdt(ID, ParlourId);
            return FuneralHelper.DataTableMapToList<MembersModel>(dr).FirstOrDefault();
        }
        public static FamilyDependencyModel GetDependencByIDNum(string ID, Guid ParlourId, int MemberID)
        {
            DataTable dr = MembersDAL.GetDependencByIDNumdt(ID, ParlourId, MemberID);
            return FuneralHelper.DataTableMapToList<FamilyDependencyModel>(dr).FirstOrDefault();
        }

        public static VehiclesModel GetVehicleByVinNo(string VinNo, Guid ParlourId, int MemberID)
        {
            DataTable dr = MembersDAL.GetVehicleByVinNodt(VinNo, ParlourId, MemberID);
            return FuneralHelper.DataTableMapToList<VehiclesModel>(dr).FirstOrDefault();
        }

        public static MembersViewModel GetAllMembers(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder)
        {
            DataSet ds = MembersDAL.GetAllMembersdt(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder);
            DataTable dr = ds.Tables[0];
            MembersViewModel objViewModel = new MembersViewModel();
            objViewModel.MemberList = FuneralHelper.DataTableMapToList<MembersModel>(dr, true);
            objViewModel.TotalRecord = Convert.ToInt64(ds.Tables[1].Rows[0]["TotalRecord"].ToString());
            return objViewModel;
        }
        public static MembersViewModel GetAllDebitOrderMembers(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder)
        {
            DataSet ds = MembersDAL.GetAllDebitMembersdt(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder);
            DataTable dr = ds.Tables[0];
            MembersViewModel objViewModel = new MembersViewModel();
            objViewModel.MemberList = FuneralHelper.DataTableMapToList<MembersModel>(dr, true);
            objViewModel.TotalRecord = Convert.ToInt64(ds.Tables[1].Rows[0]["TotalRecord"].ToString());
            return objViewModel;
        }
        public static List<string> GetDistinctPolicyStatusList()
        {
            DataTable dr = MembersDAL.GetDistinctPolicyStatusListdt();
            return FuneralHelper.DataTableMapToList<string>(dr);
        }
        //public static List<FamilyDependencyModel> GetFamilyDependencyByMemberID(Guid parlourid, int MemberId)
        //{
        //    SqlDataReader dr = MembersDAL.GetFamilyDependencyByMemberID(parlourid, MemberId);
        //    return FuneralHelper.DataReaderMapToList<FamilyDependencyModel>(dr);
        //}

        public static List<VehiclesModel> GetVehicleByMemberID(int fkiMemberId)
        {
            DataTable dr = MembersDAL.GetVehicleByMemberIDdt(fkiMemberId);
            return FuneralHelper.DataTableMapToList<VehiclesModel>(dr);
        }
        public static List<MemberInvoiceModel> GetInvoicesByMemberID(Guid parlourid, int MemberId)
        {
            DataTable dr = MembersDAL.GetInvoicesByMemberIDdt(parlourid, MemberId);
            return FuneralHelper.DataTableMapToList<MemberInvoiceModel>(dr);
        }


        //note save
        public static int NotesSaveMember(MemberNotesModel Notes)
        {
            return MembersDAL.NotesSaveMember(Notes);
        }

        public static List<MemberNotesModel> GetMemberNoteByMemberID(int MemberId)
        {
            DataTable dr = MembersDAL.MemberNotesByMemberIDdt(MemberId);
            return FuneralHelper.DataTableMapToList<MemberNotesModel>(dr);
        }


        //note edit
        public static DataTable MemberNotesBypkiNoteID(int PkInoteID)
        {
            return MembersDAL.MemberNotesBypkiNoteIDdt(PkInoteID);
        }
        public static int UpdateNotesMember(MemberNotesModel Notes)
        {
            return Convert.ToInt32(MembersDAL.NoteUpdateMember(Notes));
        }
        //public static List<SupportedDocument> SelectSupportDocumentsByMemberId(int MemberId)
        //{s
        //    return FuneralHelper.DataReaderMapToList<SupportedDocument>(MembersDAL.SelectSupportDocumentsByMemberId(MemberId));
        //}
        //public static int SaveSupportDocument(SupportedDocument model)
        //{
        //    return MembersDAL.SaveSupportDocument(model);
        //}


        //product

        public static List<AddonProductsModal> SelectProductName(Guid Parlourid)
        {
            DataTable dr = MembersDAL.selectProductNamedt(Parlourid);
            return FuneralHelper.DataTableMapToList<AddonProductsModal>(dr);
        }
        public static int SaveAddonProducts(MemberAddonProductsModel Model)
        {
            return MembersDAL.SaveAddonProducts(Model);
        }

        public static List<MemberAddonProductsModel> SelectMemberAddonProducts(int fkiMemberid)
        {
            DataTable dr = MembersDAL.GetAddonProductsdt(fkiMemberid);
            return FuneralHelper.DataTableMapToList<MemberAddonProductsModel>(dr);
        }
        public static void MemberAddonProductsRemove(Guid pkiMemberProductID)
        {
            MembersDAL.DeleteAddonProduct(pkiMemberProductID);
        }
        public static List<AddonProductsModal> MemberListBindAddonProduct(Guid pkiProductID)
        {
            DataTable dr = MembersDAL.MemberListBinddt(pkiProductID);
            return FuneralHelper.DataTableMapToList<AddonProductsModal>(dr);
        }

        public static List<MemberAddonProductsModel> SelectMembarAddonProductBypkiMemberProductID(Guid PkInoteID)
        {
            //   return MembersDAL.SelectMembarAddonProductBypkiMemberProductID(PkInoteID);
            DataTable dr = MembersDAL.SelectMembarAddonProductBypkiMemberProductIDdt(PkInoteID);
            return FuneralHelper.DataTableMapToList<MemberAddonProductsModel>(dr);
        }
        public static int AddonProductUpdateMember(MemberAddonProductsModel AddonProduct)
        {
            return MembersDAL.AddonProductUpdateMember(AddonProduct);
        }

        /// <summary>
        /// SupportedDocumentModel
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        public static List<SupportedDocumentModel> SelectSupportDocumentsByMemberId(int MemberId)
        {
            return FuneralHelper.DataTableMapToList<SupportedDocumentModel>(MembersDAL.SelectSupportDocumentsByMemberIddt(MemberId));
        }
        public static SupportedDocumentModel SelectSupportDocumentsById(int DocumentId)
        {
            return FuneralHelper.DataTableMapToList<SupportedDocumentModel>(MembersDAL.SelectSupportDocumentsByIddt(DocumentId)).FirstOrDefault();
        }
        public static int SaveSupportDocument(SupportedDocumentModel model)
        {
            return MembersDAL.SaveSupportDocument(model);
        }
        public static double SumOfPremium(int fkiMemberid, Guid ParlourId)
        {
            return MembersDAL.SumOfPremium(fkiMemberid, ParlourId);

        }

        public static List<CountryModel> GetCountry()
        {
            DataTable dr = MembersDAL.GetCountrydt();
            return FuneralHelper.DataTableMapToList<CountryModel>(dr);
        }

        #region FamilyDependency
        public static List<FamilyDependencyTypeModel> GetAllFamilyDependencyTypes()
        {
            return FuneralHelper.DataTableMapToList<FamilyDependencyTypeModel>(MembersDAL.GetFamilyDependencyTypesdt());
        }
        public static List<RelationShipModel> SelectRelationship()
        {
            return FuneralHelper.DataTableMapToList<RelationShipModel>(MembersDAL.SelectRelationshipdt());
        }

        public static int SaveFamilyDependency(FamilyDependencyModel model)
        {
            return MembersDAL.SaveFamilyDependency(model);
        }

        public static int SaveVehicle(VehiclesModel model)
        {
            return MembersDAL.SaveVehicle(model);
        }

        public static int UpdateFamilyDependency(FamilyDependencyModel model)
        {
            return MembersDAL.UpdateFamilyDependency(model);
        }

        public static int UpdateVehicle(VehiclesModel model)
        {
            return MembersDAL.UpdateVehicle(model);
        }

        public static FamilyDependencyModel SelectFamilyDependencyById(int pkiDependentID)
        {
            return FuneralHelper.DataTableMapToList<FamilyDependencyModel>(MembersDAL.SelectFamilyDependencyByIddt(pkiDependentID)).FirstOrDefault();
        }

        public static VehiclesModel SelectVehicleByVehicleId(int pkiVehicleID)
        {
            return FuneralHelper.DataTableMapToList<VehiclesModel>(MembersDAL.SelectVehicleByVehicleIddt(pkiVehicleID)).FirstOrDefault();
        }

        public static DataTable GetFamilyDependencyTypes()
        {
            return DbConnection.GetDataTable(CommandType.StoredProcedure, "GetFamilyDependecyTypes");
        }

        public static bool GetFamilyDependencyTypes(int dependencyId)
        {
            return MembersDAL.DeleteDependentById(dependencyId);
        }
        public static bool DeleteSUpportdocumentById(int DocumentId)
        {
            return MembersDAL.DeleteSUpportdocumentById(DocumentId);
        }
        #endregion
        public static List<AgentModel> SelectAllAgent(Guid ParlourId)
        {
            DataTable dr = MembersDAL.SelectAllAgentdt(ParlourId);
            return FuneralHelper.DataTableMapToList<AgentModel>(dr);
        }

        public static int GetMember(MembersModel model)
        {
            return MembersDAL.GetMember(model);
        }

        public static NewMemberInvoiceModel GetInvoiceByid(int InvoiceId)
        {
            DataTable dr = MembersDAL.GetInvoiceByiddt(InvoiceId);
            return FuneralHelper.DataTableMapToList<NewMemberInvoiceModel>(dr).FirstOrDefault();
        }
        public static DataTable PolicyStatusPieChart(Guid parlourid)
        {
            return MembersDAL.PolicyStatusPieChartdt(parlourid);

        }
        public static List<PolicyPremiumDashboardModel> SelectPolicyPremiumByParlourId(Guid ParlourId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder, bool isAdmin, bool isSuperUser, string UserName)
        {
            DataTable dr = MembersDAL.SelectPolicyPremiumByParlourIddt(ParlourId, PageSize, PageNum, Keyword, SortBy, SortOrder, isAdmin, isSuperUser, UserName);
            return FuneralHelper.DataTableMapToList<PolicyPremiumDashboardModel>(dr);
        }
        public static List<StatusModel> GetStatus(string associatedTable)
        {
            DataTable dr = MembersDAL.GetStatus(associatedTable);
            return FuneralHelper.DataTableMapToList<StatusModel>(dr);
        }

        public static void MemberStatusChangeReason(ChangeStatusReason model)
        {
            MembersDAL.MemberStatusChangeReason(model);
        }

        public static void UpdateMemberStatus(Guid parlourid, int id, string status)
        {
            MembersDAL.UpdateMemberStatus(parlourid, id, status);
        }
    }
}
