using Microsoft.AspNetCore.Mvc;
using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using SkillAppAdoDapperWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.WEBAPI.Controllers
{
    public class AeroplaneController : ControllerBase
    {
        #region Properties
        private readonly IAeroplaneService _aeroplaneService;
        #endregion

        #region Constructors
        public AeroplaneController(IAeroplaneService aeroplaneService)
        {
            _aeroplaneService = aeroplaneService;
        }
        #endregion

        #region APIs
        [Route("Aeroplane")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Aeroplane aeroplane)
        {
            await _aeroplaneService.AddAeroplane(aeroplane);
            return Ok();
        }

        [Route("Aeroplane/{Id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _aeroplaneService.GetAeroplaneById(Id);
            return Ok(result);
        }

        [Route("Aeroplanes")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _aeroplaneService.GetAllAeroplanes();
            return Ok(result);
        }

        [Route("Aeroplane/{Id}")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Aeroplane aeroplane, int Id)
        {
            aeroplane.Id = Id;
            await _aeroplaneService.UpdateAeroplane(aeroplane);
            return Ok();
        }

        [Route("Aeroplane/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _aeroplaneService.DeleteAeroplane(Id);
            return Ok();
        }
        #endregion
    }
}
