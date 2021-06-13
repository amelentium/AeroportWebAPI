using AeroportWebApi.BLL.Interfaces.Services;
using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Repository.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroportWebApi.BLL.Services
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Flight> _validator;
        public FlightService(IUnitOfWork unitOfWork, IValidator<Flight> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
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

        public async Task<bool> IsFlightExist(Flight flight)
        {
            return await _unitOfWork.FlightRepository.IsExist(flight);
        }

        async Task Complete()
        {
            await _unitOfWork.Complete();
        }

        public ValidationResult FlightValidation(Flight flight)
        {
            return _validator.Validate(flight);
        }
    }
}
