using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books_Shop_Api.Entities
{
    public class AppBooks
    {
        
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public AppAuthors? Author { get; set; }
        public string Name { get; set; }
        public DateTime Date_of_Publication { get; set; }
        public int Number_of_Pages { get; set; }
        public string Binding { get; set; }
        public string Genre { get; set;}
        public decimal Price { get; set; }
        public string Description { get; set; }

    }
}
