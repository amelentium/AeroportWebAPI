using AeroportWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroportWebApi.Repository.Interfaces.Repositories
{
    public interface ICompanyPlaneRepository : IGenericRepository<CompanyPlane, int>
    {
        Task<List<CompanyPlane>> GetAllCompanyplanesByCompanyId(int companyId);
        Task<List<CompanyPlane>> GetAllCompanyplanesByPlaneId(int planeId);
    }
}
