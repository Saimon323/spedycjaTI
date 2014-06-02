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
    public class TypesFreightRepository : BaseRepository, ITypesFreightRepository
    {
        public TypesFreight GetTypesFreightById(int id)
        {
            return Entities.TypesFreights.Where(t => t.id == id).FirstOrDefault();
        }

        public List<TypesFreight> GetAllTypesFreight()
        {
            return Entities.TypesFreights.ToList();
        }
    }
}
