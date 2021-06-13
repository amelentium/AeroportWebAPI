using AeroportWebApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AeroportWebApi.Infrastructure.Configurations
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
