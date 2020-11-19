using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity, TId> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(TId Id);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity, TId Id);

        TEntity Delete(TId Id);
    }
}
