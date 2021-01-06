using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using SkillAppAdoDapperWebApi.DAL.Entities;
using SkillAppAdoDapperWebApi.Repository.Interfaces;

namespace SkillAppAdoDapperWebApi.BLL.Services
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

        public ValidationResult AeroportValidation(Aeroport aeroport)
        {
            return _validator.Validate(aeroport);
        }
    }
}
