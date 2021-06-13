using AeroportWebApi.BLL.Interfaces.Services;
using AeroportWebApi.Repository.Interfaces;
using AeroportWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroportWebApi.BLL.Services
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

        public async Task<List<CompanyPlane>> GetAllCompanyplanes()
        {
            return await _unitOfWork.CompanyPlaneRepository.GetAll();
        }

        public async Task<List<CompanyPlane>> GetAllCompanyplanesByCompanyId(int companyId)
        {
            return await _unitOfWork.CompanyPlaneRepository.GetAllCompanyplanesByCompanyId(companyId);
        }

        public async Task<List<CompanyPlane>> GetAllCompanyplanesByPlaneId(int planeId)
        {
            return await _unitOfWork.CompanyPlaneRepository.GetAllCompanyplanesByPlaneId(planeId);
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

        public async Task<bool> IsCompanyPlaneExist(CompanyPlane plane)
        {
            return await _unitOfWork.CompanyPlaneRepository.IsExist(plane);
        }

        async Task Complete()
        {
            await _unitOfWork.Complete();
        }
    }
}
