using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELibrary.Web.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            var baseAddress = ConfigurationManager.AppSettings["ELibraryAPIEndPoint"];
            return View((object)(baseAddress + "api/library/orders"));
        }
    }
}