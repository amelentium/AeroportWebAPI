using AeroportWebApi.BLL.Interfaces.Services;
using AeroportWebApi.DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AeroportWebApi.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes =
   JwtBearerDefaults.AuthenticationScheme)]
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
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Passenger passenger)
        {
            await _passengerService.AddPassenger(passenger);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _passengerService.GetPassengerById(Id);
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _passengerService.GetAllPassengers();
            return Ok(result);
        }

        [HttpGet("{flightId}")]
        public async Task<IActionResult> GetAllPassengersByFlightId(int flightId)
        {
            var result = await _passengerService.GetAllPassengersByFlightId(flightId);
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromBody] Passenger passenger, int Id)
        {
            passenger.Id = Id;
            await _passengerService.UpdatePassenger(passenger);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _passengerService.DeletePassenger(Id);
            return Ok();
        }
        #endregion
    }
}
