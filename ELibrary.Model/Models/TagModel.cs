using System.Collections.Generic;

namespace ELibrary.Model.Models
{
    public class TagModel
    {
        public ICollection<LinkModel> Links { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public IEnumerable<BookBasicModel> Books { get; set; }
    }
}
