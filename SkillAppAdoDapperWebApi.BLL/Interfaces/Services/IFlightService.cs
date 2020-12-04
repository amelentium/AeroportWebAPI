using SkillAppAdoDapperWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.BLL.Interfaces.Services
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
    }
}
