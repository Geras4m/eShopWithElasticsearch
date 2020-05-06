using ES.WineShop.Common.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace ES.WineShop.Common.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMapperServices(this IServiceCollection services)
        {
            services.AddScoped<IWsMapper, WsMapper>();
        }
    }
}
