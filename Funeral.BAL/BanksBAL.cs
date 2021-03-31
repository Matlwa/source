using Funeral.DAL;
using Funeral.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.BAL
{
    public class BanksBAL
    {
        public BanksBAL()
        { 
        }

        /// <summary>
        /// Select All Bank
        /// </summary>
        /// <returns></returns>
        public static int SaveBank(BankModel model)
        {
            return BanksDAL.SaveBank(model);
        }

        public static List<BankModel> SelectAll()
        {
            SqlDataReader dr = BanksDAL.SelectAll();
            return FuneralHelper.DataReaderMapToList<BankModel>(dr);
        }
        public static BankModel SelectBankByID(int Id)
        {
            //SqlDataReader dr = MembersDAL.GetMemberByID(ID, ParlourId);
            //return FuneralHelper.DataReaderMapToList<MembersModel>(dr).FirstOrDefault();
            DataTable dr = BanksDAL.SelectBankByIDdt(Id);
            return FuneralHelper.DataTableMapToList<BankModel>(dr).FirstOrDefault();

        }
        public static List<BankModel> SelectLastBank()
        {
            SqlDataReader dr = BanksDAL.SelectLastBank();
            return FuneralHelper.DataReaderMapToList<BankModel>(dr);
        }

        /// <summary>
        /// Account Type Select All
        /// </summary>
        /// <returns></returns>
        public static List<AccountTypeModel> AccountTypeSelectAll()
        {
            SqlDataReader dr = BanksDAL.AccountTypeSelectAll();
            return FuneralHelper.DataReaderMapToList<AccountTypeModel>(dr);
        }


        
    }
}
