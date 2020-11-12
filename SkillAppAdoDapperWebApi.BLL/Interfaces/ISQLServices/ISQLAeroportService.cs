using SkillManagement.DataAccess.Entities.SQLEntities;
using System.Collections.Generic;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface ISQLAeroportService
    {
        SQLAeroport AddAeroport(SQLAeroport aeroport);

        SQLAeroport UpdateAeroport(SQLAeroport aeroport, int Id);

        SQLAeroport DeleteAeroport(int Id);

        SQLAeroport GetAeroportById(int id);

        IEnumerable<SQLAeroport> GetAllAeroports();
    }
}
