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
                route.StartLat = from.Item1;
                route.StartLong = from.Item2;
            }

            if (route.EndPoint != null) { 
                
                Tuple<double, double> to = Geocoding.GeocodingProvider.getLatLong(route.EndPoint);
                route.EndLat = to.Item1;
                route.EndLong = to.Item2;
            }

            Entities.Routes.Add(route);
            Entities.SaveChanges();
            return route.id;
        }

        public Tuple<string, string> getRouteStartEndById(int id)
        {
            Route route = Entities.Routes.Where(x => x.id == id).FirstOrDefault();
            Tuple<string, string> routeResult = new Tuple<string, string>(route.StartPoint,route.EndPoint);
            return routeResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance">In Meters</param>
        /// <returns></returns>
        public List<RouteStatModel> GetRoutes(double distance)
        {
            //var startPoints = getAllRoutes().Select(t => t.StartCoord);
            //var endPoints = getAllRoutes().Select(t => t.EndCoord);

            var allPointToPoints = new List<PointToPoint>();

            var startPoints = new List<GeoCoordinate>();
            var endPoints = new List<GeoCoordinate>();
            foreach (var route in getAllRoutes().ToList())
            {
                var startPoint = new GeoCoordinate(route.StartLat.Value, route.StartLong.Value);
                var endPoint = new GeoCoordinate(route.EndLat.Value, route.EndLong.Value);
                startPoints.Add(startPoint);
                endPoints.Add(endPoint);

                string startName = route.StartPoint.Split(';')[0] + ", " + route.StartPoint.Split(';')[1];
                string endName = route.EndPoint.Split(';')[0] + ", " + route.EndPoint.Split(';')[1];

                allPointToPoints.Add(new PointToPoint() 
                { 
                    StartPoint = startPoint, 
                    EndPoint = endPoint,
                    StartName = startName,
                    EndName = endName,
                    Text = "z: " + startName + " do " + endName
                });
            }


            var startPointsGroups = new List<List<GeoCoordinate>>();
            var endPointsGroups = new List<List<GeoCoordinate>>();

            var groupedPoints = new List<GeoCoordinate>();
            foreach (var point in startPoints)
            {// grupowanie punktów startowych
                if (!groupedPoints.Contains(point))
                {
                    var newGroup = new List<GeoCoordinate>();
                    newGroup.Add(point);
                    groupedPoints.Add(point);
                    for (int i = startPoints.IndexOf(point) + 1; i < startPoints.Count; i++)
                    {
                        if (startPoints[i].GetDistanceTo(point) <= distance)
                        {
                            newGroup.Add(startPoints[i]);
                            groupedPoints.Add(startPoints[i]);
                        }
                    }

                    startPointsGroups.Add(newGroup);
                }
            }

            groupedPoints.Clear();
            foreach (var point in endPoints)
            {// grupowanie punktów końcowych
                if (!groupedPoints.Contains(point))
                {
                    var newGroup = new List<GeoCoordinate>();
                    newGroup.Add(point);
                    groupedPoints.Add(point);
                    for (int i = endPoints.IndexOf(point) + 1; i < endPoints.Count; i++)
                    {
                        if (endPoints[i].GetDistanceTo(point) <= distance)
                        {
                            newGroup.Add(endPoints[i]);
                            groupedPoints.Add(endPoints[i]);
                        }
                    }

                    endPointsGroups.Add(newGroup);
                }
            }

            //startPointsGroups tutaj są już grupy punktów początkowych
            //endPointsGroups tutaj są już grupy punktów końcowych
            // teraz trzeba zliczyć jak czesto jest z jednej grupy do drugiej
            //Pierwszy punkt w grupie to punkt tytułowy grupy. Np. grupa zawieta punktu A,B,C to cała grupa ma identyfikator A.
            var counter = new Dictionary<PointToPoint, int>();
            foreach (var ptp in allPointToPoints)
            {
                var startGroup = startPointsGroups.Where(t => t.Contains(ptp.StartPoint)).FirstOrDefault();
                var endGroup = endPointsGroups.Where(t => t.Contains(ptp.EndPoint)).FirstOrDefault();

                var key = new PointToPoint() { StartPoint = startGroup.First(), EndPoint = endGroup.First() };
                if (counter.ContainsKey(key))
                {
                    counter[key]++;
                }
                else
                {
                    counter[key] = 1;
                }
            }


            var result = new List<RouteStatModel>();
            foreach (var route in counter)
            {
                result.Add(new RouteStatModel()
                    {
                        Rate = route.Value,
                        StartLat = route.Key.StartPoint.Latitude,
                        StartLong = route.Key.StartPoint.Longitude,
                        EndLat = route.Key.StartPoint.Latitude,
                        EndLong = route.Key.StartPoint.Longitude,
                        StartName = route.Key.StartName,
                        EndName = route.Key.EndName,
                        Text = route.Key.Text
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
