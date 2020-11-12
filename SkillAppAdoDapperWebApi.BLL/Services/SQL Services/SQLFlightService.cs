using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Services
{
    public class SQLFlightService : ISQLFlightService
    {
        ISQLunitOfWork _SqlsqlunitOfWork;
        public SQLFlightService(ISQLunitOfWork sqlunitOfWork)
        {
            _SqlsqlunitOfWork = sqlunitOfWork;
        }
        public SQLFlight AddFlight(SQLFlight flight)
        {
            return _SqlsqlunitOfWork.SQLFlightRepository.Add(flight);
        }

        public SQLFlight DeleteFlight(int Id)
        {
            return _SqlsqlunitOfWork.SQLFlightRepository.Delete(Id);
        }

        public IEnumerable<SQLFlight> GetAllFlights()
        {
            return _SqlsqlunitOfWork.SQLFlightRepository.GetAll();
        }

        public IEnumerable<SQLFlight> GetAllFlightsByArriveId(int aeroportId)
        {
            return _SqlsqlunitOfWork.SQLFlightRepository.GetAllFlightsByArriveId(aeroportId);
        }

        public IEnumerable<SQLFlight> GetAllFlightsByDepartId(int aeroportId)
        {
            return _SqlsqlunitOfWork.SQLFlightRepository.GetAllFlightsByDepartId(aeroportId);
        }

        public IEnumerable<SQLFlight> GetAllFlightsByPlaneId(int planeId)
        {
            return _SqlsqlunitOfWork.SQLFlightRepository.GetAllFlightsByPlaneId(planeId);
        }

        public SQLFlight GetFlightById(int Id)
        {
            return _SqlsqlunitOfWork.SQLFlightRepository.Get(Id);
        }

        public SQLFlight UpdateFlight(SQLFlight flight, int Id)
        {
            return _SqlsqlunitOfWork.SQLFlightRepository.Update(flight, Id);
        }
    }
}
