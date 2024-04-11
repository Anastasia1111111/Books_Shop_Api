using Books_Shop_Api.Data;
using Books_Shop_Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books_Shop_Api.Controller
{
    public class BooksController:BaseShopController
    {
        private readonly DataContext _context;

        public BooksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<AppBooks>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        [HttpPost("add")]
        public async Task<ActionResult<AppBooks>> AddBook(AppBooks appBook)
        {
            var book = new AppBooks
            {
                AuthorId = appBook.AuthorId,
                Name = appBook.Name,
                Date_of_Publication = appBook.Date_of_Publication,
                Number_of_Pages = appBook.Number_of_Pages,
                Binding = appBook.Binding,
                Genre = appBook.Genre,
                Price = appBook.Price,
                Description = appBook.Description
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        [HttpPut("edit/{id}")]

        public async Task<ActionResult<AppBooks>> EditBook(AppBooks appBook, int id)
        {

            var bookCheck = _context.Books.Where(e => e.Id == id).AsNoTracking().FirstOrDefault();
            if (bookCheck is null)
                return BadRequest("Book object is null");
            var book = new AppBooks
            {
                Id = id,
                AuthorId = appBook.AuthorId,
                Name = appBook.Name,
                Date_of_Publication = appBook.Date_of_Publication,
                Number_of_Pages = appBook.Number_of_Pages,
                Binding = appBook.Binding,
                Genre = appBook.Genre,
                Price = appBook.Price,
                Description = appBook.Description
            };

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return book;
        }

        [HttpDelete("delete/{id}")]

        public async Task<ActionResult<AppBooks>> DeleteBook(int id)
        {

            var bookCheck = _context.Books.Where(e => e.Id == id).AsNoTracking().FirstOrDefault();
            if (bookCheck is null)
                return BadRequest("Author object is null");

            _context.Books.Remove(bookCheck);
            await _context.SaveChangesAsync();

            return bookCheck;
        }
    }
}
