using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELibrary.Web.ViewModels
{
    public class BookViewModel
    {
        public string Title { get; set; }
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Publish Year")]
        public int PublishYear { get; set; }
        [Display(Name = "Cover")]
        public HttpPostedFileBase CoverImg { get; set; }
        [Display(Name = "Category")]
        public IEnumerable<int> TagIds { get; set; }
    }
}