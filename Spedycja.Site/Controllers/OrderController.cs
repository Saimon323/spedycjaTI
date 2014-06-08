using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Spedycja.Model.Models;
using Spedycja.Site.Models;
using Spedycja.Model.EntityModels;
using Spedycja.Model.Repositories.Interfaces;
using Spedycja.Model.Repositories;

namespace Spedycja.Site.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult NewOrder()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult NewOrder(OrderModel model)
        {
            #region Deklaracje repozytoriow
            ICustomerRepository customerRepository = new CustomerRepository();
            IRouteRepository routeRepository = new RouteRepository();
            IStatusHistoryRepository statusHistoryRepository = new StatusHistoryRepository();
            ILoadRepository loadRepository = new LoadRepository();
            IWorkerRepository workerRepository = new WorkerRepository();
            ITypesVehicleRepository typeVehicleRepository = new TypesVehicleRepository();
            ITypesFreightRepository typeFreightRepository = new TypesFreightRepository();
            IOrderRepository orderRepository = new OrderRepository();
            #endregion

            #region ID nowego rodzaju ladunku
            int typeFreightId = typeFreightRepository.CreateNewTypeFreightByOrder(new TypesFreight
            {
                TypeName = model.load.LoadType
            });
            #endregion

            #region ID nowego towaru
            int loadCreatedId = loadRepository.CreateLoadByOrder(new Load 
            { 
                Name = model.load.Name,
                Price = model.load.Price,
                Weight = model.load.Weight,
                IdType = typeFreightId
            });
            #endregion

            #region ID uzytkownika dodajacego zlecenie
            var cookie = Request.Cookies["LogOn"];
            int workerId = workerRepository.getWorkerIdByLogin(cookie.Value);
            #endregion

            #region ID statusu zlecenia
            int statusOrder = 1;
            #endregion

            #region ID nowego typu pojazdu
            int typeVehicleCreatedId = typeVehicleRepository.CreateTypeVehicleByOrder(new TypesVehicle
            {
                TypeName = model.vehicle.Name
            });
            #endregion

            #region ID nowego zleceniodawcy
            int customerCreatedId = customerRepository.CreateNewCustomerByOrder(new Customer
            {
                Name = model.customer.Name,
                Surname = model.customer.Surname,
                Address = model.customer.Address,
                PhoneNumber = model.customer.PhoneNumber,
                Firm = model.customer.Firm
            });
            #endregion

            #region ID nowej trasy 
            int routeCreatedId = routeRepository.CreateNewRouteByOrder(new Route
            {
                StartPoint = model.route.StartPoint,
                EndPoint = model.route.EndPoint
            });
            #endregion
            
            DateTime createdAt = DateTime.Now;

            Order order = new Order
            {
                idLoad = loadCreatedId,
                idWorker = workerId,
                idStatus = statusOrder,
                idTypeVehicles = typeVehicleCreatedId,
                idCustomer = customerCreatedId,
                idRoutes = routeCreatedId,
                CreatedAt = createdAt
            };

            int orderCreatedId = orderRepository.CreateNewOrder(order);
            statusHistoryRepository.AddStatusHistory(new StatusHistory
            {
                idStatus = 1,
                idWorker = workerId,
                ChangeDate = DateTime.Now,
                idOrder = orderCreatedId
            });

            
            return View();
        }

        //[HttpPost]
        //public ActionResult OrderPhase2(OrderModel model)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult NewOrderSuccess(JoinedClientsModel model)
        //{
        //    return View("OrderList");
        //}

        public ActionResult OrderList()
        {
            return View();
        }

    }
}
