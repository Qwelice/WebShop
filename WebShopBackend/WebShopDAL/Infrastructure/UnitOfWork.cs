namespace WebShopDAL.Infrastructure
{
    using NHibernate;
    using WebShopDAL.Entities;
    using WebShopDAL.Repositories;

    public class UnitOfWork
    {
        private ISession _session;
        private IRepository<UserEntity>? _users = null;
        private IRepository<RoleEntity>? _roles = null;
        private IRepository<ProductEntity>? _products = null;
        private IRepository<CategoryEntity>? _categories = null;

        public UnitOfWork(ISession session)
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

        public IRepository<ProductEntity> Products
        {
            get
            {
                if(_products == null)
                {
                    _products = new ProductRepository(_session);
                }
                return _products;
            }
        }

        public IRepository<CategoryEntity> Categories
        {
            get
            {
                if(_categories == null)
                {
                    _categories = new CategoryRepository(_session);
                }
                return _categories;
            }
        }
    }
}
