using eLibrary1.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace eLibrary1.Repository
{
    public class BookRepository:IBookRepository
    {
        private static readonly ILog _log = LogManager.GetLogger("BookRepository");

        private eLibrary1Context db = new eLibrary1Context();
        public IQueryable<Book> Get()
        {
            _log.Info("Gets list of all books.");
            return db.Books;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            Book books = await db.Books.FindAsync(id);
            return books;
        }

        public async Task<Book> CreateAsync(Book books)
        {
            db.Books.Add(books);
            await db.SaveChangesAsync();

            return books;
        }
    }
}