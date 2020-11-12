using Microsoft.AspNetCore.Mvc;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using System.Collections.Generic;


namespace SkillManagement.WebAPI.Controllers
{
    public class FlightController : ControllerBase
    {
        #region Properties
        private readonly ISQLFlightService _sqlFlightService;
        public FlightController(ISQLFlightService flightService)
        {
            _sqlFlightService = flightService;
        }
        #endregion

        #region Constructors
        [Route("Flights")]
        [HttpGet]
        public IEnumerable<SQLFlight> Get()
        {
            return _sqlFlightService.GetAllFlights();
        }
        #endregion

        #region APIs
        [Route("Flight/{Id}")]
        [HttpGet]
        public SQLFlight Get(int Id)
        {
            return _sqlFlightService.GetFlightById(Id);
        }

        [Route("Flight/DepartFrom/{aeroportId}")]
        [HttpGet]
        public IEnumerable<SQLFlight> GetAllFlightsByDepartId(int aeroportId)
        {
            return _sqlFlightService.GetAllFlightsByDepartId(aeroportId);
        }

        [Route("Flight/ArriveTo/{aeroportId}")]
        [HttpGet]
        public IEnumerable<SQLFlight> GetAllFlightsByArriveId(int aeroportId)
        {
            return _sqlFlightService.GetAllFlightsByArriveId(aeroportId);
        }

        [Route("Flight/Plane/{planeId}")]
        [HttpGet]
        public IEnumerable<SQLFlight> GetAllFlightsByPlaneId(int planeId)
        {
            return _sqlFlightService.GetAllFlightsByPlaneId(planeId);
        }

        [Route("Flight")]
        [HttpPost]
        public SQLFlight Post([FromBody] SQLFlight flight)
        {
            return _sqlFlightService.AddFlight(flight);
        }

        [Route("Flight/{Id}")]
        [HttpPut]
        public SQLFlight Put([FromBody] SQLFlight flight, int Id)
        {
            return _sqlFlightService.UpdateFlight(flight, Id);
        }

        [Route("Flight/{Id}")]
        [HttpDelete]
        public SQLFlight Delete(int Id)
        {
            return _sqlFlightService.DeleteFlight(Id);
        }
        #endregion
    }
}
