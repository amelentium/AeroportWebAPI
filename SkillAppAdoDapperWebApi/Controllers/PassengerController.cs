using Microsoft.AspNetCore.Mvc;
using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using SkillAppAdoDapperWebApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.WEBAPI.Controllers
{
    public class PassengerController : ControllerBase
    {
        #region Properties
        private readonly IPassengerService _passengerService;
        #endregion

        #region Constructors
        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }
        #endregion

        #region APIs
        [Route("Passenger")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Passenger passenger)
        {
            await _passengerService.AddPassenger(passenger);
            return Ok();
        }

        [Route("Passenger/{Id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _passengerService.GetPassengerById(Id);
            return Ok(result);
        }
        
        [Route("Passengers")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _passengerService.GetAllPassengers();
            return Ok(result);
        }

        [Route("Passenger/ByFlight/{flightId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllPassengersByFlightId(int flightId)
        {
            var result = await _passengerService.GetAllPassengersByFlightId(flightId);
            return Ok(result);
        }

        [Route("Passenger/{Id}")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Passenger passenger, int Id)
        {
            passenger.Id = Id;
            await _passengerService.UpdatePassenger(passenger);
            return Ok();
        }

        [Route("Passenger/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _passengerService.DeletePassenger(Id);
            return Ok();
        }
        #endregion
    }
}
