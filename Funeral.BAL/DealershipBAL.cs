using System;
using Funeral.Model;
using Funeral.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Funeral.BAL
{
    public class DealershipBAL
    {
        public static string SaveDealership(DealershipModel model)
        {
            return DealershipDAL.SaveDealership(model);
        }

        public static List<DealershipViewModel> GetAllDealerships(string DealershipName, string LandLine)
        {
            DataTable dr = DealershipDAL.GetAllDealerships(DealershipName, LandLine);
            return FuneralHelper.DataTableMapToList<DealershipViewModel>(dr);
        }

        public static DealershipViewModel SelectAllDealerships(string Username)
        {
            DataSet ds = DealershipDAL.SelectAllDealerships(Username);
            DataTable dr = ds.Tables[0];
            DealershipViewModel objViewModel = new DealershipViewModel();
            objViewModel.DealershipList = FuneralHelper.DataTableMapToList<DealershipModel>(dr, true);
            //objViewModel.TotalRecord = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
            return objViewModel;
        }

        public static DealershipViewModel SelectDealership(int PageSize, int PageNum, string Keyword, string Username)
        {
            DataSet ds = DealershipDAL.SelectDealership(PageSize, PageNum, Keyword, Username);
            DataTable dr = ds.Tables[0];
            DealershipViewModel objViewModel = new DealershipViewModel();
            objViewModel.DealershipList = FuneralHelper.DataTableMapToList<DealershipModel>(dr, true);
            // objViewModel.TotalRecord = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
            return objViewModel;
        }

        public static List<DealershipLookupModel> GetDealershipsDropDown()
        {
            DataTable dr = DealershipDAL.GetDealershipsDropDown();
            return FuneralHelper.DataTableMapToList<DealershipLookupModel>(dr);
        }

        public static string CheckDealershipExists(DealershipModel model)
        {
            return DealershipDAL.CheckDealershipExists(model);
        }
    }
}
