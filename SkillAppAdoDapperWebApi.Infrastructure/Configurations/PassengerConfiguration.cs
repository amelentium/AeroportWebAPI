using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillAppAdoDapperWebApi.DAL.Entities;

namespace SkillAppAdoDapperWebApi.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
	{
		public void Configure(EntityTypeBuilder<Passenger> builder)
		{
			builder.HasOne(p => p.Flight).WithMany();
		}
	}
}
