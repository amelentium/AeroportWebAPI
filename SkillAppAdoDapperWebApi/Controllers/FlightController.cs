using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using SkillAppAdoDapperWebApi.DAL.Entities;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes =
   JwtBearerDefaults.AuthenticationScheme)]
    public class FlightController : ControllerBase
    {
        #region Properties
        private readonly IFlightService _flightService;
        #endregion

        #region Constructors
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }
        #endregion

        #region APIs
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Flight flight)
        {
            await _flightService.AddFlight(flight);
            return Ok();
        }
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _flightService.GetFlightById(Id);
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _flightService.GetAllFlights();
            return Ok(result);
        }

        [HttpGet("{planeId}")]
        public async Task<IActionResult> GetAllFlightsByPlaneId(int planeId)
        {
            var result = await _flightService.GetAllFlightsByPlaneId(planeId);
            return Ok(result);
        }

        [HttpGet("{aeroportArriveId}")]
        public async Task<IActionResult> GetAllFlightsByDepartId(int aeroportArriveId)
        {
            var result = await _flightService.GetAllFlightsByDepartId(aeroportArriveId);
            return Ok(result);
        }

        [HttpGet("{aeroportDepartId}")]
        public async Task<IActionResult> GetAllFlightsByArriveId(int aeroportDepartId)
        {
            var result = await _flightService.GetAllFlightsByArriveId(aeroportDepartId);
            return Ok(result);
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromBody] Flight flight, int Id)
        {
            flight.Id = Id;
            await _flightService.UpdateFlight(flight);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await  _flightService.DeleteFlight(Id);
            return Ok();
        }
        #endregion
    }
}
