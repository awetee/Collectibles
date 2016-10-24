using Tee.Collectibles.Common.Entities;

namespace Tee.Collectibles.Common.Repository
{
    using System.Collections.Generic;

    public interface IRepository<T> where T : IBaseEntity
    {
        int Insert(T item);

        IEnumerable<T> GetAll();

        T Get(int id);

        void Delete(T entity);

        void Update(T entity);
    }
}