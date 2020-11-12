using System.Collections.Generic;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(TId Id);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity, TId Id);

        TEntity Delete(TId Id);
    }
}
