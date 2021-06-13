using AeroportWebApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AeroportWebApi.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasOne(x => x.Plane).WithMany();

            builder.HasOne(x => x.DepartFrom).WithMany();

            builder.HasOne(x => x.ArriveTo).WithMany();
        }
    }
}
