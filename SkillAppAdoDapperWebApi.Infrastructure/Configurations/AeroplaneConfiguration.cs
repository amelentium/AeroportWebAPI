using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillManagement.DataAccess.Entities.SQLEntities;

namespace SkillAppAdoDapperWebApi.Infrastructure.Configurations
{
	public class AeroplaneConfiguration : IEntityTypeConfiguration<SQLAeroplane>
	{
		public void Configure(EntityTypeBuilder<SQLAeroplane> builder)
		{
			
		}
	}
}
