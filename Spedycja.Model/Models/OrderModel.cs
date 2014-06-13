//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;


//namespace Spedycja.Model.Models
//{
//    public class OrderModel
//    {//update2

//        [Display(Name = "Nazwa ładunku")]
//        [Required]
//        public string CargoName { get; set; }

//        [Display(Name = "Waga")]
//        public int Weight { get; set; }

//        [Display(Name = "Objętość")]
//        public double Volume { get; set; }

//        [Display(Name = "Typ ładunku")]
//        public int CargoType { get; set;}

//        [Display(Name = "Cena")]
//        public decimal Price { get; set; }

//        [Display(Name = "Typ pojazdu")]
//        public int VehicleType { get; set; }

//        [Required]
//        [HiddenInput(DisplayValue = true)]
//        public int Status { get; set; }

//        [Display(Name = "Tasa z kraju:")]
//        public string StartCountry { get; set; }

//        [Display(Name = "Trasa z miasta:")]
//        public string StartCity { get; set; }

//        [Display(Name = "Trasa z ulicy:")]
//        public string StartStreet { get; set; }

//        [Display(Name = "Trasa do kraju:")]
//        public string EndCountry { get; set; }

//        [Display(Name = "Trasa do miasta:")]
//        public string EndCity { get; set; }

//        [Display(Name = "Trasa do ulica:")]
//        public string EndStreet { get; set; }

//        [Required]
//        [HiddenInput(DisplayValue = false)]
//        public string WorkerLogin { get; set; }

//        [HiddenInput(DisplayValue = false)]
//        public int? CustomerId { get; set; }

//        [HiddenInput(DisplayValue = false)]
//        public int? DriverId { get; set; }
//    }

//    public class ClientModel
//    {
//        [Display(Name = "Imię")]
//        public string Name { get; set; }

//        [Display(Name = "Nazwisko")]
//        public string Surname { get; set; }

//        [Display(Name = "Adres")]
//        public string Address { get; set; }

//        [Display(Name = "Nr telefonu")]
//        public string PhoneNumber { get; set; }

//        [Display(Name = "Nazwa firmy")]
//        public string Company { get; set; }
//    }

//    public class DriverModel : ClientModel
//    {
//        [Display(Name = "Obszar działania")]
//        public string ActivityArea { get; set; }
//    }

//    public class CustomerModel : ClientModel
//    {
        
//    }

//    public class JoinedClientsModel
//    {
//        [Display(Name = "Imię kierowcy")]
//        public string DriverName { get; set; }

//        [Display(Name = "Nazwisko kierowcy")]
//        public string DriverSurname { get; set; }

//        [Display(Name = "Adres kierowcy")]
//        public string DriverAddress { get; set; }

//        [Display(Name = "Nr telefonu kierowcy")]
//        public string DriverPhoneNumber { get; set; }

//        [Display(Name = "Nazwa firmy kierowcy")]
//        public string DriverCompany { get; set; }

//        [Display(Name = "Obszar działania kierowcy")]
//        public string DriverActivityArea { get; set; }

//        [Display(Name = "Imię zleceniodawcy")]
//        public string CustomerName { get; set; }

//        [Display(Name = "Nazwisko zleceniodawcy")]
//        public string CustomerSurname { get; set; }

//        [Display(Name = "Adres zleceniodawcy")]
//        public string CustomerAddress { get; set; }

//        [Display(Name = "Nr telefonu zleceniodawcy")]
//        public string CustomerPhoneNumber { get; set; }

//        [Display(Name = "Nazwa firmy zleceniodawcy")]
//        public string CustomerCompany { get; set; }
//    }
//}
