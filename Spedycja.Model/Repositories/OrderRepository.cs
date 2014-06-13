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

        public Order getOrder(int id)
        {
            return Entities.Orders.FirstOrDefault(order => order.id == id);
        }

        public bool deleteOrder(int id)
        {
            try
            {
                Entities.Orders.Remove(getOrder(id));
                Entities.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public void updateOrder(EditOrderModel model)
        {
            Order order = getOrder(model.id);
            order.idStatus = model.idStatus;
            Load load = Entities.Loads.Where(x => x.id == order.idLoad).FirstOrDefault();
            TypesFreight typeFreight = Entities.TypesFreights.Where(x => x.id == load.IdType).FirstOrDefault();
            TypesVehicle typeVehicle = Entities.TypesVehicles.Where(x => x.id == order.idTypeVehicles).FirstOrDefault();
            Route route = Entities.Routes.Where(x => x.id == order.idRoutes).FirstOrDefault();
            Customer customer = Entities.Customers.Where(x => x.id == order.idCustomer).FirstOrDefault();
            Driver driver = Entities.Drivers.Where(x => x.id == order.idDriver).FirstOrDefault();

            load.Name = model.load.Name;
            load.Price = model.load.Price;
            load.Weight = model.load.Weight;

            typeFreight.TypeName = model.load.LoadType;

            typeVehicle.TypeName = model.vehicle.Name;

            if (model.route.StartPoint != null)
            {
                route.StartPoint = model.route.StartPoint;
                Tuple<double, double> from = Geocoding.GeocodingProvider.getLatLong(model.route.StartPoint);
                route.StartLat = from != null ? from.Item1 : 0;
                route.StartLong = from != null ? from.Item2 : 0;
            }

            if (model.route.EndPoint != null)
            {
                route.EndPoint = model.route.EndPoint;
                Tuple<double, double> to = Geocoding.GeocodingProvider.getLatLong(model.route.EndPoint);
                route.EndLat = to != null ? to.Item1 : 0;
                route.EndLong = to != null ? to.Item2 : 0;
            }

            customer.Name = model.customer.Name;
            customer.Surname = model.customer.Surname;
            customer.Address = model.customer.Address;
            customer.PhoneNumber = model.customer.PhoneNumber;
            customer.Firm = model.customer.Firm;

            if (driver != null) { 
                
                driver.Name = model.driver.Name;
                driver.Surname = model.driver.Surname;
                driver.Address = model.driver.Address;
                driver.PhoneNumber = model.driver.PhoneNumber;
                driver.Firm = model.driver.Firm;
            }
            else
            {
                Driver newDriver = new Driver
                {
                    Name = model.driver.Name,
                    Surname = model.driver.Surname,
                    Address = model.driver.Address,
                    PhoneNumber = model.driver.PhoneNumber,
                    Firm = model.driver.Firm
                };
                Entities.Drivers.Add(newDriver);
                Entities.SaveChanges();
                order.idDriver = newDriver.id;
            }


            Entities.SaveChanges();

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
