using System.Collections.Generic;
using System.Threading.Tasks;
using AeroportWebApi.Infrastructure.Contexts;
using AeroportWebApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AeroportWebApi.Repository.Repositories
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class
    {
        protected readonly AeroDbContext _context;

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

        public async Task<bool> IsExist(TEntity entity)
        {
            return await _context.Set<TEntity>().ContainsAsync(entity);
        }
    }
}
