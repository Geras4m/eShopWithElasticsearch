using System;
using System.Collections.Generic;
using System.Text;

namespace ES.WineShop.Common.Mapper
{
    public interface IWsMapper
    {
        TDestination Map<TDestination>(object source);
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
