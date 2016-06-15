using ELibrary.Data.Infra;
using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ELibrary.Data
{
    public interface ITagRepository : IRepository<Tag>
    {
        IEnumerable<Tag> GetTagsForBook(int bookId);
        Tag GetTagWithBooks(int id, bool availableBookOnly = true);

    }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Tag GetTagWithBooks(int id, bool availableBookOnly = true)
        {
            if (availableBookOnly)
            {
                var dbquery = DbContext.Tags.Where(t => t.Id == id).Select(
                    t => new
                    {
                        t,
                        Books = t.Books.Where(b => b.Orders.Where(o => o.CloseDate == null).Count() == 0)
                    }).SingleOrDefault();

                dbquery.t.Books = dbquery.Books as ICollection<Book>;

                return dbquery.t;
            }
            else
            {
                return DbContext.Tags.Include("Books").Where(t => t.Id == id).FirstOrDefault();
            }
        }

        public IEnumerable<Tag> GetTagsForBook(int bookId)
        {
            return DbContext.Books.Include("Tags").SingleOrDefault(b => b.Id == bookId).Tags;
        }
    }
}
