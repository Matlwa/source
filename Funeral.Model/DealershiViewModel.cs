using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Funeral.Model
{

    public class DealershipViewModel
    {
        public int DealershipId { get; set; }
        public List<DealershipModel> DealershipList { get; set; }
        public Int64 TotalRecord { get; set; }
    }
}