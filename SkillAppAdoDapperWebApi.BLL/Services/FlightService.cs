using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using SkillAppAdoDapperWebApi.DAL.Entities;
using SkillAppAdoDapperWebApi.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.BLL.Services
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FlightService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddFlight(Flight flight)
        {
            await _unitOfWork.FlightRepository.Add(flight);
            await Complete();
        }

        public async Task<Flight> GetFlightById(int Id)
        {
            return await _unitOfWork.FlightRepository.Get(Id);
        }

        public async Task<List<Flight>> GetAllFlights()
        {
            return await _unitOfWork.FlightRepository.GetAll();
        }

        public async Task<List<Flight>> GetAllFlightsByPlaneId(int planeId)
        {
            return await _unitOfWork.FlightRepository.GetAllFlightsByPlaneId(planeId);
        }

        public async Task<List<Flight>> GetAllFlightsByDepartId(int aeroportId)
        {
            return await _unitOfWork.FlightRepository.GetAllFlightsByDepartId(aeroportId);
        }

        public async Task<List<Flight>> GetAllFlightsByArriveId(int aeroportId)
        {
            return await _unitOfWork.FlightRepository.GetAllFlightsByArriveId(aeroportId);
        }

        public async Task UpdateFlight(Flight flight)
        {
            _unitOfWork.FlightRepository.Update(flight);
            await Complete(); 
        }

        public async Task DeleteFlight(int Id)
        {
            await _unitOfWork.FlightRepository.Delete(Id);
            await Complete();
        }

        async Task Complete()
        {
            await _unitOfWork.Complete();
        }
    }
}
