using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
    public class PackageServiceModel
    {
        public int pkiPackageID { get; set; }
        public string PackageName { get; set; }
        public int fkiServiceID { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedUser { get; set; }
        public Guid ParlourId { get; set; }
        public int fkiPackageID { get; set; }
        public decimal Total { get; set; }
    }
}
