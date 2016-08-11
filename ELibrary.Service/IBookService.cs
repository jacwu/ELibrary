using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Service
{
    public interface IBookService
    {
        Book CreateBook(Book book);

        void DeleteBookById(int id);
    }
}
