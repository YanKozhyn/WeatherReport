using Microsoft.EntityFrameworkCore;
using Npgsql.NameTranslation;

namespace CloudWeather.Precipitation.DataAccess
{
    public class PrecipDbContext : DbContext
    {
        public PrecipDbContext() { }
        public PrecipDbContext(DbContextOptions opts) : base(opts) { }
        public DbSet<Precipitation> Precipitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentitNames(modelBuilder);
        }

        private void SnakeCaseIdentitNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Precipitation>(b => { b.ToTable("precipitations"); });
        }
    }
}
