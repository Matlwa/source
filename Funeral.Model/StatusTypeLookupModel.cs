using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
    public class StatusTypeLookupModel
    {
        public int StatusTypeId { get; set; }
        public string StatusType { get; set; }

        public StatusTypeLookupModel()
        {
            StatusType = string.Empty;
            StatusTypeId = 0;
        }
    }
}
