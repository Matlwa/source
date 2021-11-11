using System;
using Funeral.Model;
using Funeral.DAL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Funeral.BAL
{
    public class DealerDetailsBAL

    {
        public static int SaveDealerDetails(DealerDetailsModel model)
        {
            return DealerDetailsDAL.SaveDealerDetails(model);
        }

        public static void UpdateDealerDetails(DealerDetailsModel model)
        {
            DealerDetailsDAL.SaveDealerDetails(model);
        }
        public static DealersViewModel GetAllDealers(int DealerId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder, string Username)
        {
            DataSet ds = DealerDetailsDAL.GetAllDealers(DealerId, PageSize, PageNum, Keyword, SortBy, SortOrder, Username);
            DataTable dr = ds.Tables[0];
            DealersViewModel objViewModel = new DealersViewModel();
            objViewModel.DealerList = FuneralHelper.DataTableMapToList<DealerDetailsModel>(dr, true);
            objViewModel.TotalRecord = Convert.ToInt64(ds.Tables[1].Rows[0]["TotalRecord"].ToString());

            return objViewModel;
        }

        public static DealersViewModel GetDealersList(string Username)
        {
            DataSet ds = DealerDetailsDAL.GetDealersList(Username);
            DataTable dr = ds.Tables[0];
            DealersViewModel objViewModel = new DealersViewModel();
            objViewModel.DealerList = FuneralHelper.DataTableMapToList<DealerDetailsModel>(dr, true);

            //objViewModel.TotalRecord = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
            return objViewModel;
        }

        public static DealersViewModel GetDailyDealers(string Username, string Date)
        {
            DataSet ds = DealerDetailsDAL.GetDailyDealers(Username, Date);
            DataTable dr = ds.Tables[0];
            DealersViewModel objViewModel = new DealersViewModel();
            objViewModel.DealerList = FuneralHelper.DataTableMapToList<DealerDetailsModel>(dr, true);

            //objViewModel.TotalRecord = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
            return objViewModel;
        }

        //public static DealersViewModel GetDealerTotal(string Username)
        //{
        //   DataSet ds = DealerDetailsDAL.GetDealerTotal(Username);
        //   DataTable dr = ds.Tables[0];
        //   DealersViewModel objViewModel = new DealersViewModel();
        //   objViewModel.DealerList = FuneralHelper.DataTableMapToList<DealerDetailsModel>(dr, true);

        //    //objViewModel.TotalRecord = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
        //   return objViewModel;
        //    //return DealerDetailsDAL.GetDealerTotal(Username);
        //}


        public static DealerDetailsModel GetDealerById(int DealerId)
        {
            DataTable dr = DealerDetailsDAL.GetDealerById(DealerId);
            return FuneralHelper.DataTableMapToList<DealerDetailsModel>(dr).FirstOrDefault();
        }

        public static DealersViewModel SelectDealer(int DealerId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder, string Username)
        {
            DataSet ds = DealerDetailsDAL.SelectDealer(DealerId, PageSize, PageNum, Keyword, SortBy, SortOrder, Username);
            DataTable dr = ds.Tables[0];
            DealersViewModel objViewModel = new DealersViewModel();
            objViewModel.DealerList = FuneralHelper.DataTableMapToList<DealerDetailsModel>(dr, true);
            // objViewModel.TotalRecord = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
            return objViewModel;
        }

        //public static int AddMonthlyQuotes(int DealerId, string Username)
        //{
        //    return DealerDetailsDAL.AddMonthlyQuotes(DealerId, Username);
        //}
    }
}
