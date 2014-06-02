using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spedycja.Model.EntityModels;
using Spedycja.Model.Repositories;
using Spedycja.Model.Repositories.Interfaces;

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
    }
}
