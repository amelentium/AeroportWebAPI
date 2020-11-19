using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System;
using Microsoft.Extensions.Configuration;
using SkillAppAdoDapperWebApi.DAL.Infrastructure;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLFlightRepository : GenericRepository<SQLFlight, int>, ISQLFlightRepository
    {
        public SQLFlightRepository(AeroDbContext context) : base(context)
        {

        }

        public IEnumerable<SQLFlight> GetAllFlightsByArriveId(int aeroportId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SQLFlight> GetAllFlightsByDepartId(int aeroportId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SQLFlight> GetAllFlightsByPlaneId(int planeId)
        {
            throw new NotImplementedException();
        }
    }
}
