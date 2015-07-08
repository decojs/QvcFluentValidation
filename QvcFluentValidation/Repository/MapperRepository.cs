namespace QvcFluentValidation.Repository
{
    using System;
    using System.Collections.Generic;

    public class MapperRepository
    {
        readonly Dictionary<Type, Type> _mapperLookup;

        public MapperRepository()
        {
            _mapperLookup = new Dictionary<Type, Type>();
        }

        public Type FindMapperFor(Type validator)
        {
            return _mapperLookup.ContainsKey(validator)
                ? _mapperLookup[validator]
                : null;
        }

        public void AddMapper(Type validator, Type rule)
        {
            _mapperLookup.Add(validator, rule);
        }
    }
}