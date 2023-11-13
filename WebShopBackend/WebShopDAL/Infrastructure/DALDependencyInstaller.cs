namespace WebShopDAL.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;
    using WebShopDAL.Infrastructure.Interfaces;

    public static class DALDependencyInstaller
    {
        public static void AddDAL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<INHibernateProvider, NHibernateProvider>();
            serviceCollection.AddScoped(provider => provider.GetService<INHibernateProvider>()!.OpenSession());
            serviceCollection.AddScoped<UnitOfWork>();
        }
    }
}
