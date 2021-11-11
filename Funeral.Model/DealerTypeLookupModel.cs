using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
    public class DealerTypeLookupModel
    {

        public int DealerTypeId { get; set; }
        public string DealerType { get; set; }

        // public string Email { get; set; }

        public DealerTypeLookupModel()
        {
            DealerType = string.Empty;
            DealerTypeId = 0;
            //Email = string.Empty;
        }
    }
}
