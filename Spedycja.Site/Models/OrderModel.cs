using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spedycja.Model.EntityModels;

namespace Spedycja.Site.Models
{
    public class OrderModel
    {
        public LoadModel load {get;set;}
        public VehicleModel vehicle { get; set; }
        public RouteModel route { get; set; }
        public CustomerModel customer { get; set; }
        [Display(Name = "Cena")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        //public string napis{get;set;}

        public OrderModel()
        {
            load = new LoadModel();
            vehicle = new VehicleModel();
            route = new RouteModel();
            customer = new CustomerModel();
        }
    }

    public class LoadModel
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

    public class VehicleModel
    {
        [Display(Name = "Typ/Nazwa pojazdu")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }
    }

    public class RouteModel
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

    public class CustomerModel
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


    public class OrderEditModel
    {
        public LoadModel load { get; set; }
        public VehicleModel vehicle { get; set; }
        public RouteModel route { get; set; }
        public CustomerModel customer { get; set; }
        public DriverModel driver { get; set; }
        [Display(Name = "Cena")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        //public string napis{get;set;}

        public OrderEditModel()
        {
            load = new LoadModel();
            vehicle = new VehicleModel();
            route = new RouteModel();
            customer = new CustomerModel();
            driver = new DriverModel();
        }
    }

    public class DriverModel
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