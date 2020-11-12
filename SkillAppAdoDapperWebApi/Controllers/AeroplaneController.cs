using Microsoft.AspNetCore.Mvc;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using System.Collections.Generic;

namespace SkillManagement.WebAPI.Controllers
{
    public class AeroplaneController : ControllerBase
    {
        #region Properties
        private readonly ISQLAeroplaneService _sqlAeroplaneService;
        #endregion

        #region Constructors
        public AeroplaneController(ISQLAeroplaneService sqlEmployeeService)
        {
            _sqlAeroplaneService = sqlEmployeeService;
        }
        #endregion

        #region APIs
        [Route("Aeroplanes")]
        [HttpGet]
        public IEnumerable<SQLAeroplane> Get()
        {
            return _sqlAeroplaneService.GetAllAeroplanes();
        }

        [Route("Aeroplane/{Id}")]
        [HttpGet]
        public SQLAeroplane Get(int Id)
        {
            return _sqlAeroplaneService.GetAeroplaneById(Id);
        }

        [Route("Aeroplane")]
        [HttpPost]
        public SQLAeroplane Post([FromBody]SQLAeroplane aeroplane)
        {
            return _sqlAeroplaneService.AddAeroplane(aeroplane);
        }

        [Route("Aeroplane/{Id}")]
        [HttpPut]
        public SQLAeroplane Put([FromBody]SQLAeroplane aeroplane, int Id)
        {
            return _sqlAeroplaneService.UpdateAeroplane(aeroplane, Id);
        }

        [Route("Aeroplane/{Id}")]
        [HttpDelete]
        public SQLAeroplane Delete(int Id)
        {
            return _sqlAeroplaneService.DeleteAeroplane(Id);
        }
        #endregion
    }
}
