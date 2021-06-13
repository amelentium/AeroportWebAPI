using AeroportWebApi.DAL.Entities;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroportWebApi.BLL.Interfaces.Services
{
    public interface IAeroportService
    {
        Task AddAeroport(Aeroport aeroport);

        Task<Aeroport> GetAeroportById(int id);

        Task<List<Aeroport>> GetAllAeroports();

        Task UpdateAeroport(Aeroport aeroport);

        Task DeleteAeroport(int Id);

        Task<bool> IsAeroportExist(Aeroport aeroport);

        ValidationResult AeroportValidation(Aeroport aeroport);
    }
}
