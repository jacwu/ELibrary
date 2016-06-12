using AutoMapper;
using ELibrary.Data.Infra;
using ELibrary.Model.Entities;
using ELibrary.Service;
using ELibrary.Web.ViewModels;
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
            ViewBag.TagOptions = GetTagOptions();
            return View();
        }

        private IEnumerable<SelectListItem> GetTagOptions()
        {
            var items = this._tagService.AllTags.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name
            }).OrderBy(x => x.Text);
            return items;
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                // Upload book cover image
                string uploadedPic = System.IO.Path.GetFileName(bookViewModel.CoverImg.FileName);
                string localPath = System.IO.Path.Combine(Server.MapPath("~/Content/BookImg"), uploadedPic);
                bookViewModel.CoverImg.SaveAs(localPath);

                // create book
                Book book = Mapper.Map<Book>(bookViewModel);
                book.Tags = bookViewModel.TagIds.SelectMany(id => this._tagService.AllTags.Where(tag => tag.Id == id)).ToList();
                book.ImageName = uploadedPic;
                this._bookService.CreateBook(book);
                this._unitOfWork.Commit();

                return RedirectToAction("Index", "Home");
            }

            ViewBag.TagOptions = GetTagOptions();
            return View(bookViewModel);
        }
    }
}