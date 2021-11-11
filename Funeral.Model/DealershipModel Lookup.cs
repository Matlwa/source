using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
    public class DealershipLookupModel
    {
        public int DealershipId { get; set; }
        public string DealershipName { get; set; }

          
        public DealershipLookupModel()
        {
            DealershipName = string.Empty;
            DealershipId = 0;
        }
    }
}

