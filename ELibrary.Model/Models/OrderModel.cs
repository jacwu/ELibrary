using System;
using System.Collections.Generic;

namespace ELibrary.Model.Models
{
    public class OrderModel
    {
        public ICollection<LinkModel> Links { get; set; }
        public string OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string UserName { get; set; }
        public BookBasicModel Book { get; set; }
    }
}
