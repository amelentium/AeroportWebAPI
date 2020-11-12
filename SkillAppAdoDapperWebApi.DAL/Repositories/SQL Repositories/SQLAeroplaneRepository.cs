using System.Configuration;
using Microsoft.Extensions.Configuration;
using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLAeroplaneRepository : GenericRepository<SQLAeroplane, int>, ISQLAeroplaneRepository
    {
        private static readonly string _tableName = "Aeroplane";
        public SQLAeroplaneRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, _tableName, false)
        {
            var connectionString = config["connectionString:DefaultConnection"];
            connectionFactory.SetConnection(connectionString);
        }
    }
}
