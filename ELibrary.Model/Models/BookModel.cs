using System.Collections.Generic;

namespace ELibrary.Model.Models
{
    public class BookModel
    {
        public ICollection<LinkModel> Links { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }
        public string ImageName { get; set; }
        public IEnumerable<TagBasicModel> Tags { get; set; }
    }
}
