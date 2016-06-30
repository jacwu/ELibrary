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
        public ActionResult Index()
        {
            var token = (User.Identity as ClaimsIdentity)
                .FindFirst("access_token");

            if (token != null)
            {
                Response.SetCookie(new HttpCookie("access_token", token.Value));
            }

            var baseAddress = ConfigurationManager.AppSettings["ELibraryAPIEndPoint"];
            return View((object)(baseAddress + "api/library/orders"));
        }
    }
}