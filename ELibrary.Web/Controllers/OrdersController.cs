using ELibrary.Web.Filters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ELibrary.Web.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        // GET: Orders
        [SetAuthCookieFilter]
        public ActionResult Index()
        {

            var baseAddress = ConfigurationManager.AppSettings["ELibraryAPIEndPoint"];
            return View((object)(baseAddress + "api/library/orders"));
        }
    }
}