namespace WebShopDAL.Repositories
{
    using NHibernate;
    using NHibernate.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class BaseRepository<T> : IRepository<T>, IRepositorySession
    {
        protected ISession _session;
        protected ITransaction? _transaction;

        public BaseRepository(ISession session)
        {
            _session = session;
        }

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Commit()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }

        public void Delete(T entity)
        {
            try
            {
                BeginTransaction();
                _session.Delete(entity);
                Commit();
            }
            catch
            {
                Rollback();
            }
            finally
            {
                CloseTransaction();
            }
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                BeginTransaction();
                await _session.DeleteAsync(entity);
                await CommitAsync();
            }
            catch
            {
                await RollbackAsync();
            }
            finally
            {
                CloseTransaction();
            }
        }

        public void DeleteBy(Guid id)
        {
            try
            {
                var entity = Get(id);
                if (entity != null)
                {
                    BeginTransaction();
                    _session.Delete(entity);
                    Commit();
                }
            }
            catch
            {
                Rollback();
            }
            finally
            {
                CloseTransaction();
            }
        }

        public async Task DeleteByAsync(Guid id)
        {
            try
            {
                var entity = await GetAsync(id);
                if (entity != null)
                {
                    BeginTransaction();
                    await _session.DeleteAsync(entity);
                    await CommitAsync();
                }
            }
            catch
            {
                await RollbackAsync();
            }
            finally
            {
                CloseTransaction();
            }
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _session.Query<T>().Where(predicate).ToList();
        }

        public async Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
        {
            var entities = await _session.Query<T>().ToListAsync();
            return entities.Where(predicate).ToList();
        }

        public T? Get(Guid id)
        {
            return _session.Get<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _session.Query<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _session.Query<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(Guid id)
        {
            return await _session.GetAsync<T>(id);
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public void Save(T entity)
        {
            try
            {
                BeginTransaction();
                _session.Save(entity);
                Commit();
            }
            catch
            {
                Rollback();
            }
            finally
            {
                CloseTransaction();
            }
        }

        public async Task SaveAsync(T entity)
        {
            try
            {
                BeginTransaction();
                await _session.SaveAsync(entity);
                await CommitAsync();
            }
            catch
            {
                await RollbackAsync();
            }
            finally
            {
                CloseTransaction();
            }
        }

        public void Update(T entity)
        {
            try
            {
                BeginTransaction();
                _session.Update(entity);
                Commit();
            }
            catch
            {
                Rollback();
            }
            finally
            {
                CloseTransaction();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                BeginTransaction();
                await _session.UpdateAsync(entity);
                await CommitAsync();
            }
            catch
            {
                await RollbackAsync();
            }
            finally
            {
                CloseTransaction();
            }
        }
    }
}
