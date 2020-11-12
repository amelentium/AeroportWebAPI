using SkillManagement.DataAccess.Entities.SQLEntities;
using System.Collections.Generic;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface ISQLAeroplaneService
    {
        SQLAeroplane AddAeroplane(SQLAeroplane aeroplane);

        SQLAeroplane UpdateAeroplane(SQLAeroplane aeroplane, int Id);

        SQLAeroplane DeleteAeroplane(int Id);

        SQLAeroplane GetAeroplaneById(int Id);

        IEnumerable<SQLAeroplane> GetAllAeroplanes();
    }
}
