using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillManagement.DataAccess.Entities.SQLEntities;

namespace SkillAppAdoDapperWebApi.Infrastructure.Configurations
{
	public class FlightConfiguration : IEntityTypeConfiguration<SQLFlight>
	{
		public void Configure(EntityTypeBuilder<SQLFlight> builder)
		{
            builder.HasOne(x => x.Plane).WithMany();

            builder.HasOne(x => x.DepartFrom).WithMany();

            builder.HasOne(x => x.ArriveTo).WithMany();
        }
	}
}
