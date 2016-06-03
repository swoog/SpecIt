namespace SpecIt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Resolver : IResolver
    {
        private readonly Dictionary<Type, object> instances = new Dictionary<Type, object>();

        public Resolver()
        {
            this.instances.Add(typeof(IResolver), this);
        }

        public T Resolve<T>()
        {
            return (T)this.Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            if (this.instances.ContainsKey(type))
            {
                return this.instances[type];
            }

            var constructor = type.GetConstructors().First();

            var parameters = new List<object>();

            foreach (var parameterInfo in constructor.GetParameters())
            {
                parameters.Add(this.Resolve(parameterInfo.ParameterType));
            }

            var instance = constructor.Invoke(parameters.ToArray());

            this.instances.Add(type, instance);

            return instance;
        }
    }
}