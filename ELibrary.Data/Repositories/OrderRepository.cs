using ELibrary.Data.Infra;
using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<Order> GetOpenOrders(string userName);
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory)
            : base(dbFactory) { }


        public IQueryable<Order> GetOpenOrders(string userName)
        {
            return DbContext.Orders.Include("Book").Where(f => f.CloseDate == null && f.UserName == userName);
        }

    }
}
