using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spedycja.Model.EntityModels;
using Spedycja.Model.Repositories;
using Spedycja.Model.Repositories.Interfaces;
using Spedycja.Site.Models;



namespace Spedycja.Model.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public void AddNewOrder(OrderModel newOrder)
        {
            Order order = new Order();
            order.CreatedAt = DateTime.Now;
            if(newOrder.CustomerId.HasValue)
            {
                order.Customer = new CustomerRepository().GetCustomerById(newOrder.CustomerId.Value);
            }
            order.Worker = new WorkerRepository().getWorkerByLogin(newOrder.WorkerLogin);
            order.TypesVehicle = new TypesVehicleRepository().GetTypesVehicleById(newOrder.VehicleType);
            if(newOrder.DriverId.HasValue)
            {
                order.Driver = new DriverRepository().GetDriverById(newOrder.DriverId.Value);
            }
            order.Load = new Load()
            {
                IdType = newOrder.CargoType,
                Name = newOrder.CargoName,
                Price = newOrder.Price,
                TypesFreight = new TypesFreightRepository().GetTypesFreightById(newOrder.CargoType),
                Weight = newOrder.Weight
            };
            order.Route = new Route()
            {
                StartCountry = newOrder.StartCountry,
                StartCity = newOrder.StartCity,
                StartStreet = newOrder.StartStreet,
                EndCountry = newOrder.EndCountry,
                EndCity = newOrder.EndCity,
                EndStreet = newOrder.EndStreet
            };
            order.StatusOrder = new StatusOrderRepository().GetStatusOrderById(1);
            order.StatusHistories.Add(new StatusHistory()
            {
                ChangeDate = DateTime.Now,
                idStatus = 0,
                idWorker = new WorkerRepository().getWorkerByLogin(newOrder.WorkerLogin).id
            });
        }
    }
}
