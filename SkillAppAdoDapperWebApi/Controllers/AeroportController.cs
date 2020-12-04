using Microsoft.AspNetCore.Mvc;
using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using SkillAppAdoDapperWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.WEBAPI.Controllers
{
    public class AeroportController : ControllerBase
    {
        #region Properties
        private readonly IAeroportService _aeroportService;
        #endregion

        #region Constructors
        public AeroportController(IAeroportService aeroportService)
        {
            _aeroportService = aeroportService;
        }
        #endregion

        #region APIs
        [Route("Aeroport")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Aeroport aeroport)
        {
            await _aeroportService.AddAeroport(aeroport);
            return Ok();
        }

        [Route("Aeroport/{Id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _aeroportService.GetAeroportById(Id);
            return Ok(result);
        }

        [Route("Aeroports")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _aeroportService.GetAllAeroports();
            return Ok(result);
        }

        [Route("Aeroport/{Id}")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Aeroport aeroport, int Id)
        {
            aeroport.Id = Id;
            await _aeroportService.UpdateAeroport(aeroport);
            return Ok();
        }

        [Route("Aeroport/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await  _aeroportService.DeleteAeroport(Id);
            return Ok();
        }
        #endregion
    }
}
