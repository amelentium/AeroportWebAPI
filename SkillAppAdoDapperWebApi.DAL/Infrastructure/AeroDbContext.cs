using Microsoft.EntityFrameworkCore;
using SkillManagement.DataAccess.Entities.SQLEntities;
using System.Linq;

namespace SkillAppAdoDapperWebApi.DAL.Infrastructure
{
    public class AeroDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AeroDbContext(DbContextOptions<AeroDbContext> options) : base(options)
        { }

        public DbSet<SQLAeroplane> Aeroplanes { get; set; }
        public DbSet<SQLAeroport> Aeroports { get; set; }
        public DbSet<SQLFlight> Flights { get; set; }
        public DbSet<SQLPassenger> Passengers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SQLFlight>()
                .HasOne(f => f.Plane)
                .WithMany();

            modelBuilder.Entity<SQLFlight>()
                .HasOne(f => f.DepartFrom)
                .WithMany();

            modelBuilder.Entity<SQLFlight>()
                .HasOne(f => f.ArriveTo)
                .WithMany();

            modelBuilder.Entity<SQLPassenger>()
                .HasOne(p => p.Flight)
                .WithMany();
        }
    }
}
