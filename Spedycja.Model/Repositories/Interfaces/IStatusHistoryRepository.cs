using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spedycja.Model.EntityModels;
using System.Data.Spatial;

namespace Spedycja.Model.Repositories.Interfaces
{
    public interface IStatusHistoryRepository
    {
        void AddStatusHistory(StatusHistory statusHistory);
    }
}
