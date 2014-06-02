using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spedycja.Site.Models
{
    public class OrderModel
    {//update2
        public string CargoName { get; set; }

        public int Weight { get; set; }

        public double Volume { get; set; }

        public int CargoType { get; set;}

        public decimal Price { get; set; }

        public int VehicleType { get; set; }

        public int Status { get; set; }

        public string StartCountry { get; set; }

        public string StartCity { get; set; }

        public string StartStreet { get; set; }

        public string EndCountry { get; set; }

        public string EndCity { get; set; }

        public string EndStreet { get; set; }

        public string WorkerLogin { get; set; }

        public int? CustomerId { get; set; }

        public int? DriverId { get; set; }
    }
}
