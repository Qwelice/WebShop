namespace WebShopDAL.Repositories
{
    using NHibernate;
    using NHibernate.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebShopDAL.Entities;

    public class RoleRepository : IRepository<RoleEntity>, IRepositorySession
    {
        private ISession _session;
        private ITransaction? _transaction;

        public RoleRepository(ISession session)
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

        public void Delete(RoleEntity entity)
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

        public async Task DeleteAsync(RoleEntity entity)
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

        public IEnumerable<RoleEntity> Find(Func<RoleEntity, bool> predicate)
        {
            return _session.Query<RoleEntity>().Where(predicate).ToList();
        }

        public async Task<IEnumerable<RoleEntity>> FindAsync(Func<RoleEntity, bool> predicate)
        {
            var entities = await _session.Query<RoleEntity>().ToListAsync();
            return entities.Where(predicate).ToList();
        }

        public RoleEntity? Get(Guid id)
        {
            return _session.Get<RoleEntity>(id);
        }

        public IEnumerable<RoleEntity> GetAll()
        {
            return _session.Query<RoleEntity>().ToList();
        }

        public async Task<IEnumerable<RoleEntity>> GetAllAsync()
        {
            return await _session.Query<RoleEntity>().ToListAsync();
        }

        public async Task<RoleEntity?> GetAsync(Guid id)
        {
            return await _session.GetAsync<RoleEntity>(id);
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

        public void Save(RoleEntity entity)
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

        public async Task SaveAsync(RoleEntity entity)
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

        public void Update(RoleEntity entity)
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

        public async Task UpdateAsync(RoleEntity entity)
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
