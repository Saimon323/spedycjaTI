using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spedycja.Model.Repositories.Interfaces;
using Spedycja.Model.EntityModels;

namespace Spedycja.Model.Repositories
{
    public class StatusHistoryRepository : BaseRepository, IStatusHistoryRepository
    {
        public void AddStatusHistory(StatusHistory statusHistory)
        {
            //statusHistory.StatusOrder = Entities.StatusOrders.Where(t => t.id == statusHistory.idStatus).FirstOrDefault();
            //statusHistory.Order = Entities.Orders.Where(x => x.id == statusHistory.idOrder).FirstOrDefault();
            //statusHistory.Worker = Entities.Workers.Where(y => y.id == statusHistory.idWorker).FirstOrDefault();
            //Entities.StatusHistories.Add(statusHistory);
            //Entities.SaveChanges();
        }
    }
}
