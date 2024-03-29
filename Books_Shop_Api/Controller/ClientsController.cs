using Books_Shop_Api.Data;
using Books_Shop_Api.Entities;
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

        public async Task<ActionResult<IEnumerable<AppClients>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        [HttpPost("add")]

        public async Task<ActionResult<AppClients>> AddClient(AppClients appClient)
        {
            var client = new AppClients
            {
                Id = appClient.Id,
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
    }
}
