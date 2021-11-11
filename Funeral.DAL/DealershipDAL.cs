using System;
using Funeral.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Funeral.DAL
{
    public class DealershipDAL
    {
        public static string SaveDealership(DealershipModel model)
        {
            string query = "SaveDealership";
            DbParameter[] ObjParam = new DbParameter[5];

            ObjParam[0] = new DbParameter("@DealershipId", DbParameter.DbType.Int, 0, model.DealershipId);
            ObjParam[1] = new DbParameter("@DealershipName", DbParameter.DbType.NVarChar, 50, model.DealershipName);
            ObjParam[2] = new DbParameter("@LandLine", DbParameter.DbType.NVarChar, 50, model.LandLine);
            ObjParam[3] = new DbParameter("@ReturnedMessage", DbParameter.DbType.NVarChar, 50, model.ReturnedMessage);
            ObjParam[4] = new DbParameter("@Username", DbParameter.DbType.NVarChar, 50, model.Username);


            //return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, query, ObjParam));
            return Convert.ToString(DbConnection.GetScalarValue(CommandType.StoredProcedure, query, ObjParam));
        }

        public static DataSet SelectAllDealerships(string Username)
        {
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@Username", DbParameter.DbType.NVarChar, 255, Username);
            return DbConnection.GetDataSet(CommandType.StoredProcedure, "SelectAllDealership", ObjParam);
        }


        //GetAllDealerships
        public static DataTable GetAllDealerships(string DealershipName, string LandLine)
        {
            string query = "SelectAllDealership";
            DbParameter[] ObjParam = new DbParameter[2];

            ObjParam[0] = new DbParameter("@DealershipName", DbParameter.DbType.NVarChar, 50, DealershipName);
            ObjParam[1] = new DbParameter("@LandLine", DbParameter.DbType.NVarChar, 50, LandLine);

            return DbConnection.GetDataTable(CommandType.StoredProcedure, query, ObjParam);
        }

        public static DataTable GetDealershipsDropDown()
        {
            string query = "GetDealershipsDropDown";
            return DbConnection.GetDataTable(CommandType.StoredProcedure, query);
        }

        //public static string CheckDealershipExists()
        //{
        //    string query = "SaveDealershipDetails";
        //    return DbConnection.GetDataTable(CommandType.StoredProcedure, query).Rows[0][0].ToString();
        //}
        public static string CheckDealershipExists(DealershipModel model)
        {
            string query = "SaveDealershipDetails";
            return DbConnection.GetDataTable(CommandType.StoredProcedure, query).Rows[0][0].ToString();
        }

        public static DataSet SelectDealership(int PageSize, int PageNum, string Keyword, string Username)
        {
            DbParameter[] ObjParam = new DbParameter[4];

            ObjParam[0] = new DbParameter("@pagesize", DbParameter.DbType.Int, 0, PageSize);
            ObjParam[1] = new DbParameter("@pagenum", DbParameter.DbType.Int, 0, PageNum);
            ObjParam[2] = new DbParameter("@Keyword", DbParameter.DbType.NVarChar, 0, Keyword);
            ObjParam[3] = new DbParameter("@Username", DbParameter.DbType.NVarChar, 0, Username);

            return DbConnection.GetDataSet(CommandType.StoredProcedure, "SelectDealership", ObjParam);
        }
    }
}
