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
    public class AirlineController : ControllerBase
    {
        #region Properties
        private readonly IAirlineService _airlineService;
        #endregion

        #region Constructors
        public AirlineController(IAirlineService airlineService)
        {
            _airlineService = airlineService;
        }
        #endregion

        #region APIs
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Airline airline)
        {
            var result = _airlineService.AirlineValidation(airline);
            if (!result.IsValid)
                return BadRequest(result.Errors.Select(x => new { Error = x.ErrorMessage, Code = x.ErrorCode }).ToList());

            await _airlineService.AddAirline(airline);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _airlineService.GetAirlineById(Id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _airlineService.GetAllAirlines();
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromBody] Airline airline, int Id)
        {
            airline.Id = Id;
            await _airlineService.UpdateAirline(airline);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _airlineService.DeleteAirline(Id);
            return Ok();
        }
        #endregion
    }
}
