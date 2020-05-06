using ES.WineShop.Data.Repositories;
using ES.WineShop.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ES.WineShop.Data.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWsRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IEsProductRepository, EsPoductRepository>();
        }
    }
}
