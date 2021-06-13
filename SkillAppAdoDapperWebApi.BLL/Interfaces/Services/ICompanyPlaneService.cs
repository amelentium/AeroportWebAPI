using AeroportWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroportWebApi.BLL.Interfaces.Services
{
    public interface ICompanyPlaneService
    {
        Task AddCompanyPlane(CompanyPlane plane);

        Task<CompanyPlane> GeCompanyPlaneById(int Id);

        Task<List<CompanyPlane>> GetAllCompanyplanes();
        Task<List<CompanyPlane>> GetAllCompanyplanesByCompanyId(int companyId);
        Task<List<CompanyPlane>> GetAllCompanyplanesByPlaneId(int planeId);

        Task UpdateCompanyPlane(CompanyPlane plane);

        Task<bool> IsCompanyPlaneExist(CompanyPlane plane);

        Task DeleteCompanyPlane(int Id);
    }
}
