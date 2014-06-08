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
    public class LoadRepository : BaseRepository, ILoadRepository
    {
        public int CreateLoadByOrder(Load load)
        {
            Entities.Loads.Add(load);
            Entities.SaveChanges();
            return load.id;
        }

        public string getLoadNameById(int id)
        {
            return Entities.Loads.Where(x => x.id == id).FirstOrDefault().Name;
        }
    }
}
