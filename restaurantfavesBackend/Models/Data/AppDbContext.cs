using Microsoft.EntityFrameworkCore;

namespace restaurantfavesBackend.Models.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<Order> Order { get; set; }
    }
}
