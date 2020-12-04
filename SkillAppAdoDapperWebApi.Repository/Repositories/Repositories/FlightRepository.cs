using SkillManagement.DataAccess.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SkillAppAdoDapperWebApi.Infrastructure.Contexts;
using SkillAppAdoDapperWebApi.Repository.Interfaces.Repositories;
using SkillAppAdoDapperWebApi.DAL.Entities;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Repositories
{
    public class FlightRepository : GenericRepository<Flight, int>, IFlightRepository
    {
        private readonly AeroDbContext _context;
        public FlightRepository(AeroDbContext context) : base(context)
        {
            _context = context;
        }

        public new async Task Add(Flight flight)
        {
            flight.Plane = await _context.Aeroplanes.FindAsync(flight.Plane.Id);
            flight.ArriveTo = await _context.Aeroports.FindAsync(flight.ArriveTo.Id);
            flight.DepartFrom = await _context.Aeroports.FindAsync(flight.DepartFrom.Id);

            await _context.Flights.AddAsync(flight);
        } 

        public new async Task<Flight> Get(int Id)
        {
            var result = await GetAll();
            return result.FirstOrDefault(f => f.Id == Id);
        }

        public new async Task<List<Flight>> GetAll()
        {
            var result = await _context.Flights
                .Include(p => p.Plane)
                .Include(a => a.ArriveTo)
                .Include(d => d.DepartFrom)
                .ToListAsync();

            return result;
        }

        public async Task<List<Flight>> GetAllFlightsByPlaneId(int planeId)
        {
            var result = await GetAll();
            return result.FindAll(e => e.Plane.Id == planeId);
        }

        public async Task<List<Flight>> GetAllFlightsByDepartId(int aeroportId)
        {
            var result = await GetAll();
            return result.FindAll(e => e.DepartFrom.Id == aeroportId);
        }

        public async Task<List<Flight>> GetAllFlightsByArriveId(int aeroportId)
        {
            var result = await GetAll();
            return result.FindAll(e => e.ArriveTo.Id == aeroportId);
        }

        public new async Task Update(Flight flight)
        {
            var existingFlight = await Get(flight.Id);

            existingFlight.Plane = await _context.Aeroplanes.FindAsync(flight.Plane.Id);
            existingFlight.ArriveTo = await _context.Aeroports.FindAsync(flight.ArriveTo.Id);
            existingFlight.DepartFrom = await _context.Aeroports.FindAsync(flight.DepartFrom.Id);
            existingFlight.DepartAt = flight.DepartAt;
            existingFlight.Length = flight.Length;
            existingFlight.Duration = flight.Duration;
        }
    }
}
