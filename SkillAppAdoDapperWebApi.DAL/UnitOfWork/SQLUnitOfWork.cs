using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System;

namespace SkillManagement.DataAccess.sqlunitOfWork
{
    public class SQLsqlunitOfWork : ISQLunitOfWork
    {
        private readonly ISQLAeroplaneRepository _sqlAeroplaneRepository;
        private readonly ISQLPassengerRepository _sqlPassengerRepository;
        private readonly ISQLFlightRepository _sqlFlightRepository;
        private readonly ISQLAeroportRepository _sqlAeroportRepository;
        
        public SQLsqlunitOfWork(ISQLAeroplaneRepository sqlAeroplaneRepository,
            ISQLPassengerRepository sqlPassengerRepository,
            ISQLFlightRepository sqlFlightRepository,
            ISQLAeroportRepository sqlAeroportRepository)
        {
            _sqlAeroplaneRepository = sqlAeroplaneRepository;
            _sqlPassengerRepository = sqlPassengerRepository;
            _sqlFlightRepository = sqlFlightRepository;
            _sqlAeroportRepository = sqlAeroportRepository;
        }
        public ISQLAeroplaneRepository SQLAeroplaneRepository
        {
            get
            {
                return _sqlAeroplaneRepository;
            }
        }

        public ISQLPassengerRepository SQLPassengerRepository
        {
            get
            {
                return _sqlPassengerRepository;
            }
        }

        public ISQLFlightRepository SQLFlightRepository
        {
            get
            {
                return _sqlFlightRepository;
            }
        }

        public ISQLAeroportRepository SQLAeroportRepository
        {
            get
            {
                return _sqlAeroportRepository;
            }
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }
    }
}
