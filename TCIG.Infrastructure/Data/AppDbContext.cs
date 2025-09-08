using Microsoft.EntityFrameworkCore;
using TCIG.Domain.Entities;

namespace TCIG.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<ProductModel> Products { get; set; }

    }
}
 