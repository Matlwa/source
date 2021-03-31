using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
    public class MemberAddonProductsModel
    {
        public MemberAddonProductsModel()
        {
            ProductName = string.Empty;
        }
        public Guid pkiMemberProductID  {get;set;}
        public DateTime DateCreated { get; set; }
        public string UserID { get; set; }
        public Guid fkiProductID { get; set; }
        public int fkiMemberid { get; set; }
        public Guid parlourid { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedUser { get; set; }
        public Decimal? ProductCost { get; set; }
        public int? Deleted { get; set; }
        public string ProductName { get; set; }

     
    }
}
