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
        public static int SaveDealerDetails(DealerModel model)
        {
            string query = "SaveDealerDetails";
            DbParameter[] ObjParam = new DbParameter[11];

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

            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure,query, ObjParam));         
        }

        public static void UpdateDealerDetails(DealerModel model)
        {
            string query = "EditDealerDetails";
            DbParameter[] ObjParam = new DbParameter[10];

           // ObjParam[0] = new DbParameter("@DealerId", DbParameter.DbType.Int, 0, model.DealerId);
            //ObjParam[1] = new DbParameter("@DealershipId", DbParameter.DbType.Int, 0, model.DealershipId);
           // ObjParam[2] = new DbParameter("@DealerTypeId", DbParameter.DbType.Int, 0, model.DealerTypeId);
            //ObjParam[3] = new DbParameter("@StatusTypeId", DbParameter.DbType.Int, 0, model.StatusTypeId);
            ObjParam[0] = new DbParameter("@Name", DbParameter.DbType.NVarChar, 0, model.Name);
            ObjParam[1] = new DbParameter("@Surname", DbParameter.DbType.NVarChar, 0, model.Surname);
            ObjParam[2] = new DbParameter("@Landline", DbParameter.DbType.NVarChar, 0, model.Landline);
            ObjParam[3] = new DbParameter("@CellphoneNumber", DbParameter.DbType.NVarChar, 0, model.CellphoneNumber);
            ObjParam[4] = new DbParameter("@Email", DbParameter.DbType.NVarChar, 0, model.Email);
            ObjParam[5] = new DbParameter("@DealershipName", DbParameter.DbType.NVarChar, 0, model.DealershipName);
            ObjParam[6] = new DbParameter("@DealerType", DbParameter.DbType.NVarChar, 0, model.DealerType);
            ObjParam[7] = new DbParameter("@Comment", DbParameter.DbType.NVarChar, 0, model.Comment);
            ObjParam[8] = new DbParameter("@Status", DbParameter.DbType.NVarChar, 0, model.Status);
            ObjParam[9] = new DbParameter("@Province", DbParameter.DbType.NVarChar, 0, model.Province);

            Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, query, ObjParam));
        }


        public static int GetDealer(DealerModel model)
        {
            DealerModel addDealer = new DealerModel();
            string query = "GetDealer";
            DbParameter[] ObjParam = new DbParameter[9];

            ObjParam[0] = new DbParameter("@Names", DbParameter.DbType.NVarChar, 0, model.Name);
            ObjParam[1] = new DbParameter("@Surname", DbParameter.DbType.NVarChar, 0, model.Surname);
            ObjParam[2] = new DbParameter("@Landline", DbParameter.DbType.NVarChar, 0, model.Landline);
            ObjParam[3] = new DbParameter("@CellphoneNumber", DbParameter.DbType.NVarChar, 0, model.CellphoneNumber);
            ObjParam[4] = new DbParameter("@Email", DbParameter.DbType.NVarChar, 0, model.Email);
            ObjParam[5] = new DbParameter("@DealershipName", DbParameter.DbType.NVarChar, 0, model.DealershipName);
            ObjParam[6] = new DbParameter("@DealerType", DbParameter.DbType.NVarChar, 0, model.DealerType);
            ObjParam[7] = new DbParameter("@Status", DbParameter.DbType.NVarChar, 0, model.Status);
            ObjParam[8] = new DbParameter("@Province", DbParameter.DbType.NVarChar, 0, model.Province);
        
            int i = ObjParam.Count();
            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, query, ObjParam));

        }
    }
}
