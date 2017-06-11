using System;
using System.Collections.Generic;
using System.Linq;

namespace DevIoC
{
    class DevIoCContainer : IDevIoCContainer
    {
        private readonly Dictionary<Type, Type> _typeDictionary = new Dictionary<Type, Type>();
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }
        private object Resolve(Type typeToResolve)
        {
            Type resolveType;
            try
            {
                resolveType = _typeDictionary[typeToResolve];
            }
            catch
            {
                throw new Exception(string.Format("Can't resolve {0} type", typeToResolve.Name));
            }
            var constructor = resolveType.GetConstructors().First();
            var constructorParameters = constructor.GetParameters();
            if (!constructorParameters.Any())
            {
                return Activator.CreateInstance(resolveType);
            }

            IList<object> parameterList = new List<object>();
            foreach (var param in constructorParameters)
            {
                parameterList.Add(Resolve(param.ParameterType));
            }
            return constructor.Invoke(parameterList.ToArray());
        }

        public void RegisterType<TFrom, TTo>()
        {
            Type outputType;
            if (!_typeDictionary.TryGetValue(typeof(TFrom), out outputType))
            {
                _typeDictionary.Add(typeof(TFrom), typeof(TTo));
            }
        }
    }
}
