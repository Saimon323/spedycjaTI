using Geocoding.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spedycja.Geocoding
{
    public static class GeocodingProvider
    {
        public static Tuple<double, double> getLatLong(string location)
        {
            GoogleGeocoder geocoder = new GoogleGeocoder();
            var addresses = geocoder.Geocode(location);
            foreach (var coord in addresses)
            {
                Thread.Sleep(500);
                Tuple<double, double> result = new Tuple<double, double>(coord.Coordinates.Latitude, coord.Coordinates.Longitude);
                return result;
            }

            return null;
        }
    }
    
}
