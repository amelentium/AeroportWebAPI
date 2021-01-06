using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using SkillAppAdoDapperWebApi.DAL.Entities;
using SkillAppAdoDapperWebApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.BLL.Services
{
    public class AirlineService : IAirlineService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AirlineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAirline(Airline airline)
        {
            await _unitOfWork.AirlineRepository.Add(airline);
            await Complete();
        }

        public async Task<Airline> GetAirlineById(int Id)
        {
            return await _unitOfWork.AirlineRepository.Get(Id);
        }

        public async Task<List<Airline>> GetAllAirlines()
        {
            return await _unitOfWork.AirlineRepository.GetAll();
        }

        public async Task UpdateAirline(Airline airline)
        {
            _unitOfWork.AirlineRepository.Update(airline);
            await Complete();
        }

        public async Task DeleteAirline(int Id)
        {
            await _unitOfWork.AirlineRepository.Delete(Id);
            await Complete();
        }

        async Task Complete()
        {
            await _unitOfWork.Complete();
        }
    }
}
