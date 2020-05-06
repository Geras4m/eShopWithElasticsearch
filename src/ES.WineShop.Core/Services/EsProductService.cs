using ES.WineShop.Common.Mapper;
using ES.WineShop.Core.Dto;
using ES.WineShop.Core.Services.Interfaces;
using ES.WineShop.Data.Entities;
using ES.WineShop.Data.Repositories.Interfaces;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ES.WineShop.Core.Services
{
    public class EsProductService : IEsProductService
    {
        #region Fields/Constructors
        private readonly IEsProductRepository _esProductRepository;
        private readonly IWsMapper _mapper;
        public EsProductService(IEsProductRepository esProductRepository, IWsMapper mapper)
        {
            _esProductRepository = esProductRepository ?? throw new ArgumentNullException(nameof(esProductRepository));
            _mapper = mapper;
        }
        #endregion

        public async Task IndexAll(IList<ProductDto> products)
            => await _esProductRepository.IndexAll(_mapper.Map<IList<Product>>(products));

        public async Task<IEnumerable<ProductDto>> GetAllAsync(string term)
            => _mapper.Map<IEnumerable<ProductDto>>(await _esProductRepository.GetAllAsync(term));
    }
}
