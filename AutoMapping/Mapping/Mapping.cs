using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using AutoMapping.Interface;

namespace AutoMapping.Mapping
{
    public abstract class Mapping : IMapping
    {
        protected IDictionary<Type, Type> MappingTypes = new ConcurrentDictionary<Type, Type>();

        public TTarget Map<TSource, TTarget>(TSource sourceObject)
        {
            throw new NotImplementedException();
        }
    }
}
