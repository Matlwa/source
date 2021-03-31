using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
    public class VehiclesModel
    {
        public VehiclesModel()
        {
            VehicleMake = string.Empty;
            VehicleModel = string.Empty;
            VehicleYear = string.Empty;
            VehicleColor = string.Empty;
            VehicleTrackingCompany = string.Empty;
            VehicleRegNo = string.Empty;
            VehicleVinNo = string.Empty;
            VehicleEngNo = string.Empty;
            PkiVehicleID = 0;
            FkiMemberID = 0;
            StartDate = System.DateTime.Now;
            LastModified = System.DateTime.Now;
            ModifiedUser = string.Empty;
        }

        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleYear { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleTrackingCompany { get; set; }
        public string VehicleRegNo { get; set; }
        public string VehicleVinNo { get; set; }
        public string VehicleEngNo { get; set; }
        public int PkiVehicleID { get; set; }
        public int FkiMemberID { get; set; }
        public Guid ParlourID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedUser { get; set; }
    }
}
