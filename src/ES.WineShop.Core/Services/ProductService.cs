using ES.WineShop.Common.Mapper;
using ES.WineShop.Core.Dto;
using ES.WineShop.Core.Services.Interfaces;
using ES.WineShop.Data.Entities;
using ES.WineShop.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace ES.WineShop.Core.Services
{
    public class ProductService : BaseService<ProductDto, Product>, IProductService
    {
        public ProductService(IProductRepository productRepository, IWsMapper mapper)
            : base(productRepository, mapper)
        {
        }
    }
}
