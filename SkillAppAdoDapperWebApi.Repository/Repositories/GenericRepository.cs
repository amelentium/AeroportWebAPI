using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillAppAdoDapperWebApi.Infrastructure.Contexts;
using SkillAppAdoDapperWebApi.Repository.Interfaces;

namespace SkillManagement.DataAccess.Core
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class
    {
        private readonly AeroDbContext _context;

        public GenericRepository(AeroDbContext context)
        {
            _context = context;
        }

        public async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<TEntity> Get(TId Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(TId Id)
        {
            var result = await _context.Set<TEntity>().FindAsync(Id);
            _context.Remove(result);
        }
    }
}
