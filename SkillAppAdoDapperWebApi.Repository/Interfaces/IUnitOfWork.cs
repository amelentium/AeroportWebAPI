using SkillAppAdoDapperWebApi.Repository.Interfaces.Repositories;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IAeroplaneRepository AeroplaneRepository { get; }
        IAeroportRepository AeroportRepository { get; }
        IFlightRepository FlightRepository { get; }
        IPassengerRepository PassengerRepository { get; }
        Task Complete();
    }
}
