using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Model.Entities
{
    public class Tag
    {
        public Tag()
        {
            Books = new List<Book>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageName { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}
