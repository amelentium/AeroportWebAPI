using SkillManagement.DataAccess.Entities.SQLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLServices
{
    public interface ISQLPassengerService
    {
        SQLPassenger AddPassenger(SQLPassenger passenger);

        SQLPassenger UpdatePassenger(SQLPassenger passenger, int Id);

        SQLPassenger DeletePassenger(int Id);

        SQLPassenger GetPassengerById(int Id);

        IEnumerable<SQLPassenger> GetAllPassengers();

        IEnumerable<SQLPassenger> GetAllPassengersByFlightId(int flightId);
    }
}
