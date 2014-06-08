using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spedycja.Model.EntityModels;
using Spedycja.Model.Models;
using Spedycja.Model.Repositories;
using Spedycja.Model.Repositories.Interfaces;




namespace Spedycja.Model.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public int CreateNewOrder(Order order)
        {
            Entities.Orders.Add(order);
            Entities.SaveChanges();
            return order.id;
        }

        public List<Order> getAllOrders()
        {
            return Entities.Orders.ToList();
        }
        //public void AddNewOrder(OrderModel newOrder)
        //{
        //    Order order = new Order();
        //    order.CreatedAt = DateTime.Now;
        //    if(newOrder.CustomerId.HasValue)
        //    {
        //        order.Customer = new CustomerRepository().GetCustomerById(newOrder.CustomerId.Value);
        //    }
        //    order.Worker = new WorkerRepository().getWorkerByLogin(newOrder.WorkerLogin);
        //    order.TypesVehicle = new TypesVehicleRepository().GetTypesVehicleById(newOrder.VehicleType);
        //    if(newOrder.DriverId.HasValue)
        //    {
        //        order.Driver = new DriverRepository().GetDriverById(newOrder.DriverId.Value);
        //    }
        //    order.Load = new Load()
        //    {
        //        IdType = newOrder.CargoType,
        //        Name = newOrder.CargoName,
        //        Price = newOrder.Price,
        //        TypesFreight = new TypesFreightRepository().GetTypesFreightById(newOrder.CargoType),
        //        Weight = newOrder.Weight
        //    };
        //    string startPoint = newOrder.StartCountry + ";" + newOrder.StartCity + ";" + newOrder.StartStreet;
        //    string endPoint = newOrder.EndCountry + ";" + newOrder.EndCity + ";" + newOrder.EndStreet;
        //    order.Route = new Route()
        //    {
        //        StartPoint = startPoint,
        //        EndPoint = endPoint
        //    };
        //    order.StatusOrder = new StatusOrderRepository().GetStatusOrderById(1);
        //    order.StatusHistories.Add(new StatusHistory()
        //    {
        //        ChangeDate = DateTime.Now,
        //        idStatus = 0,
        //        idWorker = new WorkerRepository().getWorkerByLogin(newOrder.WorkerLogin).id
        //    });
        //}
    }
}
