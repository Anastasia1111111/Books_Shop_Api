using Books_Shop_Api.Data;
using Books_Shop_Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books_Shop_Api.Controller
{
    public class AuthorsController:BaseShopController
    {
        private readonly DataContext _context;
        public AuthorsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<AppAuthors>>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        [HttpPost("add")]

        public async Task<ActionResult<AppAuthors>> AddAuthor(AppAuthors appAuthor)
        {
            var author = new AppAuthors
            {
                Name = appAuthor.Name,
                Patronymic = appAuthor.Patronymic,
                Surname = appAuthor.Surname,
                Date_of_Birth = appAuthor.Date_of_Birth,
                Date_of_death = appAuthor.Date_of_death,
                biography = appAuthor.biography,
                awards = appAuthor.awards
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return author;
        }

        //[HttpPut("edit")]

    }
}
