using BookStore.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DataContext _context;
        public BookController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> CreateBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Book>>> UpdateBook(Book book)
        {
            var dbBook = await _context.Books.FindAsync(book.Id);
            if (dbBook == null)
            {
                return BadRequest("Book not found.");
            }

            dbBook.Title = book.Title;
            dbBook.Author = book.Author;
            dbBook.Description = book.Description;
            dbBook.ISBN = book.ISBN;
            dbBook.Pages = book.Pages;
            dbBook.Rating = book.Rating;

            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            var dbBook = await _context.Books.FindAsync(id);
            if (dbBook == null)
            {
                return BadRequest("Book not found.");
            }

            _context.Books.Remove(dbBook);

            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

    }
}
