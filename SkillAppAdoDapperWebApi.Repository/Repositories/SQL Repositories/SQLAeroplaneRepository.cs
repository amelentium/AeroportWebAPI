using System.Configuration;
using Microsoft.Extensions.Configuration;
using SkillAppAdoDapperWebApi.DAL.Infrastructure;
using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLAeroplaneRepository : GenericRepository<SQLAeroplane, int>, ISQLAeroplaneRepository
    {
        public SQLAeroplaneRepository(AeroDbContext context) : base(context)
        {

        }
    }
}
