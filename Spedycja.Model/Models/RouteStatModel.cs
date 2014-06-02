using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spedycja.Model.Models
{
    public class RouteStatModel
    {
        public int Rate { get; set; }

        public string Text { get; set; }

        public string StartName { get; set; }

        public string EndName { get; set; }

        public double StartLat { get; set; }
        public double StartLong { get; set; }
        public double EndLat { get; set; }
        public double EndLong { get; set; }
    }
}
