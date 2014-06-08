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
            Entities.StatusHistories.Add(statusHistory);
            Entities.SaveChanges();
        }
    }
}
