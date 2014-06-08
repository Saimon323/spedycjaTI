using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using Spedycja.Model.EntityModels;

namespace Spedycja.Site.Models
{
    public class OrderModel
    {
        public LoadModel load {get;set;}
        public VehicleModel vehicle { get; set; }
        public RouteModel route { get; set; }
        public CustomerModel customer { get; set; }

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
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string LoadType { get; set; }

    }

    public class VehicleModel
    {
        public string Name { get; set; }
    }

    public class RouteModel
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
    }

    public class CustomerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Firm { get; set; }
    }

}