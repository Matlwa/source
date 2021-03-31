using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
  public class BankingDetailSending
    {

        public BankingDetailSending()
        {
            AccountHolder = string.Empty;
            Bankname = string.Empty;
            AccountNumber = string.Empty;
            Accounttype = string.Empty;
            Branch = string.Empty;
            Branchcode = string.Empty;
            LastModified = System.DateTime.Now;
            ModifiedUser = string.Empty;
            
        }
     
        public string AccountHolder { get; set; }
        public string Bankname { get; set; }
        public string AccountNumber { get; set; }
        public string Accounttype { get; set; }
        public string Branch { get; set; }
        public string Branchcode { get; set; }
        public Guid parlourid { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedUser { get; set; }
    }
}
