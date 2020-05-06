using ES.WineShop.Core.Dto;
using ES.WineShop.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ES.WineShop.Core.Services.Interfaces
{
    public interface IEsProductService
    {
        Task IndexAll(IList<ProductDto> products);
        Task<IEnumerable<ProductDto>> GetAllAsync(string term);

    }
}
