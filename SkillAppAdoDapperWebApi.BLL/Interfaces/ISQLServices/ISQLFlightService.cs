using SkillManagement.DataAccess.Entities.SQLEntities;
using System.Collections.Generic;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface ISQLFlightService
    {
        SQLFlight AddFlight(SQLFlight flight);

        SQLFlight UpdateFlight(SQLFlight flight, int Id);

        SQLFlight DeleteFlight(int id);

        SQLFlight GetFlightById(int Id);

        IEnumerable<SQLFlight> GetAllFlights();

        IEnumerable<SQLFlight> GetAllFlightsByPlaneId(int planeId);
        IEnumerable<SQLFlight> GetAllFlightsByDepartId(int aeroportId);
        IEnumerable<SQLFlight> GetAllFlightsByArriveId(int aeroportId);
    }
}
