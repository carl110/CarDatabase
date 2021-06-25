using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDatabase
{
    class Car
    {
        private string vehicleRegNo;
        private string make;
        private string engineSize;
        private DateTime dateRegistered;
        private double rentalPerDay;
        private bool available;

        public string VehicleRegNo { get => vehicleRegNo; set => vehicleRegNo = value; }
        public string Make { get => make; set => make = value; }
        public string EngineSize { get => engineSize; set => engineSize = value; }
        public DateTime DateRegistered { get => dateRegistered; set => dateRegistered = value; }
        public double RentalPerDay { get => rentalPerDay; set => rentalPerDay = value; }
        public bool Available { get => available; set => available = value; }

    }
}
