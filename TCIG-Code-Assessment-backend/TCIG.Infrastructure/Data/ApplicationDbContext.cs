using Microsoft.EntityFrameworkCore;
using TCIG_Code_Assessment_backend.TCIG.Domain.Entities;

namespace TCIG_Code_Assessment_backend.TCIG.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
