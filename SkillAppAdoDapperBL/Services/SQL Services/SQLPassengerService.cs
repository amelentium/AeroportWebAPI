using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Services.SQL_Services
{
    public class SQLPassengerService : ISQLPassengerService
    {
        ISQLunitOfWork _SqlsqlunitOfWork;
        public SQLPassengerService(ISQLunitOfWork sqlsqlunitOfWork)
        {
            _SqlsqlunitOfWork = sqlsqlunitOfWork;
        }
        public SQLPassenger AddPassenger(SQLPassenger passenger)
        {
            return _SqlsqlunitOfWork.SQLPassengerRepository.Add(passenger);
        }

        public SQLPassenger DeletePassenger(int Id)
        {
            return _SqlsqlunitOfWork.SQLPassengerRepository.Delete(Id);
        }

        public IEnumerable<SQLPassenger> GetAllPassengers()
        {
            return _SqlsqlunitOfWork.SQLPassengerRepository.GetAll();
        }

        public IEnumerable<SQLPassenger> GetAllPassengersByFlightId(int flightId)
        {
            return _SqlsqlunitOfWork.SQLPassengerRepository.GetAllPassengersByFlightId(flightId);
        }

        public SQLPassenger GetPassengerById(int Id)
        {
            return _SqlsqlunitOfWork.SQLPassengerRepository.Get(Id);
        }

        public SQLPassenger UpdatePassenger(SQLPassenger passenger, int Id)
        {
            return _SqlsqlunitOfWork.SQLPassengerRepository.Update(passenger, Id);
        }
    }
}
