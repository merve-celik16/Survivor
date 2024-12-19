using Microsoft.EntityFrameworkCore;
using Survivor.Data.Entities;

namespace Survivor.Data
{
    public class SurvivorDbContext :DbContext
    {
        public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options) : base(options) 
        {
        
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Competitor> Competitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Competitors)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}