using Microsoft.AspNetCore.Mvc;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using System.Collections.Generic;

namespace SkillManagement.WebAPI.Controllers
{
    public class AeroportController : ControllerBase
    {
        #region Properties
        private readonly ISQLAeroportService _sqlAeroportService;
        #endregion

        #region Constructors
        public AeroportController(ISQLAeroportService aeroportService)
        {
            _sqlAeroportService = aeroportService;
        }
        #endregion

        #region APIs
        [Route("Aeroports")]
        [HttpGet]
        public IEnumerable<SQLAeroport> Get()
        {
            return _sqlAeroportService.GetAllAeroports();
        }

        [Route("Aeroport/{Id}")]
        [HttpGet]
        public SQLAeroport Get(int Id)
        {
            return _sqlAeroportService.GetAeroportById(Id);
        }

        [Route("Aeroport")]
        [HttpPost]
        public SQLAeroport Post([FromBody] SQLAeroport aeroport)
        {
            return _sqlAeroportService.AddAeroport(aeroport);
        }

        [Route("Aeroport/{Id}")]
        [HttpPut]
        public SQLAeroport Put([FromBody] SQLAeroport aeroport, int Id)
        {
            return _sqlAeroportService.UpdateAeroport(aeroport, Id);
        }

        [Route("Aeroport/{Id}")]
        [HttpDelete]
        public SQLAeroport Delete(int Id)
        {
            return _sqlAeroportService.DeleteAeroport(Id);
        }
        #endregion
    }
}
