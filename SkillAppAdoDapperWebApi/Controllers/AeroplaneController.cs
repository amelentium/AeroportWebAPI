using AeroportWebApi.BLL.Interfaces.Services;
using AeroportWebApi.DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AeroportWebApi.WEBAPI.Controllers
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
            var result = _aeroplaneService.AeroplaneValidation(aeroplane);
            if (!result.IsValid)
                return BadRequest(result.Errors.Select(x => x.ErrorMessage).ToList());
                
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
