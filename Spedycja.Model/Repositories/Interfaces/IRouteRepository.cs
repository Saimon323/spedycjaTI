using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spedycja.Model.EntityModels;
using Spedycja.Model.Repositories;
using Spedycja.Model.Models;

namespace Spedycja.Model.Repositories.Interfaces
{
    public interface IRouteRepository
    {
        List<Route> getAllRoutes();
        Route getRouteById(int id);

        int CreateNewRouteByOrder(Route route);

        Tuple<string, string> getRouteStartEndById(int id);

        List<RouteStatModel> GetAggregatedRoutes(double distance);
    }
}
