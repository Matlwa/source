using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeral.Model
{
    class CarTrackModel
    {
        public CarTrackModel()
        {
            InitVariables();
        }

        private void InitVariables()
        {
            this.Make = string.Empty;
            this.Model = string.Empty;
            this.Year = DateTime.MinValue;
            this.Colour = string.Empty;
            this.YearOfRegistration = DateTime.MinValue;
            this.LicenceRenewalDate = DateTime.MinValue;
            this.RegNumber = string.Empty;
            this.VinNo = string.Empty;
            this.DepartureDate = DateTime.MinValue;
            this.ArrivalAddress = string.Empty;
            this.ArrivalTime = TimeSpan.MinValue;
            this.ArrivalMileage = 0;
            this.KM = 0;
            this.TripNote = string.Empty;
            this.VehicleDetails = string.Empty;
            this.DateOfService = DateTime.MinValue;
            this.Mileage = 0;
            this.NextServiceMileage = 0;
            this.Dealership = string.Empty;
            this.ServiceCost = 0;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string Colour { get; set; }
        public DateTime YearOfRegistration { get; set; }
        public DateTime LicenceRenewalDate { get; set; }
        public string RegNumber { get; set; }
        public string VinNo { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Driver { get; set; }
        public string DepartureAddress { get; set; }
        public int DepartureMileage { get; set; }
        public string ArrivalAddress { get; set; }
        public TimeSpan ArrivalTime { get; set; }   
        public int ArrivalMileage { get; set; }
        public int KM { get; set; }
        public string TripNote { get; set; }
        public string VehicleDetails { get; set; }
        public DateTime DateOfService { get; set; }
        public int Mileage { get; set; }
        public int NextServiceMileage { get; set; }
        public string Dealership { get; set; }
        public Decimal ServiceCost { get; set; }
    }
}
