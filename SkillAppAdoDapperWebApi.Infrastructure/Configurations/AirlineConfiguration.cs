using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillAppAdoDapperWebApi.DAL.Entities;

namespace SkillAppAdoDapperWebApi.Infrastructure.Configurations
{
    public class AirlineConfiguration : IEntityTypeConfiguration<Airline>
    {
        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            builder.HasMany(x => x.Aeroplanes).WithOne().OnDelete(DeleteBehavior.SetNull);
        }
    }
}
