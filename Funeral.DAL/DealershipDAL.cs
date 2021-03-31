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
         public static int SaveDealership(DealershipModel model)
        {
            string query = "SaveDealership";
            DbParameter[] ObjParam = new DbParameter[3];

            ObjParam[0] = new DbParameter("@DealershipId", DbParameter.DbType.Int, 0, model.DealershipId);
            ObjParam[1] = new DbParameter("@DealershipName", DbParameter.DbType.NVarChar, 50, model.DealershipName);
            ObjParam[2] = new DbParameter("@LandLine", DbParameter.DbType.NVarChar, 50, model.LandLine);
           // ObjParam[3] = new DbParameter("@Email", DbParameter.DbType.NVarChar, 0, model.Email);

            return Convert.ToInt32(DbConnection.GetScalarValue(CommandType.StoredProcedure,query, ObjParam));         
        }
    }
}
