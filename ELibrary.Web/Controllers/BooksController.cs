using ELibrary.Data.Infra;
using ELibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELibrary.Web.Controllers
{
    public class BooksController : Controller
    {
        private IBookService _bookService;
        private ITagService _tagService;
        private IUnitOfWork _unitOfWork;

        public BooksController(IBookService bookService,
            ITagService tagService,
            IUnitOfWork unitOfWork)
        {
            this._bookService = bookService;
            this._tagService = tagService;
            this._unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}