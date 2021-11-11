using Funeral.Model;
using Funeral.BAL;
using Funeral.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Funeral.BAL
{
    public class DealerBAL
    {
        public static int SaveDealerDetails(DealerDetailsModel model)
        {
            return DealerDetailsDAL.SaveDealerDetails(model);
        }
        public static string SaveDealer(DealerModel model)
        {
            return DealerDAL.SaveDealer(model);
        }
        public static DealerModel GetDealerById(int DealerId)
        {
            DataTable dr = DealerDAL.GetDealerById(DealerId);
            return FuneralHelper.DataTableMapToList<DealerModel>(dr).FirstOrDefault();
        }
        public static string UpdateDealerDetails(DealerModel model)
        {
            return DealerDAL.UpdateDealerDetails(model);
        }
        //public static DealerModel GetAllDealers(int DealerId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder)
        //{
        //    return DealerDAL.GetAllDealers();
        //}

        //public static DataSet GetAllStatus(int StatusTypeId, string Status)
        //{
        //    return DealerDAL.GetAllStatus(StatusTypeId,Status);
        //}

        //11 july change
        public static List<DealerStatusTypeModel> GetAllDealerStatus(int StatusTypeId, string Status)
        {
            DataTable dr = DealerDAL.GetAllDealerStatus(StatusTypeId, Status);
            return FuneralHelper.DataTableMapToList<DealerStatusTypeModel>(dr);
        }

        public static List<ProvinceViewModel> GetAllProvinces(int ProvinceId, string Province)
        {
            DataTable dr = DealerDAL.GetAllProvinces(ProvinceId, Province);
            return FuneralHelper.DataTableMapToList<ProvinceViewModel>(dr);
        }

        public static DataSet GetAllDealers(int DealerId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder, string Username)
        {
            return DealerDAL.GetAllDealers(DealerId, PageSize, PageNum, Keyword, SortBy, SortOrder, Username);
        }

        public static List<DealerStatusTypeModel> GetAllDealerType(int DealerTypeId, string DealerType)
        {
            DataTable dr = DealerDAL.GetAllDealerStatus(DealerTypeId, DealerType);
            return FuneralHelper.DataTableMapToList<DealerStatusTypeModel>(dr);
        }

        public static List<DealerTypeLookupModel> GetDealerTypeLookup()
        {
            DataTable dr = DealerDAL.GetDealerTypeLookup();
            return FuneralHelper.DataTableMapToList<DealerTypeLookupModel>(dr);
        }

        public static List<StatusTypeLookupModel> GetStatusTypeLookup()
        {
            DataTable dr = DealerDAL.GetStatusTypeLookup();
            return FuneralHelper.DataTableMapToList<StatusTypeLookupModel>(dr);
        }

        public static List<DealershipLookupModel> GetDealershipsDropDown()
        {
            DataTable dr = DealerDAL.GetDealershipsDropDown();
            return FuneralHelper.DataTableMapToList<DealershipLookupModel>(dr);
        }

        public static List<ProvinceLookpmodel> GetProvinceDropDown()
        {
            DataTable dr = DealerDAL.GetProvinceDropDown();
            return FuneralHelper.DataTableMapToList<ProvinceLookpmodel>(dr);
        }

        public static List<DealerModel> CheckDealerExist()
        {
            DataTable dr = DealerDAL.DealerExistCheck();
            return FuneralHelper.DataTableMapToList<DealerModel>(dr);
        }

        public static DataSet GetDealerId(int DealerId)
        {
            return DealerDAL.GetDealerId(DealerId);
        }

        public static string GetDealerTotal(/*string Total,*/ string username)
        {
            return DealerTotal.GetDealerTotal(/*Total,*/ username);
        }

        //public static string GetDealerTotal(DealerModel model)
        //{
        //    return DealerTotal.GetDealerTotal(model);
        //}
        public static List<DealerCommunicationStatusTypeModel> GetDealerCommunicationStatuses()
        {
            DataTable dr = DealerDAL.DealerCommStatusDropDown();
            return FuneralHelper.DataTableMapToList<DealerCommunicationStatusTypeModel>(dr);
        }

    }
}
