using Microsoft.EntityFrameworkCore;
using SkillManagement.DataAccess.Entities.SQLEntities;

namespace SkillAppAdoDapperWebApi.DAL.Infrastructure
{
    public class AeroContext : DbContext
    {
        public AeroContext(DbContextOptions<AeroContext> options) : base(options)
        { }

        public DbSet<SQLAeroplane> Aeroplanes { get; set; }
        public DbSet<SQLAeroport> Aeroports { get; set; }
        public DbSet<SQLFlight> Flights { get; set; }
        public DbSet<SQLPassenger> Passengers { get; set; }
    }
}
