using System.ComponentModel.DataAnnotations;

namespace Books_Shop_Api.Entities
{
    public class AppClients
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public string Surname { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public decimal Personal_Discount { get; set; }
        public DateTime Registration_Date { get; set; }
    }
}
