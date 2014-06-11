using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spedycja.Model.EntityModels;
using Spedycja.Model.Repositories;
using Spedycja.Model.Repositories.Interfaces;
using Spedycja.Model.Models;
using System.Device.Location;
using Spedycja.Geocoding;

namespace Spedycja.Model.Repositories
{
    public class RouteRepository : BaseRepository, IRouteRepository
    {
        public List<Route> getAllRoutes()
        {
            return Entities.Routes.ToList();
        }

        public Route getRouteById(int id)
        {
            return Entities.Routes.Where(x => x.id == id).FirstOrDefault();
        }

        public int CreateNewRouteByOrder(Route route)
        {
            if (route.StartPoint != null)
            {
                Tuple<double, double> from = Geocoding.GeocodingProvider.getLatLong(route.StartPoint);
                route.StartLat = from != null ? from.Item1 : 0 ;
                route.StartLong = from != null ? from.Item2 : 0;
            }

            if (route.EndPoint != null)
            {

                Tuple<double, double> to = Geocoding.GeocodingProvider.getLatLong(route.EndPoint);
                route.EndLat = to != null ? to.Item1 : 0;
                route.EndLong = to != null ? to.Item2 : 0;
            }

            Entities.Routes.Add(route);
            Entities.SaveChanges();
            return route.id;
        }

        public Tuple<string, string> getRouteStartEndById(int id)
        {
            Route route = Entities.Routes.Where(x => x.id == id).FirstOrDefault();
            Tuple<string, string> routeResult = new Tuple<string, string>(route.StartPoint, route.EndPoint);
            return routeResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance">In Meters</param>
        /// <returns></returns>
        public List<RouteStatModel> GetAggregatedRoutes(double distance)
        {
            var allPointToPoints = new List<PointToPoint>();

            foreach (var route in getAllRoutes().ToList())
            {
                allPointToPoints.Add(new PointToPoint()
                {
                    StartPoint = new GeoCoordinate(route.StartLat.Value, route.StartLong.Value),
                    EndPoint = new GeoCoordinate(route.EndLat.Value, route.EndLong.Value),
                    StartName = route.StartPoint,
                    EndName = route.EndPoint,
                    Text = "z: " + route.StartPoint + " do " + route.EndPoint
                });
            }


            var unGrouped = allPointToPoints.ToList();
            var Groups = new List<List<PointToPoint>>();
            foreach (var route in allPointToPoints)
            {
                if (unGrouped.Contains(route))
                {
                    var NewGroup = unGrouped.Where(t => t.StartPoint.GetDistanceTo(route.StartPoint) <= distance
                                                    && t.EndPoint.GetDistanceTo(route.EndPoint) <= distance).ToList();

                    foreach (var ptp in NewGroup)
                    {
                        unGrouped.Remove(ptp);
                    }

                    Groups.Add(NewGroup);
                }
            }

            var result = new List<RouteStatModel>();
            foreach (var route in Groups)
            {
                result.Add(new RouteStatModel()
                {
                    Rate = route.Count,
                    StartLat = route.First().StartPoint.Latitude,
                    StartLong = route.First().StartPoint.Longitude,
                    EndLat = route.First().EndPoint.Latitude,
                    EndLong = route.First().EndPoint.Longitude,
                    StartName = route.First().StartName,
                    EndName = route.First().EndName,
                    Text = route.First().Text
                });
            }

            return result;

        }

        private class PointToPoint
        {
            public GeoCoordinate StartPoint { get; set; }
            public GeoCoordinate EndPoint { get; set; }

            public string StartName { get; set; }
            public string EndName { get; set; }
            public string Text { get; set; }
        }


    }
}
