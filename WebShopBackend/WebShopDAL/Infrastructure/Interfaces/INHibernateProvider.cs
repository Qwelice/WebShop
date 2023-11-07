namespace WebShopDAL.Infrastructure.Interfaces
{
    using NHibernate;

    public interface INHibernateProvider
    {
        public ISessionFactory GetSessionFactory();
        public ISession OpenSession();
    }
}
