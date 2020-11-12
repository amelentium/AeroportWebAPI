using System.Collections.Generic;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;

namespace SkillManagement.DataAccess.Services
{
    public class SQLAeroplaneService : ISQLAeroplaneService
    {
        ISQLunitOfWork _SqlsqlunitOfWork;
        public SQLAeroplaneService(ISQLunitOfWork sqlsqlunitOfWork)
        {
            _SqlsqlunitOfWork = sqlsqlunitOfWork;
        }

        public SQLAeroplane AddAeroplane(SQLAeroplane aeroplane)
        {
            return _SqlsqlunitOfWork.SQLAeroplaneRepository.Add(aeroplane);
        }

        public SQLAeroplane DeleteAeroplane(int Id)
        {
            return _SqlsqlunitOfWork.SQLAeroplaneRepository.Delete(Id);
        }

        public IEnumerable<SQLAeroplane> GetAllAeroplanes()
        {
            return _SqlsqlunitOfWork.SQLAeroplaneRepository.GetAll();
        }

        public SQLAeroplane GetAeroplaneById(int Id)
        {
            return _SqlsqlunitOfWork.SQLAeroplaneRepository.Get(Id);
        }

        public SQLAeroplane UpdateAeroplane(SQLAeroplane aeroplane, int Id)
        {
            return _SqlsqlunitOfWork.SQLAeroplaneRepository.Update(aeroplane, Id);
        }
    }
}
