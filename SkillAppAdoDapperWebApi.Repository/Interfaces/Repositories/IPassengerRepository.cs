using AeroportWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroportWebApi.Repository.Interfaces.Repositories
{
    public interface IPassengerRepository : IGenericRepository<Passenger, int>
    {
        Task<List<Passenger>> GetAllPassengersByFlightId(int flightId);
    }
}
