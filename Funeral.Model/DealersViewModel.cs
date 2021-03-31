using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
   public class DealersViewModel
    {
        public int DealerId { get; set; }
        public List<DealerDetailsModel> DealerList { get; set; }
        public Int64 TotalRecord { get; set; }
    }
}
