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
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Aeroport aeroport)
        {
            await _aeroportService.AddAeroport(aeroport);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _aeroportService.GetAeroportById(Id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _aeroportService.GetAllAeroports();
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromBody] Aeroport aeroport, int Id)
        {
            aeroport.Id = Id;
            await _aeroportService.UpdateAeroport(aeroport);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await  _aeroportService.DeleteAeroport(Id);
            return Ok();
        }
        #endregion
    }
}
