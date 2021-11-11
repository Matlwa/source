using Funeral.Model;
using Funeral.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Funeral.DAL
{
    public class DealerDetailsDAL
    {
        public static int SaveDealerDetails(DealerDetailsModel model)
        {
            DbParameter[] ObjParam = new DbParameter[14];
            ObjParam[0] = new DbParameter("@DealershipId", DbParameter.DbType.Int, 0, model.DealershipId);
            ObjParam[1] = new DbParameter("@DealerTypeId", DbParameter.DbType.Int, 0, model.DealerTypeId);
            ObjParam[2] = new DbParameter("@StatusTypeId", DbParameter.DbType.Int, 0, model.StatusTypeId);
            ObjParam[3] = new DbParameter("@Name", DbParameter.DbType.NVarChar, 0, model.Name);
            ObjParam[4] = new DbParameter("@Surname", DbParameter.DbType.NVarChar, 0, model.Surname);
            ObjParam[5] = new DbParameter("@Landline", DbParameter.DbType.NVarChar, 0, model.Landline);
            ObjParam[6] = new DbParameter("@CellphoneNumber", DbParameter.DbType.NVarChar, 0, model.CellphoneNumber);
            ObjParam[7] = new DbParameter("@Email", DbParameter.DbType.NVarChar, 0, model.Email);
            ObjParam[8] = new DbParameter("@DealershipName", DbParameter.DbType.NVarChar, 0, model.DealershipName);
            ObjParam[9] = new DbParameter("@DealerType", DbParameter.DbType.NVarChar, 0, model.DealerType);
            ObjParam[10] = new DbParameter("@Comment", DbParameter.DbType.NVarChar, 0, model.Comment);
            ObjParam[11] = new DbParameter("@Status", DbParameter.DbType.NVarChar, 0, model.Status);
            ObjParam[12] = new DbParameter("@Province", DbParameter.DbType.NVarChar, 0, model.Province);
            //ObjParam[13] = new DbParameter("@AvailabilityStatus", DbParameter.DbType.NVarChar, 0, model.AvailabilityStatus);
            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, "SaveDealerDetails", ObjParam));
        }

        public static DataSet GetAllDealers(int DealerId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder, string Username)
        {
            DbParameter[] ObjParam = new DbParameter[7];

            ObjParam[0] = new DbParameter("@DealerId", DbParameter.DbType.Int, 0, DealerId);
            //ObjParam[0] = new DbParameter("@Name", DbParameter.DbType.NVarChar, 0, Name);
            ObjParam[1] = new DbParameter("@pagesize", DbParameter.DbType.Int, 0, PageSize);
            ObjParam[2] = new DbParameter("@pagenum", DbParameter.DbType.Int, 0, PageNum);
            ObjParam[3] = new DbParameter("@Keyword", DbParameter.DbType.NVarChar, 0, Keyword);
            ObjParam[4] = new DbParameter("@field", DbParameter.DbType.NVarChar, 0, SortBy);
            ObjParam[5] = new DbParameter("@orderby", DbParameter.DbType.NVarChar, 0, SortOrder);
            ObjParam[6] = new DbParameter("@Username", DbParameter.DbType.NVarChar, 0, Username);

            return DbConnection.GetDataSet(CommandType.StoredProcedure, "GetAllDealers", ObjParam);
        }

        //Trace from here
        public static DataSet GetDealersList(string Username)
        {
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@Username", DbParameter.DbType.NVarChar, 255, Username);
            return DbConnection.GetDataSet(CommandType.StoredProcedure, "GetDealersList", ObjParam);
        }

        public static DataSet GetDailyDealers(string Username, string Date)
        {
            DbParameter[] ObjParam = new DbParameter[2];
            ObjParam[0] = new DbParameter("@Username", DbParameter.DbType.NVarChar, 255, Username);
            ObjParam[1] = new DbParameter("@Date", DbParameter.DbType.NVarChar, 255, Date);
            return DbConnection.GetDataSet(CommandType.StoredProcedure, "GetDailyDealers", ObjParam);
        }
        //public static DataSet GetDealerTotal(string Username)
        //{
        //    DbParameter[] ObjParam = new DbParameter[2];
        //    ObjParam[0] = new DbParameter("@Username", DbParameter.DbType.NVarChar, 255, Username);
        //    return DbConnection.GetDataSet(CommandType.StoredProcedure, "GetDealerTotal", ObjParam);
        //    //return Convert.ToString(DbConnection.GetScalarValue(CommandType.StoredProcedure, "GetDealerTotal", ObjParam));
        //}



        public static DataTable GetDealerById(int DealerId)
        {
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@DealerId", DbParameter.DbType.Int, 0, DealerId);
            // ObjParam[1] = new DbParameter("@Username", DbParameter.DbType.NVarChar, 0, User);
            //ObjParam[1] = new DbParameter("@Name", DbParameter.DbType.NVarChar, 0, Name);
            return DbConnection.GetDataTable(CommandType.StoredProcedure, "GetDealerById", ObjParam);
        }

        public static DataTable GetDealerByName(string Name)
        {
            DbParameter[] ObjParam = new DbParameter[0];
            ObjParam[0] = new DbParameter("@Name", DbParameter.DbType.Int, 0, Name);
            return DbConnection.GetDataTable(CommandType.StoredProcedure, "GetDealer", ObjParam);
        }
        public static DataSet GetAllDealersList(string Username)
        {
            string query = "GetDealersList";
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@Username", DbParameter.DbType.NVarChar, 0, Username);
            //UserName
            return DbConnection.GetDataSet(CommandType.StoredProcedure, query);
        }


        public static DataSet SelectDealer(int DealerId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder, string Username)
        {
            DbParameter[] ObjParam = new DbParameter[7];

            ObjParam[0] = new DbParameter("@DealerId", DbParameter.DbType.Int, 0, DealerId);
            ObjParam[1] = new DbParameter("@pagesize", DbParameter.DbType.Int, 0, PageSize);
            ObjParam[2] = new DbParameter("@pagenum", DbParameter.DbType.Int, 0, PageNum);
            ObjParam[3] = new DbParameter("@Keyword", DbParameter.DbType.NVarChar, 0, Keyword);
            ObjParam[4] = new DbParameter("@field", DbParameter.DbType.NVarChar, 0, SortBy);
            ObjParam[5] = new DbParameter("@orderby", DbParameter.DbType.NVarChar, 0, SortOrder);
            ObjParam[6] = new DbParameter("@Username", DbParameter.DbType.NVarChar, 0, Username);

            return DbConnection.GetDataSet(CommandType.StoredProcedure, "SelectDealer", ObjParam);
        }

        public static int AddMonthlyQuotes(int DealerId, string Username)
        {
            string query = "AddMonthlyQuotes";
            DbParameter[] ObjParam = new DbParameter[2];
            ObjParam[0] = new DbParameter("@DealerId", DbParameter.DbType.Int, 0, DealerId);
            ObjParam[1] = new DbParameter("@Username", DbParameter.DbType.NVarChar, 0, Username);
            //UserName
            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, query));
        }

    }
}
