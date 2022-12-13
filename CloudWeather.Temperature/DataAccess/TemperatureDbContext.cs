using Microsoft.EntityFrameworkCore;

namespace CloudWeather.Temperature.DataAccess
{
    public class TemperatureDbContext : DbContext
    {
        public TemperatureDbContext() { }
        public TemperatureDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Temperature> Temperatures { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentitNames(modelBuilder);
        }

        private void SnakeCaseIdentitNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Temperature>(b => { b.ToTable("temperatures"); });
        }
    }
}
