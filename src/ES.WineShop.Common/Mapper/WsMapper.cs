using AutoMapper;
using System;

namespace ES.WineShop.Common.Mapper
{
    public class WsMapper : IWsMapper
    {
        private readonly IMapper _mapper;
        public WsMapper(IMapper mapper)
            => _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));


        public TDestination Map<TDestination>(object source)
            => _mapper.Map<TDestination>(source);

        public TDestination Map<TSource, TDestination>(TSource source)
            => _mapper.Map<TSource, TDestination>(source);
    }
}
