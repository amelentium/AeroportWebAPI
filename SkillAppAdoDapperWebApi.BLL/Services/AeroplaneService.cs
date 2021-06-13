using System.Collections.Generic;
using System.Threading.Tasks;
using AeroportWebApi.BLL.Interfaces.Services;
using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Repository.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace AeroportWebApi.BLL.Services
{
    public class AeroplaneService : IAeroplaneService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Aeroplane> _validator;
        public AeroplaneService(IUnitOfWork unitOfWork, IValidator<Aeroplane> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task AddAeroplane(Aeroplane aeroplane)
        {
            await _unitOfWork.AeroplaneRepository.Add(aeroplane);
            await Complete();
        }

        public async Task<Aeroplane> GetAeroplaneById(int Id)
        {
            return await _unitOfWork.AeroplaneRepository.Get(Id);
        }

        public async Task<List<Aeroplane>> GetAllAeroplanes()
        {
            return await _unitOfWork.AeroplaneRepository.GetAll();
        }

        public async Task UpdateAeroplane(Aeroplane aeroplane)
        {
            _unitOfWork.AeroplaneRepository.Update(aeroplane);
            await Complete();
        }

        public async Task DeleteAeroplane(int Id)
        {
            await _unitOfWork.AeroplaneRepository.Delete(Id);
            await Complete();
        }

        async Task Complete()
        {
            await _unitOfWork.Complete();
        }

        public async Task<bool> IsAeroplaneExist(Aeroplane aeroplane)
        {
            return await _unitOfWork.AeroplaneRepository.IsExist(aeroplane);
        }

        public ValidationResult AeroplaneValidation(Aeroplane aeroplane)
        {
            return _validator.Validate(aeroplane);
        }
    }
}
