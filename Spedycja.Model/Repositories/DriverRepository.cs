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
    public class DriverRepository : BaseRepository, IDriverRepository
    {
        public Driver GetDriverById(int id)
        {
            return Entities.Drivers.Where(t => t.id == id).FirstOrDefault();
        }

        public List<Driver> GetAllDrivers()
        {
            return Entities.Drivers.ToList();
        }
    }
}
