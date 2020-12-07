using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using SkillAppAdoDapperWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes =
JwtBearerDefaults.AuthenticationScheme)]
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
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Aeroplane aeroplane)
        {
            await _aeroplaneService.AddAeroplane(aeroplane);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _aeroplaneService.GetAeroplaneById(Id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _aeroplaneService.GetAllAeroplanes();
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromBody] Aeroplane aeroplane, int Id)
        {
            aeroplane.Id = Id;
            await _aeroplaneService.UpdateAeroplane(aeroplane);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _aeroplaneService.DeleteAeroplane(Id);
            return Ok();
        }
        #endregion
    }
}
