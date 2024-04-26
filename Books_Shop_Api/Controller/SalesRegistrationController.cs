using Books_Shop_Api.Data;
using Books_Shop_Api.Entities;
using Books_Shop_Api.Helpers;
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

        public async Task<ActionResult<IEnumerable<AppSalesRegistration>>> GetSalesRegistration([FromQuery]SalesRegistrationParams salesRegistrationParams)
        {
            var query = _context.SalesRegistration.AsQueryable();

            if(salesRegistrationParams.SaleRegistrationBookId != null)
            {
                query = query.Where(u => u.BookId == salesRegistrationParams.SaleRegistrationBookId);
            }

            if (salesRegistrationParams.SaleRegistrationClientId != null)
            {
                query = query.Where(u => u.ClientId == salesRegistrationParams.SaleRegistrationClientId);
            }

            if (salesRegistrationParams.SaleRegistrationEmployeeId != null)
            {
                query = query.Where(u => u.EmployeeId == salesRegistrationParams.SaleRegistrationEmployeeId);
            }

            if(salesRegistrationParams.fromSaleRegistrationDateOfPurchase != null && salesRegistrationParams.toSaleRegistrationDateOfPurchase != null)
            {
                query = query.Where(u => u.Date_of_Purchase >= salesRegistrationParams.fromSaleRegistrationDateOfPurchase && u.Date_of_Purchase <= salesRegistrationParams.toSaleRegistrationDateOfPurchase);
            }

            if (salesRegistrationParams.fromSaleRegistrationTheFinalPrice != null && salesRegistrationParams.toSaleRegistrationTheFinalPrice != null)
            {
                query = query.Where(u => u.TheFinalPrice >= salesRegistrationParams.fromSaleRegistrationTheFinalPrice && u.TheFinalPrice <= salesRegistrationParams.toSaleRegistrationTheFinalPrice);
            }
            return await query.ToListAsync();
        }

        [HttpPost("add")]

        public async Task<ActionResult<AppSalesRegistration>> AddSaleRegistration(AppSalesRegistration appSaleRegistration)
        {
            var saleRegistration = new AppSalesRegistration
            {
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

        [HttpPut("edit/{id}")]

        public async Task<ActionResult<AppSalesRegistration>> EditSaleRegistration(AppSalesRegistration appSaleRegistration, int id)
        {

            var saleregistrationCheck = _context.Clients.Where(e => e.Id == id).AsNoTracking().FirstOrDefault();
            if (saleregistrationCheck is null)
                return BadRequest("Book object is null");

            var saleRegistration = new AppSalesRegistration
            {
                Id = id,
                BookId = appSaleRegistration.BookId,
                EmployeeId = appSaleRegistration.EmployeeId,
                ClientId = appSaleRegistration.ClientId,
                Date_of_Purchase = appSaleRegistration.Date_of_Purchase,
                TheFinalPrice = appSaleRegistration.TheFinalPrice
            };

            _context.SalesRegistration.Update(saleRegistration);
            await _context.SaveChangesAsync();

            return saleRegistration;
        }

        [HttpDelete("delete/{id}")]

        public async Task<ActionResult<AppSalesRegistration>> DeleteSaleRegistration(int id)
        {

            var saleRegistrationCheck = _context.SalesRegistration.Where(e => e.Id == id).AsNoTracking().FirstOrDefault();
            if (saleRegistrationCheck is null)
                return BadRequest("SaleRegistration object is null");

            _context.SalesRegistration.Remove(saleRegistrationCheck);
            await _context.SaveChangesAsync();

            return saleRegistrationCheck;
        }
    }
}
