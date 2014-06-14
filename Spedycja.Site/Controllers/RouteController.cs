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
            var aggregatedRoutes = routeRepository.GetAggregatedRoutes(50 * 1000); // w metrach
            var routes = routeRepository.getAllRoutes();
            List<POIModelExtended> RoutesList = new List<POIModelExtended>();
            POIModelExtended routeToAdd;
            string place;
            //foreach(var route in routes)
            //{
            //    routeToAdd = new POIModel("", route.StartPoint, route.StartLat.GetValueOrDefault(), route.StartLong.GetValueOrDefault());
            //    RoutesList.Add(routeToAdd);
            //    routeToAdd = new POIModel("", route.EndPoint, route.EndLat.GetValueOrDefault(), route.EndLong.GetValueOrDefault());
            //    RoutesList.Add(routeToAdd);
            //}

            foreach (var route in aggregatedRoutes)
            {
                routeToAdd = new POIModelExtended("", route.StartName, route.StartLat, route.StartLong,route.Rate);
                RoutesList.Add(routeToAdd);
                routeToAdd = new POIModelExtended("", route.EndName, route.EndLat, route.EndLong,route.Rate);
                RoutesList.Add(routeToAdd);
            }

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
