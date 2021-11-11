using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeral.Model;
using Funeral.DAL;
using System.Data.Common;
using System.Web.UI.WebControls;

namespace Funeral.DAL
{
    public class DealerTotal
    {
        //public static string GetDealerTotal(string Total)
        //{

        //    DbParameter[] ObjParam = new DbParameter[1];

        //    ObjParam[0] = new DbParameter("@Total", DbParameter.DbType.Int, 0, Total);

        //    return  DbConnection.ExecuteNonQuery(CommandType.StoredProcedure, "GetDealerTotal", ObjParam);
        //}

        //public static string GetDealerTotal(string username)
        //{
        //    string query = "GetDealerTotal";

        //    return DbConnection.GetDataTable(CommandType.StoredProcedure, query).Rows[0][0].ToString();
        //}

        public static string GetDealerTotal(string username/*, string Total*/ )
        {
            DbParameter[] objparam = new DbParameter[1];
            objparam[0] = new DbParameter("@username", DbParameter.DbType.NVarChar, 0, username);
            //objparam[1] = new DbParameter("@total", DbParameter.DbType.NVarChar, 0, Total);

            //objparam[1] = new dbparameter("@name", dbparameter.dbtype.nvarchar, 0, name);
            return Convert.ToString(DbConnection.GetScalarValue(CommandType.StoredProcedure, "getdealertotal", objparam));
        }
    }
}
