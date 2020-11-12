using Dapper;
using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System;
using Microsoft.Extensions.Configuration;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLFlightRepository : GenericRepository<SQLFlight, int>, ISQLFlightRepository
    {
        private static readonly string _tableName = "Flight";
        public SQLFlightRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, _tableName, false)
        {
            var connectionString = config["connectionString:DefaultConnection"];
            connectionFactory.SetConnection(connectionString);
        }

        public IEnumerable<SQLFlight> GetAllFlightsByArriveId(int aeroportId)
        {
            var query = "SP_GetAllFlightsByArriveId";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<SQLFlight>(query,
                    new { P_Id = aeroportId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<SQLFlight> GetAllFlightsByDepartId(int aeroportId)
        {
            var query = "SP_GetAllFlightsByDepartId";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<SQLFlight>(query,
                    new { P_Id = aeroportId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<SQLFlight> GetAllFlightsByPlaneId(int planeId)
        {
            var query = "SP_GetAllFlightsByPlaneId";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<SQLFlight>(query,
                    new { P_Id = planeId },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
