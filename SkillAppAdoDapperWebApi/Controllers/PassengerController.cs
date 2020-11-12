using Microsoft.AspNetCore.Mvc;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLServices;
using System;
using System.Collections.Generic;

namespace SkillManagement.WebAPI.Controllers
{
    public class PassengerController : ControllerBase
    {
        #region Properties
        private readonly ISQLPassengerService _sqlPassengerService;
        #endregion

        #region Constructors
        public PassengerController(ISQLPassengerService sqlPassengerService)
        {
            _sqlPassengerService = sqlPassengerService;
        }
        #endregion

        #region APIs
        [Route("Passengers")]
        [HttpGet]
        public IEnumerable<SQLPassenger> Get()
        {
            return _sqlPassengerService.GetAllPassengers();
        }

        [Route("Passenger/ByFlight/{flightId}")]
        [HttpGet]
        public IEnumerable<SQLPassenger> GetAllEmployeeSkillsByEmployeeId(int flightId)
        {
            return _sqlPassengerService.GetAllPassengersByFlightId(flightId);
        }

        [Route("Passenger/{Id}")]
        [HttpGet]
        public SQLPassenger Get(int Id)
        {
            return _sqlPassengerService.GetPassengerById(Id);
        }

        [Route("Passenger")]
        [HttpPost]
        public SQLPassenger Post([FromBody] SQLPassenger passenger)
        {
            return _sqlPassengerService.AddPassenger(passenger);
        }

        [Route("Passenger/{Id}")]
        [HttpPut]
        public SQLPassenger Put([FromBody] SQLPassenger passenger, int Id)
        {
            return _sqlPassengerService.UpdatePassenger(passenger, Id);
        }

        [Route("Passenger/{Id}")]
        [HttpDelete]
        public SQLPassenger Delete(int Id)
        {
            return _sqlPassengerService.DeletePassenger(Id);
        }
        #endregion
    }
}
