using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Infrastructure.Contexts;
using AeroportWebApi.Repository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroportWebApi.Repository.Repositories.Repositories
{
    public class PassengerRepository : GenericRepository<Passenger, int>, IPassengerRepository
    {
        public PassengerRepository(AeroDbContext context) : base(context)
        {

        }

        public new async Task Add(Passenger passenger)
        {
            passenger.Flight = await _context.Flights.FindAsync(passenger.Flight.Id);

            await _context.Passengers.AddAsync(passenger);
        }

        public new async Task<Passenger> Get(int Id)
        {
            return await _context.Passengers
                .Include(p => p.Flight)
                .Include(p => p.Flight.Plane)
                .Include(p => p.Flight.Plane.Plane)
                .Include(p => p.Flight.Plane.Company)
                .Include(p => p.Flight.ArriveTo)
                .Include(p => p.Flight.DepartFrom)
                .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public new async Task<List<Passenger>> GetAll()
        {
            return await _context.Passengers
                .Include(p => p.Flight)
                .Include(p => p.Flight.Plane)
                .Include(p => p.Flight.Plane.Plane)
                .Include(p => p.Flight.Plane.Company)
                .Include(p => p.Flight.ArriveTo)
                .Include(p => p.Flight.DepartFrom)
                .ToListAsync();
        }

        public async Task<List<Passenger>> GetAllPassengersByFlightId(int flightId)
        {
            return await _context.Passengers
                .Include(p => p.Flight)
                .Include(p => p.Flight.Plane)
                .Include(p => p.Flight.Plane.Plane)
                .Include(p => p.Flight.Plane.Company)
                .Include(p => p.Flight.ArriveTo)
                .Include(p => p.Flight.DepartFrom)
                .Where(p => p.Flight.Id == flightId)
                .ToListAsync();
                
        }

        public new async void Update(Passenger passenger)
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
