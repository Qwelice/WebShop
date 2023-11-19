namespace WebShopDAL.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;
    using MongoDB.Driver;
    using WebShopDAL.Infrastructure.Interfaces;

    public static class DALDependencyInstaller
    {
        public static void AddDAL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(new MongoClient("mongodb://localhost:27017"));
            serviceCollection.AddSingleton(provider => provider.GetRequiredService<MongoClient>().GetDatabase("webshop"));
            serviceCollection.AddSingleton<INHibernateProvider, NHibernateProvider>();
            serviceCollection.AddScoped(provider => provider.GetService<INHibernateProvider>()!.OpenSession());
            serviceCollection.AddScoped<UnitOfWork>();
        }
    }
}
