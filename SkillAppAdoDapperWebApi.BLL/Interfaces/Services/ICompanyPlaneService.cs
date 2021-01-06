using SkillAppAdoDapperWebApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.BLL.Interfaces.Services
{
    public interface ICompanyPlaneService
    {
        Task AddCompanyPlane(CompanyPlane plane);

        Task<CompanyPlane> GeCompanyPlaneById(int Id);

        Task<List<CompanyPlane>> GetAllCompanyPlane();

        Task UpdateCompanyPlane(CompanyPlane plane);

        Task DeleteCompanyPlane(int Id);
    }
}
