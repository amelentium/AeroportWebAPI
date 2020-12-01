using Microsoft.EntityFrameworkCore;
using SkillAppAdoDapperWebApi.Infrastructure.Configurations;
using SkillManagement.DataAccess.Entities.SQLEntities;
using System.Linq;

namespace SkillAppAdoDapperWebApi.DAL.Infrastructure
{
    public class AeroDbContext : DbContext
    {
        public AeroDbContext(DbContextOptions<AeroDbContext> options) : base(options)
        { }

        public DbSet<SQLAeroplane> Aeroplanes { get; set; }
        public DbSet<SQLAeroport> Aeroports { get; set; }
        public DbSet<SQLFlight> Flights { get; set; }
        public DbSet<SQLPassenger> Passengers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new AeroportConfiguration());
            modelBuilder.ApplyConfiguration(new AeroplaneConfiguration());
        }
    }
}
