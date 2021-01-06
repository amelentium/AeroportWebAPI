using Microsoft.EntityFrameworkCore;
using SkillAppAdoDapperWebApi.DAL.Entities;
using SkillAppAdoDapperWebApi.Infrastructure.Contexts;
using SkillAppAdoDapperWebApi.Repository.Interfaces;
using SkillAppAdoDapperWebApi.Repository.Interfaces.Repositories;
using SkillManagement.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Repositories
{
    public class CompanyPlaneRepository : GenericRepository<CompanyPlane, int>, ICompanyPlaneRepository
    {

        private readonly AeroDbContext _context;
        public CompanyPlaneRepository(AeroDbContext context) : base(context)
        {
            _context = context;
        }

        public new async Task Add(CompanyPlane plane)
        {
            plane.Company = _context.Airlines.Find(plane.Company.Id);
            plane.Plane = _context.Aeroplanes.Find(plane.Plane.Id);

            await _context.CompanyPlanes.AddAsync(plane);
        }

        public new async Task<CompanyPlane> Get(int Id)
        {
            var result = await GetAll();
            return result.FirstOrDefault(p => p.Id == Id);
        }

        public new async Task<List<CompanyPlane>> GetAll()
        {
            var result = await _context.CompanyPlanes
                .Include(p => p.Company)
                .Include(p => p.Plane)
                .ToListAsync();

            return result;
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
