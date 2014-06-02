using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spedycja.Model.Repositories.Interfaces;
using Spedycja.Model.Repositories;
using Spedycja.Model.EntityModels;
using Spedycja.Site.Models;

namespace Spedycja.Site.Controllers
{
    public class RouteController : Controller
    {
        //
        // GET: /Route/

        public ActionResult ShowAllRoutes()
        {
            IRouteRepository routeRepository = new RouteRepository();
            var routes = routeRepository.getAllRoutes();
            List<POIModel> RoutesList = new List<POIModel>();
            POIModel routeToAdd;
            string place;
            foreach(var route in routes)
            {
                place = route.StartPoint.Replace(";", ",");
                routeToAdd = getPOI(place);
                RoutesList.Add(routeToAdd);
                place = route.EndPoint.Replace(";",",");
                routeToAdd = getPOI(place);
                RoutesList.Add(routeToAdd);
            }
            /*var routes2 = routeRepository.getAllRoutes().Select(x => new POIModel
            {
                No = "",
                Name = x.StartCountry,
                Latitude = Spedycja.Geocoding.GeocodingProvider.getLatLong(x.StartCountry).Item1,
                Longtitude = Spedycja.Geocoding.GeocodingProvider.getLatLong(x.StartCountry).Item2

            }).ToList();*/

            return View(RoutesList);
        }

        public static POIModel getPOI(string route)
        {
            Tuple<double, double> LatLong = Spedycja.Geocoding.GeocodingProvider.getLatLong(route);
            POIModel routeToAdd = new POIModel("", route, LatLong.Item1, LatLong.Item2);
            return routeToAdd;
        }

    }
}
