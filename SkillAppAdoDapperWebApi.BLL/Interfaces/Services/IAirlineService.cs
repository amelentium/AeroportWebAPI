using AeroportWebApi.DAL.Entities;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroportWebApi.BLL.Interfaces.Services
{
    public interface IAirlineService
    {
        Task AddAirline(Airline airline);

        Task<Airline> GetAirlineById(int Id);

        Task<List<Airline>> GetAllAirlines();

        Task UpdateAirline(Airline airline);

        Task DeleteAirline(int Id);

        Task<bool> IsAirlineExist(Airline airline);

        ValidationResult AirlineValidation(Airline airline);
    }
}
