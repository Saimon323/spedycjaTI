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
    public class StatusOrderRepository : BaseRepository, IStatusOrderRepository
    {
        public StatusOrder GetStatusOrderById(int id)
        {
            return Entities.StatusOrders.Where(t => t.id == id).FirstOrDefault();
        }
    }
}
