using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillAppAdoDapperWebApi.DAL.Entities;

namespace SkillAppAdoDapperWebApi.Infrastructure.Configurations
{
    public class AeroportConfiguration : IEntityTypeConfiguration<Aeroport>
	{
		public void Configure(EntityTypeBuilder<Aeroport> builder)
		{
			
		}
	}
}
