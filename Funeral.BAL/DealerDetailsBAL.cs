using System;
using Funeral.Model;
using Funeral.DAL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.BAL
{
   public class DealerDetailsBAL

    {
        public static int SaveDealerDetails(DealerDetailsModel model)
        {
            return DealerDetailsDAL.SaveDealerDetails(model);
        }

        public static void UpdateDealerDetails(DealerDetailsModel model)
        {
           DealerDetailsDAL.SaveDealerDetails(model);
        }
    }
}
