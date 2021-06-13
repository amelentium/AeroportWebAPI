using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Infrastructure.Contexts;
using AeroportWebApi.Repository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroportWebApi.Repository.Repositories.Repositories
{
    public class AirlineRepository : GenericRepository<Airline, int>, IAirlineRepository
    {
        public AirlineRepository(AeroDbContext context) : base(context)
        {

        }

        public new async Task Add(Airline airline)
        {
            List<Aeroplane> planesList = new List<Aeroplane>();
            foreach (Aeroplane plane in airline.Aeroplanes)
                planesList.Add(_context.Aeroplanes.Find(plane.Id));
            airline.Aeroplanes = planesList;

            await _context.Airlines.AddAsync(airline);
        }

        public new async Task<Airline> Get(int Id)
        {
            return await _context.Airlines
                .Include(l => l.Aeroplanes)
                .FirstOrDefaultAsync(l => l.Id == Id);
        }

        public new async Task<List<Airline>> GetAll()
        {
            return await _context.Airlines
                .Include(l => l.Aeroplanes)
                .ToListAsync();
        }

        public new async void Update(Airline airline)
        {
            var existingAirline = await Get(airline.Id);

            List<Aeroplane> planesList = new List<Aeroplane>();
            foreach (Aeroplane plane in airline.Aeroplanes)
                planesList.Add(_context.Aeroplanes.Find(plane.Id));

            existingAirline.Aeroplanes = planesList;
            existingAirline.Country = airline.Country;
            existingAirline.Description = airline.Description;
        }
    }
}
