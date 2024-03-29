using Books_Shop_Api.Data;
using Books_Shop_Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books_Shop_Api.Controller
{
    public class SalesRegistrationController:BaseShopController
    {
        private readonly DataContext _context;

        public SalesRegistrationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<AppSalesRegistration>>> GetSalesRegistration()
        {
            return await _context.SalesRegistration.ToListAsync();
        }

        [HttpPost("add")]

        public async Task<ActionResult<AppSalesRegistration>> AddSaleRegistration(AppSalesRegistration appSaleRegistration)
        {
            var saleRegistration = new AppSalesRegistration
            {
                Id = appSaleRegistration.Id,
                BookId = appSaleRegistration.BookId,
                EmployeeId = appSaleRegistration.EmployeeId,
                ClientId = appSaleRegistration.ClientId,
                Date_of_Purchase = appSaleRegistration.Date_of_Purchase,
                TheFinalPrice = appSaleRegistration.TheFinalPrice
            };

            _context.SalesRegistration.Add(saleRegistration);
            await _context.SaveChangesAsync();

            return saleRegistration;
        }
    }
}
