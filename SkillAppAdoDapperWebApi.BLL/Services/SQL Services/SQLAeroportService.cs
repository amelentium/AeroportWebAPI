using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Services
{
    public class SQLAeroportService : ISQLAeroportService
    {
        ISQLunitOfWork _sqlunitOfWork;
        public SQLAeroportService(ISQLunitOfWork sqlunitOfWork)
        {
            _sqlunitOfWork = sqlunitOfWork;
        }
        public SQLAeroport AddAeroport(SQLAeroport aeroport)
        {
            return _sqlunitOfWork.SQLAeroportRepository.Add(aeroport);
        }

        public SQLAeroport DeleteAeroport(int Id)
        {
            return _sqlunitOfWork.SQLAeroportRepository.Delete(Id);
        }

        public IEnumerable<SQLAeroport> GetAllAeroports()
        {
            return _sqlunitOfWork.SQLAeroportRepository.GetAll();
        }

        public SQLAeroport GetAeroportById(int Id)
        {
            return _sqlunitOfWork.SQLAeroportRepository.Get(Id);
        }

        public SQLAeroport UpdateAeroport(SQLAeroport aeroport, int Id)
        {
            return _sqlunitOfWork.SQLAeroportRepository.Update(aeroport, Id);
        }
    }
}
