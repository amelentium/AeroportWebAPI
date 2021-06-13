using AeroportWebApi.Repository.Interfaces;
using AeroportWebApi.BLL.Interfaces.Services;
using AeroportWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using FluentValidation;

namespace AeroportWebApi.BLL.Services
{
    public class AirlineService : IAirlineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Airline> _validator;
        public AirlineService(IUnitOfWork unitOfWork, IValidator<Airline> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task AddAirline(Airline airline)
        {
            await _unitOfWork.AirlineRepository.Add(airline);
            await Complete();
        }

        public async Task<Airline> GetAirlineById(int Id)
        {
            return await _unitOfWork.AirlineRepository.Get(Id);
        }

        public async Task<List<Airline>> GetAllAirlines()
        {
            return await _unitOfWork.AirlineRepository.GetAll();
        }

        public async Task UpdateAirline(Airline airline)
        {
            _unitOfWork.AirlineRepository.Update(airline);
            await Complete();
        }

        public async Task DeleteAirline(int Id)
        {
            await _unitOfWork.AirlineRepository.Delete(Id);
            await Complete();
        }

        async Task Complete()
        {
            await _unitOfWork.Complete();
        }

        public async Task<bool> IsAirlineExist(Airline airline)
        {
            return await _unitOfWork.AirlineRepository.IsExist(airline);
        }

        public ValidationResult AirlineValidation(Airline airline)
        {
            return _validator.Validate(airline);
        }
    }
}
