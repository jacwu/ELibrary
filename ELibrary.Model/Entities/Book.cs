using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Model.Entities
{
    public class Book
    {
        public Book()
        {
            Orders = new List<Order>();
            Tags = new List<Tag>();
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string AuthorName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int PublishYear { get; set; }
        [Required]
        public string ImageName { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
