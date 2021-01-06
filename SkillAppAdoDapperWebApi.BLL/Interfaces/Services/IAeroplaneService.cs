using FluentValidation.Results;
using SkillAppAdoDapperWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.BLL.Interfaces.Services
{
    public interface IAeroplaneService
    {
        Task AddAeroplane(Aeroplane aeroplane);

        Task<Aeroplane> GetAeroplaneById(int Id);

        Task<List<Aeroplane>> GetAllAeroplanes();

        Task UpdateAeroplane(Aeroplane aeroplane);

        Task DeleteAeroplane(int Id);

        ValidationResult AeroplaneValidation(Aeroplane aeroplane);
    }
}
