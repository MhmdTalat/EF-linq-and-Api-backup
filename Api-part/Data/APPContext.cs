using Microsoft.EntityFrameworkCore;
namespace EFCore.Model
{
    public class APPContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        public APPContext(DbContextOptions<APPContext> options)
            : base(options) { }
    }
}