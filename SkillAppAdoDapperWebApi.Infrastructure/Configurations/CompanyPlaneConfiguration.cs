using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillAppAdoDapperWebApi.DAL.Entities;

namespace SkillAppAdoDapperWebApi.Infrastructure.Configurations
{
    public class CompanyPlaneConfiguration : IEntityTypeConfiguration<CompanyPlane>
    {
        public void Configure(EntityTypeBuilder<CompanyPlane> builder)
        {
            builder.HasOne(x => x.Company).WithMany();

            builder.HasOne(x => x.Plane).WithMany();
        }
    }
}
