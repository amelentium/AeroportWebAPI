using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using SkillAppAdoDapperWebApi.DAL.Entities;
using SkillAppAdoDapperWebApi.Repository.Interfaces;

namespace SkillAppAdoDapperWebApi.BLL.Services
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

        public ValidationResult AeroplaneValidation(Aeroplane aeroplane)
        {
            return _validator.Validate(aeroplane);
        }
    }
}
