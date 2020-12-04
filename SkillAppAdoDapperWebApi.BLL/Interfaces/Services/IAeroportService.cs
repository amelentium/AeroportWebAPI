using SkillAppAdoDapperWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.BLL.Interfaces.Services
{
    public interface IAeroportService
    {
        Task AddAeroport(Aeroport aeroport);

        Task<Aeroport> GetAeroportById(int id);

        Task<List<Aeroport>> GetAllAeroports();

        Task UpdateAeroport(Aeroport aeroport);

        Task DeleteAeroport(int Id);
    }
}
