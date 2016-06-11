using ELibrary.Data;
using ELibrary.Data.Repositories;
using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository;
        private IBookRepository bookRepository;

        public OrderService(IOrderRepository orderRepository, IBookRepository bookRepository)
        {
            this.orderRepository = orderRepository;
            this.bookRepository = bookRepository;
        }
    }
}
