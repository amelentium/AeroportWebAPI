using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Infrastructure.Contexts;
using AeroportWebApi.Repository.Interfaces.Repositories;

namespace AeroportWebApi.Repository.Repositories.Repositories
{
    public class AeroplaneRepository : GenericRepository<Aeroplane, int>, IAeroplaneRepository
    {
        public AeroplaneRepository(AeroDbContext context) : base(context)
        {

        }
    }
}
