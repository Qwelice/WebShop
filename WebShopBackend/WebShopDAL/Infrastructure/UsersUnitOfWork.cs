namespace WebShopDAL.Infrastructure
{
    using NHibernate;
    using WebShopDAL.Entities;
    using WebShopDAL.Repositories;

    public class UsersUnitOfWork
    {
        private ISession _session;
        private IRepository<UserEntity>? _users = null;
        private IRepository<RoleEntity>? _roles = null;

        public UsersUnitOfWork(ISession session)
        {
            _session = session;
        }

        public IRepository<UserEntity> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_session);
                }
                return _users;
            }
        }

        public IRepository<RoleEntity> Roles
        {
            get
            {
                if(_roles == null)
                {
                    _roles = new RoleRepository(_session);
                }
                return _roles;
            }
        }
    }
}
