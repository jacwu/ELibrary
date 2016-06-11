using ELibrary.Data.Infra;
using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Data.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
    }

    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}
