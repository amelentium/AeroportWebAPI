using Microsoft.EntityFrameworkCore;
using SkillAppAdoDapperWebApi.DAL.Entities;
using SkillAppAdoDapperWebApi.Infrastructure.Contexts;
using SkillAppAdoDapperWebApi.Repository.Interfaces.Repositories;
using SkillManagement.DataAccess.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Repositories
{
    public class AirlineRepository : GenericRepository<Airline, int>, IAirlineRepository
    {
        private readonly AeroDbContext _context;
        public AirlineRepository(AeroDbContext context) : base(context)
        {
            _context = context;
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
            var result = await GetAll();
            return result.FirstOrDefault(l => l.Id == Id);
        }

        public new async Task<List<Airline>> GetAll()
        {
            var result = await _context.Airlines
                .Include(l => l.Aeroplanes)
                .ToListAsync();

            return result;
        }

        public new async Task Update(Airline airline)
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
