using Microsoft.EntityFrameworkCore;
using TCIG.Domain.Entities;

namespace TCIG.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<ProductModel> Products { get; set; }


    }
}
 