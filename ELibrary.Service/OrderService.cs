using ELibrary.Data.Repositories;
using ELibrary.Model.Entities;
using System;
using System.Linq;

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


        public IQueryable<Order> GetOpenOrders(string userName)
        {
            return orderRepository.GetOpenOrders(userName);
        }
    }
}
