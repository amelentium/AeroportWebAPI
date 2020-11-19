using SkillManagement.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SkillAppAdoDapperWebApi.DAL.Infrastructure;
using Microsoft.Data.SqlClient;
using System;
using System.Linq.Expressions;

namespace SkillManagement.DataAccess.Core
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class
    {
        private readonly AeroDbContext _context;

        public GenericRepository(AeroDbContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public TEntity Get(TId Id)
        {
            return _context.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Update(TEntity entity, TId Id)
        {
            var result = _context.Set<TEntity>().Update(entity);

            _context.SaveChanges();

            return result.Entity;
        }

        public TEntity Delete(TId Id)
        {
            var result = Get(Id);
            _context.Set<TEntity>().Remove(result);

            return result;
        }
    }
}
