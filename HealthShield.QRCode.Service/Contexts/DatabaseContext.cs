using HealthShield.QRCode.Service.Model;
using Microsoft.EntityFrameworkCore;

namespace HealthShield.QRCode.Service.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions)
            : base(dbContextOptions) { }

        public virtual DbSet<ParameterName> ParameterNames { get; set; }
        public virtual DbSet<ParameterValue> ParameterValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assemblyWithConfigurations = GetType().Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=QRCodeDatabase.db");
    }
}
