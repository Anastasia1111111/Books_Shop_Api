using Books_Shop_Api.Data;
using Books_Shop_Api.Entities;
using Books_Shop_Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books_Shop_Api.Controller
{
    public class ClientsController:BaseShopController
    {
        private readonly DataContext _context;

        public ClientsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<AppClients>>> GetClients([FromQuery]ClientsParams clientParams)
        {
            var query = _context.Clients.AsQueryable();
            if (clientParams.fromClientsDateOfBirth != null && clientParams.toClientsDateOfBirth != null)
            {
                query = query.Where(u => u.Date_of_Birth >= clientParams.fromClientsDateOfBirth && u.Date_of_Birth <= clientParams.toClientsDateOfBirth);
            }

            if(clientParams.fromClientRegistrationDate !=null && clientParams.toClientRegistrationDate != null)
            {
                query = query.Where(u => u.Registration_Date >= clientParams.fromClientRegistrationDate && u.Registration_Date <= clientParams.toClientRegistrationDate);
            }

            if(clientParams.fromClientPersonalDiscount != null && clientParams.toClientPersonalDiscount != null)
            {
                query = query.Where(u => u.Personal_Discount >= clientParams.fromClientPersonalDiscount && u.Personal_Discount <= clientParams.toClientPersonalDiscount);
            }

            return await query.ToListAsync();
        }

        [HttpPost("add")]

        public async Task<ActionResult<AppClients>> AddClient(AppClients appClient)
        {
            var client = new AppClients
            {
                Name = appClient.Name,
                Patronymic = appClient.Patronymic,
                Surname = appClient.Surname,
                Date_of_Birth = appClient.Date_of_Birth,
                Personal_Discount = appClient.Personal_Discount,
                Registration_Date = appClient.Registration_Date
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return client;
        }

        [HttpPut("edit/{id}")]

        public async Task<ActionResult<AppClients>> EditClient(AppClients appClient, int id)
        {

            var clientCheck = _context.Clients.Where(e => e.Id == id).AsNoTracking().FirstOrDefault();
            if (clientCheck is null)
                return BadRequest("Book object is null");
            var client = new AppClients
            {
                Id = id,
                Name = appClient.Name,
                Patronymic = appClient.Patronymic,
                Surname = appClient.Surname,
                Date_of_Birth = appClient.Date_of_Birth,
                Personal_Discount = appClient.Personal_Discount,
                Registration_Date = appClient.Registration_Date
            };

            _context.Clients.Update(client);
            await _context.SaveChangesAsync();

            return client;
        }

        [HttpDelete("delete/{id}")]

        public async Task<ActionResult<AppClients>> DeleteClient(int id)
        {

            var clientCheck = _context.Clients.Where(e => e.Id == id).AsNoTracking().FirstOrDefault();
            if (clientCheck is null)
                return BadRequest("Client object is null");

            _context.Clients.Remove(clientCheck);
            await _context.SaveChangesAsync();

            return clientCheck;
        }
    }
}
