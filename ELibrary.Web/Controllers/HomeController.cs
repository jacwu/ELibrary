using ELibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELibrary.Web.Controllers
{
    public class HomeController : Controller
    {
        private ITagService _tagService;
        public HomeController(ITagService tagService)
        {
            _tagService = tagService;
        }
        // GET: Home
        public ActionResult Index()
        {
            var tags = _tagService.AllTags;

            return View();
        }
    }
}