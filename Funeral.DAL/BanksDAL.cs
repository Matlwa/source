using Funeral.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.DAL
{
    public class BanksDAL
    {
        public BanksDAL()
        {
        }

        /// <summary>
        /// Select All Bank
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader SelectAll()
        {
            return DbConnection.GetDataReader(CommandType.StoredProcedure, "BanksSelectAll");
        }
        public static SqlDataReader SelectLastBank()
        {
            return DbConnection.GetDataReader(CommandType.StoredProcedure, "GetLastBank");
        }
        public static SqlDataReader SelectBankByID(int id)
        {
            
            DbParameter[] objParam = new DbParameter[1];
            objParam[0] = new DbParameter("@BankId", DbParameter.DbType.NVarChar, 0, id);
            return DbConnection.GetDataReader(CommandType.StoredProcedure, "GetBankByID",objParam);
        }
        public static DataTable SelectBankByIDdt(int Id)
        {
            DbParameter[] objParam = new DbParameter[1];
            objParam[0] = new DbParameter("@BankId", DbParameter.DbType.NVarChar, 0,Id);
            return DbConnection.GetDataTable(CommandType.StoredProcedure, "GetBankByID", objParam);
            
        }

        public static int SaveBank(BankModel model)
        {
            string query = "SaveBanks";
            DbParameter[] ObjParam = new DbParameter[2];
            ObjParam[0] = new DbParameter("@BankName", DbParameter.DbType.NVarChar, 0, model.BankName);
            ObjParam[1] = new DbParameter("@BranchCode", DbParameter.DbType.NVarChar, 0,model.BranchCode);
           
            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, query, ObjParam));

       
        }
        public static SqlDataReader AccountTypeSelectAll()
        {
            return DbConnection.GetDataReader(CommandType.StoredProcedure, "AccoutnTypeSelectAll");
        }
    }
}
