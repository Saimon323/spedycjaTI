using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult OrderPhase2()
        {
            return View();
        }

        public ActionResult OrderList()
        {
            return View();
        }

    }
}
