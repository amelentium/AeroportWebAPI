using Microsoft.EntityFrameworkCore;
using SkillAppAdoDapperWebApi.DAL.Entities;
using SkillAppAdoDapperWebApi.Infrastructure.Contexts;
using SkillAppAdoDapperWebApi.Repository.Interfaces.Repositories;
using SkillManagement.DataAccess.Core;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Repositories
{
    public class PassengerRepository : GenericRepository<Passenger, int>, IPassengerRepository
    {
        private readonly AeroDbContext _context;
        public PassengerRepository(AeroDbContext context) : base(context)
        {
            _context = context;
        }

        public new async Task Add(Passenger passenger)
        {
            passenger.Flight = await _context.Flights.FindAsync(passenger.Flight.Id);

            await _context.Passengers.AddAsync(passenger);
        }

        public new async Task<Passenger> Get(int Id)
        {
            var result = await GetAll();
            return result.FirstOrDefault(p => p.Id == Id);
        }

        public new async Task<List<Passenger>> GetAll()
        {
            var result = await _context.Passengers
                .Include(f => f.Flight)
                .Include(f => f.Flight.Plane)
                .Include(f => f.Flight.ArriveTo)
                .Include(f => f.Flight.DepartFrom)
                .ToListAsync();

            return result;
        }

        public async Task<List<Passenger>> GetAllPassengersByFlightId(int flightId)
        {
            var result = await GetAll();
            return result.FindAll(e => e.Flight.Id == flightId);
        }

        public new async Task Update(Passenger passenger)
        {
            var existingPassenger = await Get(passenger.Id);

            existingPassenger.Flight = await _context.Flights.FindAsync(passenger.Flight.Id);
            existingPassenger.FirstName = passenger.FirstName;
            existingPassenger.MiddleName = passenger.MiddleName;
            existingPassenger.LastName = passenger.LastName;
            existingPassenger.SeatNum = passenger.SeatNum;
            existingPassenger.PassportNum = passenger.PassportNum;
            existingPassenger.PhoneNum = passenger.PhoneNum;
        }
    }
}
