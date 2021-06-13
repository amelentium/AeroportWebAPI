using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroportWebApi.Repository.Interfaces
{
    public interface IGenericRepository<TEntity, TId> where TEntity : class
    {
        Task Add(TEntity entity);

        Task<TEntity> Get(TId Id);

        Task<List<TEntity>> GetAll();

        void Update(TEntity entity);

        Task Delete(TId Id);

        Task<bool> IsExist(TEntity entity);
    }
}
