using Microsoft.EntityFrameworkCore;

namespace CloudWeather.Report.DataAccess
{
    public class WeatherReportDbContext : DbContext
    {
        public WeatherReportDbContext() { }
        public WeatherReportDbContext(DbContextOptions options) : base(options) { }

        public DbSet<WeatherReport> WeatherReports { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentitNames(modelBuilder);
        }

        private void SnakeCaseIdentitNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherReport>(b => { b.ToTable("weather_report"); });
        }
    }
}
