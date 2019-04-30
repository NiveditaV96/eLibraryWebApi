using eLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLibrary1.Repository
{
    public interface IBookRepository
    {
        IQueryable<Book> Get();
        Task<Book> GetByIdAsync(int id);
        Task<Book> CreateAsync(Book books);
    }
}
