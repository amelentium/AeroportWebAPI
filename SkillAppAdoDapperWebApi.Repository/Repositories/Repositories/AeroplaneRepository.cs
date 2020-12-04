using SkillAppAdoDapperWebApi.DAL.Entities;
using SkillAppAdoDapperWebApi.Infrastructure.Contexts;
using SkillAppAdoDapperWebApi.Repository.Interfaces.Repositories;
using SkillManagement.DataAccess.Core;

namespace SkillManagement.DataAccess.Repositories
{
    public class AeroplaneRepository : GenericRepository<Aeroplane, int>, IAeroplaneRepository
    {
        public AeroplaneRepository(AeroDbContext context) : base(context)
        {

        }
    }
}
