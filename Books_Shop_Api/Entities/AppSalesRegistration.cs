using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books_Shop_Api.Entities
{
    public class AppSalesRegistration
    {
        
        public int Id { get; set; }
        public int BookId { get; set; }
        public AppBooks? Book { get; set; }
        public int EmployeeId { get; set; }
        public AppEmployees? Employee { get; set; }
        public int ClientId { get; set; }
        public AppClients? Client { get; set; }
        public DateTime Date_of_Purchase { get; set; }
        public decimal TheFinalPrice { get; set; }
    }
}
