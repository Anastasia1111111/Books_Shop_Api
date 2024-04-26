using AutoMapper;
using Books_Shop_Api.Data;
using Books_Shop_Api.Entities;
using Books_Shop_Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books_Shop_Api.Controller
{
    public class AuthorsController : BaseShopController
    {
        private readonly DataContext _context;
        public AuthorsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<AppAuthors>>> GetAuthors([FromQuery]AuthorsParams authorsParams)
        {
            var query = _context.Authors.AsQueryable();
            if(authorsParams.fromAuthorDateOfBirth != null && authorsParams.toAuthorDateOfBirth != null)
            {
                query = query.Where(u => u.Date_of_Birth >=  authorsParams.fromAuthorDateOfBirth && u.Date_of_Birth <= authorsParams.toAuthorDateOfBirth);
            }

            if(authorsParams.fromAuthorDateOfDeath != null && authorsParams.toAuthorDateOfDeath != null)
            {
                query = query.Where(u => u.Date_of_death >= authorsParams.fromAuthorDateOfDeath && u.Date_of_death <= authorsParams.toAuthorDateOfDeath);
            }

            return await query.ToListAsync();
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

        [HttpPut("edit/{id}")]

        public async Task<ActionResult<AppAuthors>> EditAuthor(AppAuthors appAuthor, int id)
        {

            var authorCheck = _context.Authors.Where(e => e.Id == id).AsNoTracking().FirstOrDefault();
            if (authorCheck is null)
                return BadRequest("Author object is null");

            var author = new AppAuthors
            {
                Id = id,
                Name = appAuthor.Name,
                Patronymic = appAuthor.Patronymic,
                Surname = appAuthor.Surname,
                Date_of_Birth = appAuthor.Date_of_Birth,
                Date_of_death = appAuthor.Date_of_death,
                biography = appAuthor.biography,
                awards = appAuthor.awards
            };

            _context.Authors.Update(author);
            await _context.SaveChangesAsync();

            return author;
        }

        [HttpDelete("delete/{id}")]

        public async Task<ActionResult<AppAuthors>> DeleteAuthor(int id)
        {

            var authorCheck = _context.Authors.Where(e => e.Id == id).AsNoTracking().FirstOrDefault();
            if (authorCheck is null)
                return BadRequest("Author object is null");

            _context.Authors.Remove(authorCheck);
            await _context.SaveChangesAsync();

            return authorCheck;
        }

    }
}
