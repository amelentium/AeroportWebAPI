using System.Collections.Generic;
using System.Threading.Tasks;
using AeroportWebApi.BLL.Interfaces.Services;
using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Repository.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace AeroportWebApi.BLL.Services
{
    public class AeroportService : IAeroportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Aeroport> _validator;
        public AeroportService(IUnitOfWork unitOfWork, IValidator<Aeroport> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public async Task AddAeroport(Aeroport aeroport)
        {
            await _unitOfWork.AeroportRepository.Add(aeroport);
            await Complete();
        }

        public async Task<Aeroport> GetAeroportById(int Id)
        {
            return await _unitOfWork.AeroportRepository.Get(Id);
        }

        public async Task<List<Aeroport>> GetAllAeroports()
        {
            return await _unitOfWork.AeroportRepository.GetAll();
        }

        public async Task UpdateAeroport(Aeroport aeroport)
        {
            _unitOfWork.AeroportRepository.Update(aeroport);
            await Complete();
        }

        public async Task DeleteAeroport(int Id)
        {
            await _unitOfWork.AeroportRepository.Delete(Id);
            await Complete();
        }

        async Task Complete()
        {
            await _unitOfWork.Complete();
        }

        public async Task<bool> IsAeroportExist(Aeroport aeroport)
        {
            return await _unitOfWork.AeroportRepository.IsExist(aeroport);
        }

        public ValidationResult AeroportValidation(Aeroport aeroport)
        {
            return _validator.Validate(aeroport);
        }
    }
}
