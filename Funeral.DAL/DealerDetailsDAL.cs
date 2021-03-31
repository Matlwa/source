using Funeral.Model;
using Funeral.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.DAL
{
   public class DealerDetailsDAL
    {
        public static int SaveDealerDetails(DealerDetailsModel model)
        {
            DbParameter[] ObjParam = new DbParameter[13];
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
            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure, "SaveDealerDetails", ObjParam));
        }
    }
}
