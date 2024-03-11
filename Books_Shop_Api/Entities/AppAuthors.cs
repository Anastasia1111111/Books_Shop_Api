using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Books_Shop_Api.Entities
{
    public class AppAuthors
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public string Surname { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string biography { get; set; }
        public string? awards { get; set; }
    }
}
