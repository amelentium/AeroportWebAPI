using AeroportWebApi.Repository.Interfaces.Repositories;
using System.Threading.Tasks;

namespace AeroportWebApi.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IAeroplaneRepository AeroplaneRepository { get; }
        IAeroportRepository AeroportRepository { get; }
        IAirlineRepository AirlineRepository { get; }
        IFlightRepository FlightRepository { get; }
        IPassengerRepository PassengerRepository { get; }
        ICompanyPlaneRepository CompanyPlaneRepository { get; }
        Task Complete();
    }
}
