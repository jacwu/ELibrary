using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELibrary.API.Models
{
    public class BookUploadModel
    {
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string Description { get; set; }

        public int PublishYear { get; set; }

        public IEnumerable<int> TagIds { get; set; }

    }
}