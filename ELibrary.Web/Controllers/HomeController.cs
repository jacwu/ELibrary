using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELibrary.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ELibrary.Data.ELibraryEntities entity = new Data.ELibraryEntities();
            entity.Books.ToList();

            return View();
        }
    }
}