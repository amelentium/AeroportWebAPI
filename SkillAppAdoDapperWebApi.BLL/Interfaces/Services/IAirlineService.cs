using SkillAppAdoDapperWebApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.BLL.Interfaces.Services
{
    public interface IAirlineService
    {
        Task AddAirline(Airline airline);

        Task<Airline> GetAirlineById(int Id);

        Task<List<Airline>> GetAllAirlines();

        Task UpdateAirline(Airline airline);

        Task DeleteAirline(int Id);
    }
}
