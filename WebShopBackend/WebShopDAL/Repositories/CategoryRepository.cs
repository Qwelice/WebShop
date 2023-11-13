namespace WebShopDAL.Repositories
{
    using NHibernate;
    using NHibernate.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WebShopDAL.Entities;

    public class CategoryRepository : IRepository<CategoryEntity>, IRepositorySession
    {
        private ISession _session;
        private ITransaction? _transaction;

        public CategoryRepository(ISession session)
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

        public void Delete(CategoryEntity entity)
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

        public async Task DeleteAsync(CategoryEntity entity)
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

        public IEnumerable<CategoryEntity> Find(Func<CategoryEntity, bool> predicate)
        {
            return _session.Query<CategoryEntity>().Where(predicate).ToList();
        }

        public async Task<IEnumerable<CategoryEntity>> FindAsync(Func<CategoryEntity, bool> predicate)
        {
            var entities = await _session.Query<CategoryEntity>().ToListAsync();
            return entities.Where(predicate).ToList();
        }

        public CategoryEntity? Get(Guid id)
        {
            return _session.Get<CategoryEntity>(id);
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            return _session.Query<CategoryEntity>().ToList();
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllAsync()
        {
            return await _session.Query<CategoryEntity>().ToListAsync();
        }

        public async Task<CategoryEntity?> GetAsync(Guid id)
        {
            return await _session.GetAsync<CategoryEntity>(id);
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

        public void Save(CategoryEntity entity)
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

        public async Task SaveAsync(CategoryEntity entity)
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

        public void Update(CategoryEntity entity)
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

        public async Task UpdateAsync(CategoryEntity entity)
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
