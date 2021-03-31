using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
    public class DealershipModel
    {
        public int DealershipId { get; set; }
        public string DealershipName { get; set; }
        public string LandLine { get; set; }
        // public string Email { get; set; }

        public DealershipModel()
        {
            DealershipName = string.Empty;
            LandLine = string.Empty;
            //Email = string.Empty;
        }
    }
}
