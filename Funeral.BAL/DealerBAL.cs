using Funeral.Model;
using Funeral.BAL;
using Funeral.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.BAL
{
    public class DealerBAL
    {
        public static int SaveDealerDetails(DealerModel model)
        {
            return DealerDAL.SaveDealerDetails(model);
        }
    }
}
