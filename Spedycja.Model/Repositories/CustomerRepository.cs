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
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public IQueryable<Customer> GetAllCustomers()
        {
            
            return Entities.Customers;
        }

        public Customer GetCustomerById(int id)
        {
            return Entities.Customers.Where(t => t.id == id).FirstOrDefault();
        }

        public int CreateNewCustomerByOrder(Customer customer)
        {
            Entities.Customers.Add(customer);
            Entities.SaveChanges();
            return customer.id;
        }
    }
}
