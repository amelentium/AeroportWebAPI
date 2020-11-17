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
        protected IConnectionFactory _connectionFactory;
        private readonly string _tableName;
        private readonly bool _isSoftDelete;
        private readonly AeroDbContext _context;


        public GenericRepository(IConnectionFactory connectionFactory, string tableName, bool isSoftDelete, AeroDbContext context)
        {
            _connectionFactory = connectionFactory;
            _tableName = tableName;
            _isSoftDelete = isSoftDelete;
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            var stringOfColumns = string.Join(", ", GetColumns());
            var stringOfProperties = string.Join(", ", GetProperties(entity));

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
            var columns = GetColumns();
            var properties = GetProperties(entity);
            columns = columns.Zip(properties, (column, property) => column + " = " + property);
            var stringOfColumns = string.Join(", ", columns);

            var result = _context.Set<TEntity>()
                            .FromSqlRaw("SP_UpdateRecordInTable @P_tableName, @P_columnsString, @P_Id",
                            new SqlParameter("P_tableName", _tableName),
                            new SqlParameter("P_columnsString", stringOfColumns),
                            new SqlParameter("P_Id", Id)
                            ).ToList().FirstOrDefault();

            _context.SaveChanges();

            return result;
        }

        public TEntity Delete(TId Id)
        {
            var result = _context.Set<TEntity>()
                    .FromSqlRaw("SP_DeleteRecordFromTable @P_tableName, @P_Id",
                    new SqlParameter("P_tableName", _tableName),
                    new SqlParameter("P_Id", Id)
                    ).ToList().FirstOrDefault();

            _context.SaveChanges();

            return result;
        }
        
        private IEnumerable<string> GetColumns()
        {
            return typeof(TEntity)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && e.Name != "Duration" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }

        private IEnumerable<string> GetProperties(TEntity entity)
        {
            return typeof(TEntity)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && e.Name != "Duration" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => '\'' + e.GetValue(entity).ToString() + '\'');
        }
    }
}
