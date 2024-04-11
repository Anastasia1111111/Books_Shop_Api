using Books_Shop_Api.Data;
using Books_Shop_Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books_Shop_Api.Controller
{
    public class EmployeesController:BaseShopController
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<AppEmployees>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpPost("add")]

        public async Task<ActionResult<AppEmployees>> AddEmployee(AppEmployees appEmployee)
        {
            var employee = new AppEmployees
            {
                Name = appEmployee.Name,
                Patronymic = appEmployee.Patronymic,
                Surname = appEmployee.Surname,
                Date_of_Birth = appEmployee.Date_of_Birth,
                Hirу_Date = appEmployee.Hirу_Date,
                Date_of_Dismissal = appEmployee.Date_of_Dismissal,
                Job_Title = appEmployee.Job_Title
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        [HttpPut("edit/{id}")]

        public async Task<ActionResult<AppEmployees>> EditEmployees(AppEmployees appEmployee, int id)
        {

            var employeeCheck = _context.Clients.Where(e => e.Id == id).AsNoTracking().FirstOrDefault();
            if (employeeCheck is null)
                return BadRequest("Book object is null");

            var employee = new AppEmployees
            {
                Id =id,
                Name = appEmployee.Name,
                Patronymic = appEmployee.Patronymic,
                Surname = appEmployee.Surname,
                Date_of_Birth = appEmployee.Date_of_Birth,
                Hirу_Date = appEmployee.Hirу_Date,
                Date_of_Dismissal = appEmployee.Date_of_Dismissal,
                Job_Title = appEmployee.Job_Title
            };

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        [HttpDelete("delete/{id}")]

        public async Task<ActionResult<AppEmployees>> DeleteEmployee(int id)
        {

            var employeeCheck = _context.Employees.Where(e => e.Id == id).AsNoTracking().FirstOrDefault();
            if (employeeCheck is null)
                return BadRequest("Author object is null");

            _context.Employees.Remove(employeeCheck);
            await _context.SaveChangesAsync();

            return employeeCheck;
        }
    }
}
