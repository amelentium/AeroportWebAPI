using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Repository.Interfaces.Repositories;
using AeroportWebApi.Infrastructure.Contexts;

namespace AeroportWebApi.Repository.Repositories.Repositories
{
    public class FlightRepository : GenericRepository<Flight, int>, IFlightRepository
    {
        public FlightRepository(AeroDbContext context) : base(context)
        {

        }

        public new async Task Add(Flight flight)
        {
            flight.Plane = await _context.CompanyPlanes.FindAsync(flight.Plane.Id);
            flight.ArriveTo = await _context.Aeroports.FindAsync(flight.ArriveTo.Id);
            flight.DepartFrom = await _context.Aeroports.FindAsync(flight.DepartFrom.Id);

            await _context.Flights.AddAsync(flight);
        }

        public new async Task<Flight> Get(int Id)
        {
            return await _context.Flights
                .Include(f => f.Plane)
                .Include(f => f.Plane.Company)
                .Include(f => f.Plane.Plane)
                .Include(f => f.ArriveTo)
                .Include(f => f.DepartFrom)
                .FirstOrDefaultAsync(f => f.Id == Id);
        }

        public new async Task<List<Flight>> GetAll()
        {
            return await _context.Flights
                .Include(f => f.Plane)
                .Include(f => f.Plane.Company)
                .Include(f => f.Plane.Plane)
                .Include(f => f.ArriveTo)
                .Include(f => f.DepartFrom)
                .ToListAsync();
        }

        public async Task<List<Flight>> GetAllFlightsByPlaneId(int planeId)
        {
            return await _context.Flights
                   .Include(f => f.Plane)
                   .Include(f => f.Plane.Company)
                   .Include(f => f.Plane.Plane)
                   .Include(f => f.ArriveTo)
                   .Include(f => f.DepartFrom)
                   .Where(f => f.Plane.Id == planeId)
                   .ToListAsync();
        }

        public async Task<List<Flight>> GetAllFlightsByArriveId(int aeroportId)
        {
            return await _context.Flights
                   .Include(f => f.Plane)
                   .Include(f => f.Plane.Company)
                   .Include(f => f.Plane.Plane)
                   .Include(f => f.ArriveTo)
                   .Include(f => f.DepartFrom)
                   .Where(f => f.ArriveTo.Id == aeroportId)
                   .ToListAsync();
        }

        public async Task<List<Flight>> GetAllFlightsByDepartId(int aeroportId)
        {
            return await _context.Flights
                   .Include(f => f.Plane)
                   .Include(f => f.Plane.Company)
                   .Include(f => f.Plane.Plane)
                   .Include(f => f.ArriveTo)
                   .Include(f => f.DepartFrom)
                   .Where(f => f.DepartFrom.Id == aeroportId)
                   .ToListAsync();
        }

        public new async void Update(Flight flight)
        {
            var existingFlight = await Get(flight.Id);

            existingFlight.Plane = await _context.CompanyPlanes.FindAsync(flight.Plane.Id);
            existingFlight.ArriveTo = await _context.Aeroports.FindAsync(flight.ArriveTo.Id);
            existingFlight.DepartFrom = await _context.Aeroports.FindAsync(flight.DepartFrom.Id);
            existingFlight.DepartAt = flight.DepartAt;
            existingFlight.Length = flight.Length;
            existingFlight.Duration = flight.Duration;
        }
    }
}
