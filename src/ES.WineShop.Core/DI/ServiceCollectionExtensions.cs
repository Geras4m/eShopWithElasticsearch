using ES.WineShop.Core.Services;
using ES.WineShop.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ES.WineShop.Core.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWsCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IEsProductService, EsProductService>();
        }
    }
}
