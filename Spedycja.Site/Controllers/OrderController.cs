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
using Newtonsoft.Json;

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
            if (ModelState.IsValid)
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

                #region Nowe zlecenie
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
                #endregion


                return RedirectToAction("OrderList", "Order");
            }

            return NewOrderRetry(model);
        }

        public ActionResult NewOrderRetry(OrderModel dataModel)
        {
            ViewBag.data = dataModel;

            return View();
        }

        public ActionResult OrderList()
        {
            return View();
        }

        public ActionResult EditOrder(int orderId)
        {
            IOrderRepository orderRepository = new OrderRepository();
            var order = orderRepository.getOrder(orderId);

            CustomerModel customer = new CustomerModel()
            {
                Name = order.Customer.Name,
                Surname = order.Customer.Surname,
                Address = order.Customer.Address,
                PhoneNumber = order.Customer.PhoneNumber,
                Firm = order.Customer.Firm
            };


            DriverModel driver = new DriverModel()
            {
                Name = (order.Driver != null) ? order.Driver.Name : string.Empty,
                Surname =  (order.Driver != null) ? order.Driver.Surname : string.Empty,
                Address = (order.Driver != null) ? order.Driver.Address : string.Empty,
                PhoneNumber = (order.Driver != null) ? order.Driver.PhoneNumber : string.Empty,
                Firm = (order.Driver != null) ? order.Driver.Firm : string.Empty
            };

            RouteModel route = new RouteModel()
            {
                StartPoint = order.Route.StartPoint,
                EndPoint = order.Route.EndPoint
            };

            LoadModel load = new LoadModel()
            {
                Name = order.Load.Name,
                LoadType = order.Load.TypesFreight.TypeName,
                Weight = order.Load.Weight ?? 0,
                Price = order.Load.Price ?? 0
            };
            VehicleModel vehicle = new VehicleModel()
            {
                Name = order.TypesVehicle.TypeName
            };


            OrderEditModel orderModel = new OrderEditModel()
            {
                load = load,
                vehicle = vehicle,
                route = route,
                customer = customer,
                driver = driver
            };

            ViewBag.Data = orderModel;
            var selectList = new List<SelectListItem>();
            foreach (var state in new StatusOrderRepository().GetAllStatus().ToList())
            {
                selectList.Add(new SelectListItem
                    {
                        Text = state.Status,
                        Value = state.id.ToString(),
                        Selected = (state.id == order.idStatus)
                    });
            }
            ViewBag.StateList = new SelectList(selectList, "Value", "Text");
            return View();
        }

        [HttpPost]
        public ActionResult EditOrder(OrderEditModel model)
        {
            return View();
        }

        public ActionResult DeleteOrder(int orderId)
        {
            IOrderRepository orderRepository = new OrderRepository();

            bool del = false;
            del = orderRepository.deleteOrder(orderId);

            if(del == true)
                return RedirectToAction("OrderList", "Order");

            else
                return RedirectToAction("OrderList", "Order", new { orderId = orderId });
        }

        public ActionResult OrderDetails(int id)
        {
            IOrderRepository orderRepository = new OrderRepository();

            var order = orderRepository.getOrder(id);

            //if (order.Driver == null)
            //    ViewBag.IsDriver = 0;
            //else if (order.Driver != null)
            //    ViewBag.IsDriver = 1;

            List<POIModel> RoutesList = new List<POIModel>();
            
            POIModel route = new POIModel("", order.Route.StartPoint, order.Route.StartLat.GetValueOrDefault(), order.Route.StartLong.GetValueOrDefault());
            RoutesList.Add(route);

            POIModel route2 = new POIModel("", order.Route.EndPoint, order.Route.EndLat.GetValueOrDefault(), order.Route.EndLong.GetValueOrDefault());
            RoutesList.Add(route2);

            ViewBag.map = RoutesList;

            return View(order);
        }

        public string OrderGridRead()
        {
            #region Deklaracje repozytoriow
            IOrderRepository orderRepository = new OrderRepository();
            ILoadRepository loadRepository = new LoadRepository();
            IRouteRepository routeRepository = new RouteRepository();
            IStatusOrderRepository statusOrderRepository = new StatusOrderRepository();
            ICustomerRepository customerRepository = new CustomerRepository();
            #endregion

            #region Wypelnianie OrderListModelu
            string orderName = "";
            string status = "";
            string from = "";
            string to = "";
            string customerInformation = "";
            DateTime date;
            #endregion

            List<OrderListModel> ordersListResult = new List<OrderListModel>();
            List<Order> orders = orderRepository.getAllOrders();
            foreach (var order in orders)
            {
                if(order.idLoad.HasValue)
                    orderName = loadRepository.getLoadNameById(order.idLoad.GetValueOrDefault());
                
                if(order.idStatus.HasValue)
                    status = statusOrderRepository.getStatusOrderNameById(order.idStatus.GetValueOrDefault());

                if (order.idRoutes.HasValue) {
                    Tuple<string, string> route = routeRepository.getRouteStartEndById(order.idRoutes.GetValueOrDefault());
                    from = route.Item1;
                    to = route.Item2;
                }

                if(order.idCustomer.HasValue)
                    customerInformation = customerRepository.getCustomerInformationById(order.idCustomer.GetValueOrDefault());

                date = order.CreatedAt;
                OrderListModel singleOrder = new OrderListModel
                {
                    id = order.id,
                    OrderName = orderName,
                    Status = status,
                    From = from,
                    To = to,
                    Customer = customerInformation,
                    Date = date
                };

                ordersListResult.Add(singleOrder);
            }

            return JsonConvert.SerializeObject(ordersListResult);

        }

    }
}
