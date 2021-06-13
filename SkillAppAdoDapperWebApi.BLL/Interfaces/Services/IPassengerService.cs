using AeroportWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroportWebApi.BLL.Interfaces.Services
{
    public interface IPassengerService
    {
        Task AddPassenger(Passenger passenger);

        Task<Passenger> GetPassengerById(int Id);

        Task<List<Passenger>> GetAllPassengers();

        Task<List<Passenger>> GetAllPassengersByFlightId(int flightId);

        Task UpdatePassenger(Passenger passenger);

        Task<bool> IsPassengerExist(Passenger passenger);

        Task DeletePassenger(int Id);
    }
}
