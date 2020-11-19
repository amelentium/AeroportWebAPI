using Microsoft.Extensions.Configuration;
using SkillAppAdoDapperWebApi.DAL.Infrastructure;
using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System.Configuration;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLAeroportRepository : GenericRepository<SQLAeroport, int>, ISQLAeroportRepository
    {
        public SQLAeroportRepository(AeroDbContext context) : base(context)
        {

        }
    }
}
