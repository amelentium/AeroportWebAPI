using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AeroportWebApi.Infrastructure.Contexts
{
    public class AeroDbContext : IdentityDbContext
    {
        public AeroDbContext(DbContextOptions<AeroDbContext> options) : base(options)
        { }

        public DbSet<Aeroplane> Aeroplanes { get; set; }
        public DbSet<Aeroport> Aeroports { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<CompanyPlane> CompanyPlanes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyPlaneConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new AirlineConfiguration());
            modelBuilder.ApplyConfiguration(new AeroportConfiguration());
            modelBuilder.ApplyConfiguration(new AeroplaneConfiguration());
        }
    }
}
