using SkillAppAdoDapperWebApi.DAL.Entities;
using SkillAppAdoDapperWebApi.Infrastructure.Contexts;
using SkillAppAdoDapperWebApi.Repository.Interfaces.Repositories;
using SkillManagement.DataAccess.Core;

namespace SkillManagement.DataAccess.Repositories
{
    public class AeroportRepository : GenericRepository<Aeroport, int>, IAeroportRepository
    {
        public AeroportRepository(AeroDbContext context) : base(context)
        {

        }
    }
}
