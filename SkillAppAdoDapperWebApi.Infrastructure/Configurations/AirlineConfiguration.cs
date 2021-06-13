using AeroportWebApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AeroportWebApi.Infrastructure.Configurations
{
    public class AirlineConfiguration : IEntityTypeConfiguration<Airline>
    {
        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            builder.HasMany(x => x.Aeroplanes).WithOne().OnDelete(DeleteBehavior.SetNull);
        }
    }
}
