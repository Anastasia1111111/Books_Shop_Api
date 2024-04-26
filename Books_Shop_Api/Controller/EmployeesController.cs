using Books_Shop_Api.Data;
using Books_Shop_Api.Entities;
using Books_Shop_Api.Helpers;
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

        public async Task<ActionResult<IEnumerable<AppEmployees>>> GetEmployees([FromQuery]EmployeesParams employeesParams)
        {
            var query = _context.Employees.AsQueryable();

            if(employeesParams.fromEmployeeDateOfBirth != null && employeesParams.toEmployeeDateOfBirth != null)
            {
                query = query.Where(u => u.Date_of_Birth >= employeesParams.fromEmployeeDateOfBirth && u.Date_of_Birth <= employeesParams.toEmployeeDateOfBirth); ;
            }

            if(employeesParams.fromEmployeeHiryDate != null && employeesParams.toEmployeeHiryDate != null)
            {
                query = query.Where(u => u.Hiry_Date >= employeesParams.fromEmployeeHiryDate && u.Hiry_Date <= employeesParams.toEmployeeHiryDate);
            }

            if (employeesParams.fromEmployeeDateOfDismissal != null && employeesParams.toEmployeeDateOfDismissal != null)
            {
                query = query.Where(u => u.Date_of_Dismissal >= employeesParams.fromEmployeeDateOfDismissal && u.Date_of_Dismissal <= employeesParams.toEmployeeDateOfDismissal);
            }

            if (employeesParams.employeeJobTitle != null)
            {
                query = query.Where(u => u.Job_Title == employeesParams.employeeJobTitle);
            }
            return await query.ToListAsync();
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
                Hiry_Date = appEmployee.Hiry_Date,
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
                Hiry_Date = appEmployee.Hiry_Date,
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
                return BadRequest("Employee object is null");

            _context.Employees.Remove(employeeCheck);
            await _context.SaveChangesAsync();

            return employeeCheck;
        }
    }
}
