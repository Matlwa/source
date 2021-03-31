using System;
using Funeral.Model;
using Funeral.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.BAL
{
   public class DealershipBAL
    {
        public static int SaveDealership(DealershipModel model)
        {
            return DealershipDAL.SaveDealership(model);
        }     
    }
}
