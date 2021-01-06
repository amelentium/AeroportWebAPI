using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using SkillAppAdoDapperWebApi.DAL.Entities;
using SkillAppAdoDapperWebApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.BLL.Services
{
    public class CompanyPlaneService : ICompanyPlaneService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyPlaneService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddCompanyPlane(CompanyPlane plane)
        {
            await _unitOfWork.CompanyPlaneRepository.Add(plane);
            await Complete();
        }

        public async Task<CompanyPlane> GeCompanyPlaneById(int Id)
        {
            return await _unitOfWork.CompanyPlaneRepository.Get(Id);
        }

        public async Task<List<CompanyPlane>> GetAllCompanyPlane()
        {
            return await _unitOfWork.CompanyPlaneRepository.GetAll();
        }

        public async Task UpdateCompanyPlane(CompanyPlane plane)
        {
            _unitOfWork.CompanyPlaneRepository.Update(plane);
            await Complete();
        }

        public async Task DeleteCompanyPlane(int Id)
        {
            await _unitOfWork.CompanyPlaneRepository.Delete(Id);
            await Complete();
        }

        async Task Complete()
        {
            await _unitOfWork.Complete();
        }
    }
}
