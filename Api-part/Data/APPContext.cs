using Microsoft.EntityFrameworkCore;
using Api_part.Model; // تأكد ان الـ namespace صحيح حسب مكان Models

namespace Api_part.Data
{
    public class APPContext : DbContext
    {
        public APPContext(DbContextOptions<APPContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}