namespace WebShopDAL.Repositories
{
    using NHibernate;
    using NHibernate.Linq;
    using WebShopDAL.Entities;

    public class ProductRepository : IRepository<ProductEntity>, IRepositorySession
    {
        private ISession _session;
        private ITransaction? _transaction;

        public ProductRepository(ISession session)
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

        public void Delete(ProductEntity entity)
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

        public async Task DeleteAsync(ProductEntity entity)
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

        public IEnumerable<ProductEntity> Find(Func<ProductEntity, bool> predicate)
        {
            return _session.Query<ProductEntity>().Where(predicate).ToList();
        }

        public async Task<IEnumerable<ProductEntity>> FindAsync(Func<ProductEntity, bool> predicate)
        {
            var entities = await _session.Query<ProductEntity>().ToListAsync();
            return entities.Where(predicate).ToList();
        }

        public ProductEntity? Get(Guid id)
        {
            return _session.Get<ProductEntity>(id);
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            return _session.Query<ProductEntity>().ToList();
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _session.Query<ProductEntity>().ToListAsync();
        }

        public async Task<ProductEntity?> GetAsync(Guid id)
        {
            return await _session.GetAsync<ProductEntity>(id);
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

        public void Save(ProductEntity entity)
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

        public async Task SaveAsync(ProductEntity entity)
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

        public void Update(ProductEntity entity)
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

        public async Task UpdateAsync(ProductEntity entity)
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
