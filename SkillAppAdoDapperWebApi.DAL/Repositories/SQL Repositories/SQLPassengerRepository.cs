using Dapper;
using Microsoft.Extensions.Configuration;
using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Repositories.SQL_Repositories
{
    public class SQLPassengerRepository : GenericRepository<SQLPassenger, int>, ISQLPassengerRepository
    {
        private static readonly string _tableName = "Passenger";
        public SQLPassengerRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, _tableName, false)
        {
            var connectionString = config["connectionString:DefaultConnection"];
            connectionFactory.SetConnection(connectionString);
        }

        public IEnumerable<SQLPassenger> GetAllPassengersByFlightId(int flightId)
        {
            var query = "SP_GetAllPassengersByFlightId";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<SQLPassenger>(query,
                    new { P_Id = flightId },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
