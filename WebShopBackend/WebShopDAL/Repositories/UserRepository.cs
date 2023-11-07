namespace WebShopDAL.Repositories
{
    using NHibernate;
    using NHibernate.Linq;
    using WebShopDAL.Entities;

    public class UserRepository : IRepository<UserEntity>, IRepositorySession
    {
        private ISession _session;
        private ITransaction? _transaction;

        public UserRepository(ISession session)
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

        public void Delete(UserEntity entity)
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

        public async Task DeleteAsync(UserEntity entity)
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

        public IEnumerable<UserEntity> Find(Func<UserEntity, bool> predicate)
        {
            return _session.Query<UserEntity>().Where(predicate).ToList();
        }

        public async Task<IEnumerable<UserEntity>> FindAsync(Func<UserEntity, bool> predicate)
        {
            var entities = await _session.Query<UserEntity>().ToListAsync();
            return entities.Where(predicate).ToList();
        }

        public UserEntity? Get(Guid id)
        {
            return _session.Get<UserEntity>(id);
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _session.Query<UserEntity>().ToList();
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _session.Query<UserEntity>().ToListAsync();
        }

        public async Task<UserEntity?> GetAsync(Guid id)
        {
            return await _session.GetAsync<UserEntity>(id);
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

        public void Save(UserEntity entity)
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

        public async Task SaveAsync(UserEntity entity)
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

        public void Update(UserEntity entity)
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

        public async Task UpdateAsync(UserEntity entity)
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
