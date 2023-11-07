namespace WebShopDAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T? Get(Guid id);
        Task<T?> GetAsync(Guid id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate);
        void Save(T entity);
        Task SaveAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void DeleteBy(Guid id);
        Task DeleteByAsync(Guid id);
    }
}
