using Microsoft.EntityFrameworkCore;
using SkillAppAdoDapperWebApi.DAL.Entities;
using SkillAppAdoDapperWebApi.Infrastructure.Configurations;

namespace SkillAppAdoDapperWebApi.Infrastructure.Contexts
{
    public class AeroDbContext : DbContext
    {
        public AeroDbContext(DbContextOptions<AeroDbContext> options) : base(options)
        { }

        public DbSet<Aeroplane> Aeroplanes { get; set; }
        public DbSet<Aeroport> Aeroports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

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
