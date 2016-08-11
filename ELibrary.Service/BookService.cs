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
    public class BookService: IBookService
    {
        private IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public Book CreateBook(Book book)
        {
            return bookRepository.Add(book);
        }

        public void DeleteBookById(int id)
        {
            var book = bookRepository.GetById(id);
            bookRepository.Delete(book);
        }
    }
}
