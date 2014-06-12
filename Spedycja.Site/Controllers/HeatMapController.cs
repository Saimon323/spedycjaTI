using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spedycja.Model.EntityModels;
using Spedycja.Model.Repositories.Interfaces;
using Spedycja.Model.Repositories;
using Spedycja.Site.Models;
using Newtonsoft.Json;


namespace Spedycja.Site.Controllers
{
    public class HeatMapController : Controller
    {
        //
        // GET: /HeatMap/

        public ActionResult HeatMap()
        {
            //IRouteRepository routeRepository = new RouteRepository();
            //List<Route> allRoutes = routeRepository.getAllRoutes();
            //List<POIModel> RoutesList = new List<POIModel>();
            //POIModel routeToAdd;

            //foreach (var route in allRoutes)
            //{
            //    routeToAdd = new POIModel("", route.StartPoint, route.StartLat.GetValueOrDefault(), route.StartLong.GetValueOrDefault());
            //    RoutesList.Add(routeToAdd);
            //    routeToAdd = new POIModel("", route.EndPoint, route.EndLat.GetValueOrDefault(), route.EndLong.GetValueOrDefault());
            //    RoutesList.Add(routeToAdd);
            //}

            //return View(RoutesList);
            return View();
        }

        public string getAllHeatPoint()
        {
            IRouteRepository routeRepository = new RouteRepository();
            List<Route> allRoutes = routeRepository.getAllRoutes();
            List<POIModel> RoutesList = new List<POIModel>();
            POIModel routeToAdd;

            foreach (var route in allRoutes)
            {
                routeToAdd = new POIModel("", route.StartPoint, route.StartLat.GetValueOrDefault(), route.StartLong.GetValueOrDefault());
                RoutesList.Add(routeToAdd);
                routeToAdd = new POIModel("", route.EndPoint, route.EndLat.GetValueOrDefault(), route.EndLong.GetValueOrDefault());
                RoutesList.Add(routeToAdd);
            }

            return JsonConvert.SerializeObject(RoutesList);
        }
    }
}
