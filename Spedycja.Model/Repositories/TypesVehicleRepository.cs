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
    public class TypesVehicleRepository : BaseRepository, ITypesVehicleRepository
    {
        public TypesVehicle GetTypesVehicleById(int id)
        {
            return Entities.TypesVehicles.Where(t => t.id == id).FirstOrDefault();
        }

        public List<TypesVehicle> GetAllTypesVehicle()
        {
            return Entities.TypesVehicles.ToList();
        }
    }
}
