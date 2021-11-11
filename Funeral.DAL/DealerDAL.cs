using System;
using Funeral.Model;
using Funeral.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Funeral.DAL
{
    public class DealerDAL
    {
        public static string SaveDealer(DealerModel model)
        {
            string query = "SaveDealer";
            DbParameter[] ObjParam = new DbParameter[13];

            ObjParam[0] = new DbParameter("@DealerId", DbParameter.DbType.Int, 0, model.DealerId);
            //ObjParam[1] = new DbParameter("@DealershipId", DbParameter.DbType.Int, 0, model.DealershipId);
            //ObjParam[2] = new DbParameter("@DealerTypeId", DbParameter.DbType.Int, 0, model.DealerTypeId);
            //ObjParam[3] = new DbParameter("@StatusTypeId", DbParameter.DbType.Int, 0, model.StatusTypeId);
            ObjParam[1] = new DbParameter("@Name", DbParameter.DbType.NVarChar, 0, model.Name);
            ObjParam[2] = new DbParameter("@Surname", DbParameter.DbType.NVarChar, 0, model.Surname);
            ObjParam[3] = new DbParameter("@Landline", DbParameter.DbType.NVarChar, 0, model.Landline);
            ObjParam[4] = new DbParameter("@CellphoneNumber", DbParameter.DbType.NVarChar, 0, model.CellphoneNumber);
            ObjParam[5] = new DbParameter("@Email", DbParameter.DbType.NVarChar, 0, model.Email);
            ObjParam[6] = new DbParameter("@DealershipName", DbParameter.DbType.NVarChar, 0, model.DealershipName);
            ObjParam[7] = new DbParameter("@DealerType", DbParameter.DbType.NVarChar, 0, model.DealerType);
            ObjParam[8] = new DbParameter("@Comment", DbParameter.DbType.NVarChar, 0, model.Comment);
            ObjParam[9] = new DbParameter("@Status", DbParameter.DbType.NVarChar, 0, model.Status);
            ObjParam[10] = new DbParameter("@Province", DbParameter.DbType.NVarChar, 0, model.Province);
            ObjParam[11] = new DbParameter("@username", DbParameter.DbType.NVarChar, 0, model.UserName);
            ObjParam[12] = new DbParameter("@ReturnedMessage", DbParameter.DbType.NVarChar, 0, model.ReturnedMessage);
            // return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, query, ObjParam));
            return Convert.ToString(DbConnection.GetScalarValue(CommandType.StoredProcedure, query, ObjParam));
        }

        public static string UpdateDealerDetails(DealerModel model)
        {
            string query = "SaveDealerDetails";
            DbParameter[] ObjParam = new DbParameter[14];

            ObjParam[0] = new DbParameter("@DealerId", DbParameter.DbType.Int, 0, model.DealerId);
            //ObjParam[1] = new DbParameter("@DealershipId", DbParameter.DbType.Int, 0, model.DealershipId);
            //ObjParam[2] = new DbParameter("@DealerTypeId", DbParameter.DbType.Int, 0, model.DealerTypeId);
            //ObjParam[3] = new DbParameter("@StatusTypeId", DbParameter.DbType.Int, 0, model.StatusTypeId);
            ObjParam[1] = new DbParameter("@Name", DbParameter.DbType.NVarChar, 0, model.Name);
            ObjParam[2] = new DbParameter("@Surname", DbParameter.DbType.NVarChar, 0, model.Surname);
            ObjParam[3] = new DbParameter("@Landline", DbParameter.DbType.NVarChar, 0, model.Landline);
            ObjParam[4] = new DbParameter("@CellphoneNumber", DbParameter.DbType.NVarChar, 0, model.CellphoneNumber);
            ObjParam[5] = new DbParameter("@Email", DbParameter.DbType.NVarChar, 0, model.Email);
            ObjParam[6] = new DbParameter("@DealershipName", DbParameter.DbType.NVarChar, 0, model.DealershipName);
            ObjParam[7] = new DbParameter("@DealerType", DbParameter.DbType.NVarChar, 0, model.DealerType);
            ObjParam[8] = new DbParameter("@Comment", DbParameter.DbType.NVarChar, 0, model.Comment);
            ObjParam[9] = new DbParameter("@Status", DbParameter.DbType.NVarChar, 0, model.Status);
            ObjParam[10] = new DbParameter("@Province", DbParameter.DbType.NVarChar, 0, model.Province);
            ObjParam[11] = new DbParameter("@username", DbParameter.DbType.NVarChar, 0, model.UserName);
            ObjParam[12] = new DbParameter("@ReturnedMessage", DbParameter.DbType.NVarChar, 0, model.ReturnedMessage);
            ObjParam[13] = new DbParameter("@CommunicationStatus", DbParameter.DbType.NVarChar, 255, model.CommunicationStatus);

            return Convert.ToString(DbConnection.GetScalarValue(CommandType.StoredProcedure, query, ObjParam));
        }


        public static int GetDealer(DealerModel model)
        {
            DealerModel addDealer = new DealerModel();
            string query = "GetDealer";
            DbParameter[] ObjParam = new DbParameter[10];

            ObjParam[0] = new DbParameter("@Names", DbParameter.DbType.NVarChar, 0, model.Name);
            ObjParam[1] = new DbParameter("@Surname", DbParameter.DbType.NVarChar, 0, model.Surname);
            ObjParam[2] = new DbParameter("@Landline", DbParameter.DbType.NVarChar, 0, model.Landline);
            ObjParam[3] = new DbParameter("@CellphoneNumber", DbParameter.DbType.NVarChar, 0, model.CellphoneNumber);
            ObjParam[4] = new DbParameter("@Email", DbParameter.DbType.NVarChar, 0, model.Email);
            ObjParam[5] = new DbParameter("@DealershipName", DbParameter.DbType.NVarChar, 0, model.DealershipName);
            ObjParam[6] = new DbParameter("@DealerType", DbParameter.DbType.NVarChar, 0, model.DealerType);
            ObjParam[7] = new DbParameter("@Status", DbParameter.DbType.NVarChar, 0, model.Status);
            ObjParam[8] = new DbParameter("@Province", DbParameter.DbType.NVarChar, 0, model.Province);
            ObjParam[9] = new DbParameter("@username", DbParameter.DbType.NVarChar, 0, model.UserName);

            int i = ObjParam.Count();
            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, query, ObjParam));

        }
        //july changes
        public static DataTable GetAllDealerStatus(int StatusTypeId, string Status)
        {
            DbParameter[] ObjParam = new DbParameter[2];

            ObjParam[0] = new DbParameter("@StatusTypeId", DbParameter.DbType.Int, 0, StatusTypeId);
            ObjParam[1] = new DbParameter("@Status", DbParameter.DbType.NVarChar, 0, Status);

            return DbConnection.GetDataTable(CommandType.StoredProcedure, "GetAllStatus", ObjParam);
        }

        public static DataTable GetAllProvinces(int ProvinceId, string Province)
        {
            DbParameter[] ObjParam = new DbParameter[2];

            ObjParam[0] = new DbParameter("@ProvinceId", DbParameter.DbType.Int, 0, ProvinceId);
            ObjParam[1] = new DbParameter("@Province", DbParameter.DbType.NVarChar, 0, Province);

            return DbConnection.GetDataTable(CommandType.StoredProcedure, "GetAllProvinces", ObjParam);
        }

        public static DataSet GetAllDealers(int DealerId, int PageSize, int PageNum, string Keyword, string SortBy, string SortOrder, string Username)
        {

            DbParameter[] ObjParam = new DbParameter[7];

            ObjParam[0] = new DbParameter("@DealerId", DbParameter.DbType.Int, 0, DealerId);
            //ObjParam[0] = new DbParameter("@Name", DbParameter.DbType.NVarChar, 0, Name);
            ObjParam[1] = new DbParameter("@Pagesize", DbParameter.DbType.Int, 0, PageSize);
            ObjParam[2] = new DbParameter("@Pagenum", DbParameter.DbType.Int, 0, PageNum);
            ObjParam[3] = new DbParameter("@Keyword", DbParameter.DbType.NVarChar, 0, Keyword);
            ObjParam[4] = new DbParameter("@field", DbParameter.DbType.Int, 0, SortBy);
            ObjParam[5] = new DbParameter("@orderby", DbParameter.DbType.NVarChar, 0, SortOrder);
            ObjParam[6] = new DbParameter("@orderby", DbParameter.DbType.NVarChar, 0, Username);

            return DbConnection.GetDataSet(CommandType.StoredProcedure, "GetAllDealers", ObjParam);
        }

        //GetAllDealerType
        public static DataTable GetAllDealerType(int DealerTypeId, string DealerType)
        {
            DbParameter[] ObjParam = new DbParameter[2];

            ObjParam[0] = new DbParameter("@DealerTypeId", DbParameter.DbType.Int, 0, DealerTypeId);
            ObjParam[1] = new DbParameter("@DealerType", DbParameter.DbType.NVarChar, 0, DealerType);

            return DbConnection.GetDataTable(CommandType.StoredProcedure, "GetAllDealerType", ObjParam);
        }

        public static DataTable GetDealerTypeLookup()
        {
            string query = "GetDealerTypeLookup";
            return DbConnection.GetDataTable(CommandType.StoredProcedure, query);
        }

        public static DataTable GetStatusTypeLookup()
        {
            string query = "GetStatusTypeLookup";
            return DbConnection.GetDataTable(CommandType.StoredProcedure, query);
        }

        public static DataTable DealerCommStatusDropDown()
        {
            string query = "GetDealerCommunicationStatuses";
            return DbConnection.GetDataTable(CommandType.StoredProcedure, query);
        }

        public static DataTable GetDealershipsDropDown()
        {
            string query = "GetDealershipsDropDown";
            return DbConnection.GetDataTable(CommandType.StoredProcedure, query);
        }

        public static DataTable GetProvinceDropDown()
        {
            string query = "GetProvinceDropDown";
            return DbConnection.GetDataTable(CommandType.StoredProcedure, query);
        }

        public static DataTable DealerExistCheck()
        {
            string query = "SaveDealerDetails";
            return DbConnection.GetDataTable(CommandType.StoredProcedure, query);
        }
        //for returning the string
        public static string SaveDealerTestCheck(int dealerid, string dealername)
        {
            string query = "SaveDealerDetails";
            return DbConnection.GetDataTable(CommandType.StoredProcedure, query).Rows[0][0].ToString();
        }

        public static DataSet GetDealerId(int Dealerid)
        {

            DbParameter[] ObjParam = new DbParameter[1];

            ObjParam[0] = new DbParameter("@DealerId", DbParameter.DbType.Int, 0, Dealerid);

            return DbConnection.GetDataSet(CommandType.StoredProcedure, "GetDealerId", ObjParam);
        }

        public static DataTable GetDealerById(int DealerId)
        {
            DbParameter[] ObjParam = new DbParameter[1];
            ObjParam[0] = new DbParameter("@DealerId", DbParameter.DbType.Int, 0, DealerId);
            // ObjParam[1] = new DbParameter("@Username", DbParameter.DbType.NVarChar, 0, User);
            //ObjParam[1] = new DbParameter("@Name", DbParameter.DbType.NVarChar, 0, Name);
            return DbConnection.GetDataTable(CommandType.StoredProcedure, "GetDealerById", ObjParam);
        }
    }
}
