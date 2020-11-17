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
        private static readonly string _tableName = "Aeroports";
        public SQLAeroportRepository(IConnectionFactory connectionFactory, IConfiguration config, AeroDbContext context) : base(connectionFactory, _tableName, false, context)
        {
            var connectionString = config["connectionString:EFConnection"];
            connectionFactory.SetConnection(connectionString);
        }
    }
}
