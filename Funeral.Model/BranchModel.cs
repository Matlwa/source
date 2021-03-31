using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
    public class BranchModel
    {
        public BranchModel()
        {
            Brancheid = new Guid("00000000-0000-0000-0000-000000000000");
            BranchName = string.Empty;
            Parlourid = new Guid("00000000-0000-0000-0000-000000000000");
            LastModified = System.DateTime.Now;
            ModifiedUser = string.Empty;
            Address1 = string.Empty;
            Address2 = string.Empty;
            Address3 = string.Empty;
            Address4 = string.Empty;
            Code = string.Empty;
            TelNumber = string.Empty;
            CellNumber = string.Empty;
            BranchCode = string.Empty;
            Region = string.Empty;
        }
        public Guid Brancheid { get; set; }
        public string BranchName { get; set; }
        public Guid Parlourid { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedUser { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Code { get; set; }
        public string TelNumber { get; set; }
        public string CellNumber { get; set; }
        public string Region { get; set; }
        public string BranchCode { get; set; }
    }
}
