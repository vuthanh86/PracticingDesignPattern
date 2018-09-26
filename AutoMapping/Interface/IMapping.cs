using System;

namespace AutoMapping.Interface
{
    public interface IMapping
    {
        TTarget Map<TSource, TTarget>(TSource sourceObject);
    }
}
