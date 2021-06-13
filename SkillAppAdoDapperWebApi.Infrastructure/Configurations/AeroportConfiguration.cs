using AeroportWebApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AeroportWebApi.Infrastructure.Configurations
{
    public class AeroportConfiguration : IEntityTypeConfiguration<Aeroport>
    {
        public void Configure(EntityTypeBuilder<Aeroport> builder)
        {

        }
    }
}
