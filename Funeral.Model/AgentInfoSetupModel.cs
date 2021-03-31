using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
    public class AgentInfoSetupModel
    {
        public AgentInfoSetupModel()
        {
            Surname = string.Empty;
            Fullname = string.Empty;
            ContactNumber = string.Empty;
            Address1 = string.Empty;
            Address2 = string.Empty;
            Address3 = string.Empty;
            Address4 = string.Empty;
            Code = string.Empty;
            Email = string.Empty;
            ModifiedUser = string.Empty;
        }


        public int ID { get; set; }
        public string Surname { get; set; }
        public string Fullname { get; set; }
        public Decimal percentage { get; set; }
        public Guid parlourid { get; set; }
        public string ContactNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedUser { get; set; }


    }
  
}
