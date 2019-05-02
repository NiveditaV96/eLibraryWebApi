using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using eLibrary1.Models;
using eLibrary1.Repository;
using eLibrary1.Filter;
using eLibrary1.BasicAuthentication;

namespace eLibrary1.Controllers
{
    [Logger]
    public class BooksController : ApiController
    {

        private eLibrary1Context db = new eLibrary1Context();

        IBookRepository _book;
        public BooksController(IBookRepository book)
        {
            _book = book;
        }

        // GET: api/Books
        [BasicAuthentication]
        public IQueryable<Book> GetBooks()
        {
            IQueryable<Book> book = _book.Get();
            return book;
            //return db.Books;
        }

        // GET: api/Books/5
        //[Route("api/Books/GetBook/{id}")]
        [ResponseType(typeof(Book))]
        [BasicAuthentication]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            //Book book = await db.Books.FindAsync(id);
            //if (book == null)
            //{
            //    return NotFound();
            //}

            //return Ok(book);

            Book books = await _book.GetByIdAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book books)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.Books.Add(books);
            //await db.SaveChangesAsync();

            //return CreatedAtRoute("DefaultApi", new { id = books.Id }, books);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _book.CreateAsync(books);

            return CreatedAtRoute("DefaultApi", new { id = books.Id }, books);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}