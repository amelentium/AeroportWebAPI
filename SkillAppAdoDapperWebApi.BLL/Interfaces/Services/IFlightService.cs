using AeroportWebApi.DAL.Entities;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroportWebApi.BLL.Interfaces.Services
{
    public interface IFlightService
    {
        Task AddFlight(Flight flight);

        Task<Flight> GetFlightById(int Id);

        Task<List<Flight>> GetAllFlights();
        Task<List<Flight>> GetAllFlightsByPlaneId(int planeId);
        Task<List<Flight>> GetAllFlightsByDepartId(int aeroportId);
        Task<List<Flight>> GetAllFlightsByArriveId(int aeroportId);

        Task UpdateFlight(Flight flight);

        Task DeleteFlight(int id);

        Task<bool> IsFlightExist(Flight flight);

        ValidationResult FlightValidation(Flight flight);
    }
}
