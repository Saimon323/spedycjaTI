using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spedycja.Model.EntityModels;

namespace Spedycja.Model.Repositories.Interfaces
{
    public interface IRouteRepository
    {
        List<Route> getAllRoutes();
        Route getRouteById(int id);

        int CreateNewRouteByOrder(Route route);
    }
}
