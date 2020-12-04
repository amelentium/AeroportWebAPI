using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillAppAdoDapperWebApi.DAL.Entities;

namespace SkillAppAdoDapperWebApi.Infrastructure.Configurations
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
