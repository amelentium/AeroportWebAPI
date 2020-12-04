using SkillAppAdoDapperWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.BLL.Interfaces.Services
{
    public interface IPassengerService
    {
        Task AddPassenger(Passenger passenger);

        Task<Passenger> GetPassengerById(int Id);

        Task<List<Passenger>> GetAllPassengers();

        Task<List<Passenger>> GetAllPassengersByFlightId(int flightId);

        Task UpdatePassenger(Passenger passenger);

        Task DeletePassenger(int Id);
    }
}
