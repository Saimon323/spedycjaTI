using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Spedycja.Model.Models
{
    public class EditOrderModel
    {
        public int id { get; set; }
        public int idStatus { get; set; }
        public LoadEditModel load { get; set; }
        public VehicleEditModel vehicle { get; set; }
        public RouteEditModel route { get; set; }
        public CustomerEditModel customer { get; set; }
        public DriverEditModel driver { get; set; }
        public EditOrderModel()
        {
            load = new LoadEditModel();
            vehicle = new VehicleEditModel();
            route = new RouteEditModel();
            customer = new CustomerEditModel();
            driver = new DriverEditModel();
        }
    }

    public class LoadEditModel
    {
        [Display(Name = "Nazwa ładunku")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Cena")]
        public double Price { get; set; }

        [Display(Name = "Waga")]
        public double Weight { get; set; }

        [Display(Name = "Typ ładunku")]
        [DataType(DataType.Text)]
        public string LoadType { get; set; }
    }

    public class VehicleEditModel
    {
        [Display(Name = "Typ/Nazwa pojazdu")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }
    }

    public class RouteEditModel
    {
        [Display(Name = "Tasa z:")]
        [DataType(DataType.Text)]
        [Required]
        public string StartPoint { get; set; }

        [Display(Name = "Tasa do:")]
        [DataType(DataType.Text)]
        [Required]
        public string EndPoint { get; set; }
    }

    public class CustomerEditModel
    {
        [Display(Name = "Imię")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [DataType(DataType.Text)]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Adres")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Display(Name = "Nr telefonu")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Nazwa firmy")]
        [DataType(DataType.Text)]
        public string Firm { get; set; }
    }

    public class DriverEditModel
    {
        [Display(Name = "Imię")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [DataType(DataType.Text)]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Adres")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Display(Name = "Nr telefonu")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Nazwa firmy")]
        [DataType(DataType.Text)]
        public string Firm { get; set; }
    }
}
