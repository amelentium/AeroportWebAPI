using AeroportWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroportWebApi.Repository.Interfaces.Repositories
{
    public interface IFlightRepository : IGenericRepository<Flight, int>
    {
        Task<List<Flight>> GetAllFlightsByPlaneId(int planeId);
        Task<List<Flight>> GetAllFlightsByDepartId(int aeroportId);
        Task<List<Flight>> GetAllFlightsByArriveId(int aeroportId);
    }
}
