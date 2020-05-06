using ES.WineShop.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ES.WineShop.Data.Repositories.Interfaces
{
    public interface IEsProductRepository
    {
        Task IndexAll(IList<Product> products);
        Task<IEnumerable<Product>> GetAllAsync(string term);
    }
}
