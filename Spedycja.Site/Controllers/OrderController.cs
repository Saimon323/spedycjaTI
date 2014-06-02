using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spedycja.Model.Models;


namespace Spedycja.Site.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult NewOrder(OrderModel model)
        {
            return View();
        }

        public ActionResult OrderPhase2(JoinedClientsModel model)
        {
            return View();
        }

        public ActionResult OrderList()
        {
            return View();
        }

    }
}
