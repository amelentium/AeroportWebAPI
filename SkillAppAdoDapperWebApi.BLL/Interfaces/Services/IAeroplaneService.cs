using AeroportWebApi.DAL.Entities;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroportWebApi.BLL.Interfaces.Services
{
    public interface IAeroplaneService
    {
        Task AddAeroplane(Aeroplane aeroplane);

        Task<Aeroplane> GetAeroplaneById(int Id);

        Task<List<Aeroplane>> GetAllAeroplanes();

        Task UpdateAeroplane(Aeroplane aeroplane);

        Task DeleteAeroplane(int Id);

        Task<bool> IsAeroplaneExist(Aeroplane aeroplane);

        ValidationResult AeroplaneValidation(Aeroplane aeroplane);
    }
}
