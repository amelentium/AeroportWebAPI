using SkillManagement.DataAccess.Entities.SQLEntities;
using System.Collections.Generic;

namespace SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories
{
    public interface ISQLFlightRepository : IGenericRepository<SQLFlight, int>
    {
        IEnumerable<SQLFlight> GetAllFlightsByPlaneId(int planeId);
        IEnumerable<SQLFlight> GetAllFlightsByDepartId(int aeroportId);
        IEnumerable<SQLFlight> GetAllFlightsByArriveId(int aeroportId);
    }
}
