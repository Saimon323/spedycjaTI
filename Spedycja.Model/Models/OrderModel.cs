using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Spedycja.Model.Models
{
    public class OrderModel
    {//update2

        [Display(Name = "Nazwa ładunku")]
        [Required]
        public string CargoName { get; set; }

        [Display(Name = "Waga")]
        public int Weight { get; set; }

        [Display(Name = "Objętość")]
        public double Volume { get; set; }

        [Display(Name = "Typ ładunku")]
        public int CargoType { get; set;}

        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Display(Name = "Typ pojazdu")]
        public int VehicleType { get; set; }

        [Required]
        [HiddenInput(DisplayValue = true)]
        public int Status { get; set; }

        public string StartCountry { get; set; }

        public string StartCity { get; set; }

        public string StartStreet { get; set; }

        public string EndCountry { get; set; }

        public string EndCity { get; set; }

        public string EndStreet { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public string WorkerLogin { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? CustomerId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? DriverId { get; set; }
    }
}
