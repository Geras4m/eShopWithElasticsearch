using ES.WineShop.Data.Entities;
using ES.WineShop.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.WineShop.Data.Repositories
{
    internal class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(WineShopDbContext context)
            : base(context)
        {
        }
    }
}
