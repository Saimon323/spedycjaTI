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
    public class WorkerRepository: BaseRepository, IWorkerRepository
    {
        public Worker getWorkerByLogin(string Login)
        {
            return Entities.Workers.Where(x => x.Login == Login).FirstOrDefault();
        }

        public bool LogIn(string Login, string Password)
        {
            Worker worker = Entities.Workers.Where(x => x.Login == Login && x.Password == Password).FirstOrDefault();

            if(worker != null){

                return true;
            }
            return false;
            
        }

        public int getWorkerIdByLogin(string login)
        {
            Worker worker = Entities.Workers.Where(x => x.Login == login).FirstOrDefault();
            return worker.id;
        }

        
    }
}
