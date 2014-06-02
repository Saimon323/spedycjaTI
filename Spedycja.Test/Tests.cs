using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spedycja.Model.EntityModels;
using Spedycja.Model.Repositories;

namespace Spedycja.Test
{
    class Tests
    {
        static void Main(string[] args)
        {
            
            CustomerRepository customerRepo = new CustomerRepository();
            IQueryable<Customer> allCustomersList = customerRepo.GetAllCustomers();
            foreach (var x in allCustomersList)
            {
                Console.WriteLine(x.Name + " " + x.Surname + " " + x.PhoneNumber);
            }

            #region geocoding
            /*GoogleGeocoder geocoder = new GoogleGeocoder();
            GoogleAddress[] addresses = geocoder.Geocode("1600 pennsylvania ave washington dc");

            var country = addresses.Where(a => !a.IsPartialMatch).Select(a => a[GoogleAddressType.Country]).First();
            Console.WriteLine("Country: " + country.LongName + ", " + country.ShortName);*/

            //GoogleGeocoder geocoder = new GoogleGeocoder();
            //var addresses = geocoder.Geocode("Poznań");
            //foreach (var xxx in addresses)
            //{
            //    var cord = xxx.Coordinates;
            //}

            //Tuple<double, double> result = Geocoding.GeocodingProvider.getLatLong("Berlin");
            //Tuple<double, double> result2 = Geocoding.GeocodingProvider.getLatLong("warszawa");
            //var country = addresses.Where(a => !a.IsPartialMatch).Select(a => a[GoogleAddressType.Country]).First();


            #endregion

            Console.ReadKey();
        }


    }
}
