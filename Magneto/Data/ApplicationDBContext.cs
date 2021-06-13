using Magneto.Models;
using Microsoft.EntityFrameworkCore;

namespace Magneto.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }

        public DbSet<Mutant> Mutants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Mutant>()
                .HasIndex(m => m.DNA)
                .IsUnique();
        }
    }
}
