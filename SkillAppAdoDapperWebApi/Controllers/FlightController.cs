using Microsoft.AspNetCore.Mvc;
using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using SkillAppAdoDapperWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.WEBAPI.Controllers
{
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
        [Route("Flight")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Flight flight)
        {
            await _flightService.AddFlight(flight);
            return Ok();
        }
        
        [Route("Flight/{Id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _flightService.GetFlightById(Id);
            return Ok(result);
        }
        
        [Route("Flights")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _flightService.GetAllFlights();
            return Ok(result);
        }

        [Route("Flight/Plane/{planeId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllFlightsByPlaneId(int planeId)
        {
            var result = await _flightService.GetAllFlightsByPlaneId(planeId);
            return Ok(result);
        }

        [Route("Flight/DepartFrom/{aeroportId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllFlightsByDepartId(int aeroportId)
        {
            var result = await _flightService.GetAllFlightsByDepartId(aeroportId);
            return Ok(result);
        }

        [Route("Flight/ArriveTo/{aeroportId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllFlightsByArriveId(int aeroportId)
        {
            var result = await _flightService.GetAllFlightsByArriveId(aeroportId);
            return Ok(result);
        }


        [Route("Flight/{Id}")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Flight flight, int Id)
        {
            flight.Id = Id;
            await _flightService.UpdateFlight(flight);
            return Ok();
        }

        [Route("Flight/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await  _flightService.DeleteFlight(Id);
            return Ok();
        }
        #endregion
    }
}
