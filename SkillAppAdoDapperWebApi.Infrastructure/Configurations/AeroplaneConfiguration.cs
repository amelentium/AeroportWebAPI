using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillAppAdoDapperWebApi.DAL.Entities;

namespace SkillAppAdoDapperWebApi.Infrastructure.Configurations
{
    public class AeroplaneConfiguration : IEntityTypeConfiguration<Aeroplane>
	{
		public void Configure(EntityTypeBuilder<Aeroplane> builder)
		{
			
		}
	}
}
