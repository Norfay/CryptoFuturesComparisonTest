using Domain;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.Infra
{
    public class FuturesDbContext : DbContext
    {
        public DbSet<FuturesDeltaEntity> FuturesDeltaEntities { get; set; }

        public FuturesDbContext(DbContextOptions<FuturesDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuturesDeltaEntity>()
                .HasKey(e => e.Id); 
        }
    }
}
