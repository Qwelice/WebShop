namespace WebShopDAL.Infrastructure
{
    using System.Configuration;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Cfg;
    using NHibernate;
    using NHibernate.Dialect;
    using WebShopDAL.Infrastructure.Interfaces;
    using WebShopDAL.Entities;
    using NHibernate.Tool.hbm2ddl;

    public class NHibernateProvider : INHibernateProvider
    {
        private static ISessionFactory? _sessionFactory = null;
        public ISessionFactory GetSessionFactory()
        {
            return BuildAndGetSessionFactory();
        }

        public ISession OpenSession()
        {
            return GetSessionFactory().OpenSession();
        }

        private static ISessionFactory BuildAndGetSessionFactory()
        {
            if (_sessionFactory == null)
            {
                var _cfg = PostgreSQLConfiguration.Standard.ConnectionString(x =>
                x.Username("postgres")
                .Password("Kamil400")
                .Host("localhost")
                .Port(5432)
                .Database("webshop"))
                    .Dialect<PostgreSQL82Dialect>().ShowSql();

                _sessionFactory = Fluently.Configure()
                    .Database(_cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BaseEntity>())
                    .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                    .BuildSessionFactory();
            }

            return _sessionFactory;
        }
    }
}
