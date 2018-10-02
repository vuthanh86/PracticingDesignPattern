using System;

namespace AutoMapping.Interface
{
    public interface IMapping
    {
        TTarget CreateMap<TSource, TTarget>();
    }
}
