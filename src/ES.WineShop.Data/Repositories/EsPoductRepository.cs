using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ES.WineShop.Data.Entities;
using ES.WineShop.Data.Repositories.Interfaces;
using Nest;

namespace ES.WineShop.Data.Repositories
{
    internal class EsPoductRepository : IEsProductRepository
    {
        #region Fields/Constructors
        private readonly IElasticClient _elasticClient;
        private readonly IProductRepository _productRepository;
        public EsPoductRepository(IElasticClient elasticClient, IProductRepository productRepository)
        {
            _elasticClient = elasticClient ?? throw new ArgumentNullException(nameof(elasticClient));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        #endregion

        public async Task IndexAll(IList<Product> products)
        {
            var asyncBulkIndexResponse = await _elasticClient.BulkAsync(b => b
            .Index("product")
            .IndexMany(products));
        }

        public async Task<IEnumerable<Product>> GetAllAsync(string term)
        {
            var result = Search();

            if (!result.Any())
            {
                var list = await _productRepository.SelectAllAsync();
                await IndexAll(list);

                result = Search();
            }

            return result;

            //local function for searching and matching phrase prefix with term
            IEnumerable<Product> Search()
            {
                var searchResponse = _elasticClient.Search<Product>(p =>
                            p.From(0)
                            .Size(1000)
                            .Query(q => q.MatchPhrasePrefix(c => c
                                        .Field(n => n.Name)
                                        .Name("named_query")
                                        .Boost(1.1)
                                        .Query(term)
                                        .Analyzer("standard")
                                        .Slop(2)
                                        .MaxExpansions(2)
                                         )
                            ||
                                         q.MatchPhrasePrefix(c => c
                                        .Field(d => d.Description)
                                        .Name("named_query")
                                        .Boost(1.1)
                                        .Query(term)
                                        .Analyzer("standard")
                                        .Slop(2)
                                        .MaxExpansions(2)
                                        )
                            ||
                                         q.MatchPhrasePrefix(c => c
                                        .Field(d => d.ShortDescription)
                                        .Name("named_query")
                                        .Boost(1.1)
                                        .Query(term)
                                        .Analyzer("standard")
                                        .Slop(2)
                                        .MaxExpansions(2)
                                        )
                            )
                            );

                return searchResponse.Hits.Select(h => h.Source);
            }
        }
    }
}
