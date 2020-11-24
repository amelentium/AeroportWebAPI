using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillManagement.DataAccess.Entities.SQLEntities;

namespace SkillAppAdoDapperWebApi.Infrastructure.Configurations
{
	public class AeroportConfiguration : IEntityTypeConfiguration<SQLAeroport>
	{
		public void Configure(EntityTypeBuilder<SQLAeroport> builder)
		{
			
		}
	}
}
