﻿using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using SkillAppAdoDapperWebApi.DAL.Entities;
using SkillAppAdoDapperWebApi.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.BLL.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PassengerService(IUnitOfWork sqlsqlunitOfWork)
        {
            _unitOfWork = sqlsqlunitOfWork;
        }
        public async Task AddPassenger(Passenger passenger)
        {
            await _unitOfWork.PassengerRepository.Add(passenger);
            await Complete();
        }

        public async Task<Passenger> GetPassengerById(int Id)
        {
            return await _unitOfWork.PassengerRepository.Get(Id);
        }

        public async Task<List<Passenger>> GetAllPassengers()
        {
            return await _unitOfWork.PassengerRepository.GetAll();
        }

        public async Task<List<Passenger>> GetAllPassengersByFlightId(int flightId)
        {
            return await _unitOfWork.PassengerRepository.GetAllPassengersByFlightId(flightId);
        }

        public async Task UpdatePassenger(Passenger passenger)
        {
            _unitOfWork.PassengerRepository.Update(passenger);
            await Complete();
        }

        public async Task DeletePassenger(int Id)
        {
            await _unitOfWork.PassengerRepository.Delete(Id);
            await Complete();
        }

        async Task Complete()
        {
            await _unitOfWork.Complete();
        }
    }
}
