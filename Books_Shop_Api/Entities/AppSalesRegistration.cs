using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books_Shop_Api.Entities
{
    public class AppSalesRegistration
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public DateTime Date_of_Purchase { get; set; }
        public decimal TheFinalPrice { get; set; }
    }
}
