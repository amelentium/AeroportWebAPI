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
        private static readonly string _tableName = "Aeroplanes";
        public SQLAeroplaneRepository(IConnectionFactory connectionFactory, IConfiguration config, AeroDbContext context) : base(connectionFactory, _tableName, false, context)
        {
            var connectionString = config["connectionString:EFConnection"];
            connectionFactory.SetConnection(connectionString);
        }
    }
}
