using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Infrastructure.Contexts;
using AeroportWebApi.Repository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroportWebApi.Repository.Repositories.Repositories
{
    public class CompanyPlaneRepository : GenericRepository<CompanyPlane, int>, ICompanyPlaneRepository
    {
        public CompanyPlaneRepository(AeroDbContext context) : base(context)
        {

        }

        public new async Task Add(CompanyPlane plane)
        {
            plane.Company = _context.Airlines.Find(plane.Company.Id);
            plane.Plane = _context.Aeroplanes.Find(plane.Plane.Id);

            await _context.CompanyPlanes.AddAsync(plane);
        }

        public new async Task<CompanyPlane> Get(int Id)
        {
            return await _context.CompanyPlanes
                .Include(p => p.Company)
                .Include(p => p.Plane)
                .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public new async Task<List<CompanyPlane>> GetAll()
        {
            return await _context.CompanyPlanes
                .Include(p => p.Company)
                .Include(p => p.Plane)
                .ToListAsync();
        }

        public async Task<List<CompanyPlane>> GetAllCompanyplanesByCompanyId(int companyId)
        {
            return await _context.CompanyPlanes
                .Include(p => p.Company)
                .Include(p => p.Plane)
                .Where(p => p.Company.Id == companyId)
                .ToListAsync();
        }

        public async Task<List<CompanyPlane>> GetAllCompanyplanesByPlaneId(int planeId)
        {
            return await _context.CompanyPlanes
                .Include(p => p.Company)
                .Include(p => p.Plane)
                .Where(p => p.Plane.Id == planeId)
                .ToListAsync();
        }

        public new async void Update(CompanyPlane plane)
        {
            var existingPlane = await Get(plane.Id);

            existingPlane.Company = _context.Airlines.Find(plane.Company.Id);
            existingPlane.Plane = _context.Aeroplanes.Find(plane.Plane.Id);
            existingPlane.Mark = plane.Mark;
        }
    }
}
