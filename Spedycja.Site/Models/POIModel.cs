using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spedycja.Site.Models
{
    public class POIModel
    {
        public string No { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longtitude { get; set; }

        public POIModel()
        {

        }

        public POIModel(string No, string Name, double Latitude, double Longtitude)
        {
            this.No = No;
            this.Name = Name;
            this.Latitude = Latitude;
            this.Longtitude = Longtitude;
        }
    }

    public class POIModelExtended : POIModel
    {
        public int Width { get; set; }

        public POIModelExtended(string No, string Name, double Latitude, double Longtitude, int Width)
        {
            this.No = No;
            this.Name = Name;
            this.Latitude = Latitude;
            this.Longtitude = Longtitude;
            this.Width = Width;
        }
    }
}