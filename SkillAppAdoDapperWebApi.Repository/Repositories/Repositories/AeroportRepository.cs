using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Infrastructure.Contexts;
using AeroportWebApi.Repository.Interfaces.Repositories;

namespace AeroportWebApi.Repository.Repositories.Repositories
{
    public class AeroportRepository : GenericRepository<Aeroport, int>, IAeroportRepository
    {
        public AeroportRepository(AeroDbContext context) : base(context)
        {

        }
    }
}
