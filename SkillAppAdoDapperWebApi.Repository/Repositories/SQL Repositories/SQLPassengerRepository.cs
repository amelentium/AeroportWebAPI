using Microsoft.Extensions.Configuration;
using SkillAppAdoDapperWebApi.DAL.Infrastructure;
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
        private readonly AeroDbContext _context;
        public SQLPassengerRepository(AeroDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SQLPassenger> GetAllPassengersByFlightId(int flightId)
        {
            return _context.Passengers.Where(e => e.Flight.Id == flightId);
        }
    }
}
