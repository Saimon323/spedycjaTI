using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spedycja.Model.EntityModels;

namespace Spedycja.Model.Repositories
{
    
     public class BaseRepository
    {
        public BaseRepository()
        {
            if (AppContext.Entities == null)
            {//Fist Time Connection
                AppContext.Entities = new SpedycjaEntities();
            }
        }

        protected static SpedycjaEntities Entities
        {
            get
            {
                if (AppContext.Entities == null)
                {
                    AppContext.Entities = new SpedycjaEntities();
                }

                return AppContext.Entities;
            }
        }
    }
     
}
