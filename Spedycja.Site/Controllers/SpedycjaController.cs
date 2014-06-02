using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spedycja.Site.Controllers
{
    public class SpedycjaController : Controller
    {
        //
        // GET: /Spedycja/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InProgress()
        {
            return View();
        }

    }
}
