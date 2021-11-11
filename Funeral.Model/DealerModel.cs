using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
    public class DealerModel
    {
        public DealerModel()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Landline = string.Empty;
            CellphoneNumber = string.Empty;
            Email = string.Empty;
            DealershipName = string.Empty;
            DealerType = string.Empty;
            Comment = string.Empty;
            Status = string.Empty;
            Province = string.Empty;
        }

        public int DealerId { get; set; }

        public int DealershipId { get; set; }

        public int DealerTypeId { get; set; }

        public int StatusTypeId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Landline { get; set; }

        public string CellphoneNumber { get; set; }

        public string Email { get; set; }

        public string DealershipName { get; set; }

        public string DealerType { get; set; }

        public string Comment { get; set; }

        public string Status { get; set; }
        public string UserName { get; set; }
        public string Province { get; set; }
        public string ReturnedMessage { get; set; }
        public string CommunicationStatus { get; set; }

    }
}
