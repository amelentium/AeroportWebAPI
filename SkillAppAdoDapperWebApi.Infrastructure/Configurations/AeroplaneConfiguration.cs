using AeroportWebApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AeroportWebApi.Infrastructure.Configurations
{
    public class AeroplaneConfiguration : IEntityTypeConfiguration<Aeroplane>
    {
        public void Configure(EntityTypeBuilder<Aeroplane> builder)
        {

        }
    }
}
