using Books_Shop_Api.Entities;
using Microsoft.EntityFrameworkCore;
namespace Books_Shop_Api.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        
        }

        public DbSet<AppAuthors> Authors { get; set; }
        public DbSet<AppBooks> Books { get; set; }
        public DbSet<AppClients> Clients { get; set; }  
        public DbSet<AppEmployees> Employees { get; set; }
        public DbSet<AppSalesRegistration> SalesRegistration { get; set; }
    }
}
