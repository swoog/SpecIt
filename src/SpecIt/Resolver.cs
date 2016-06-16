namespace SpecIt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal class Resolver : IResolver
    {
        private readonly Dictionary<Type, object> instances = new Dictionary<Type, object>();

        public Resolver()
        {
            this.instances.Add(typeof(IResolver), this);
        }

        public T Resolve<T>()
        {
            return (T)this.Resolve(typeof(T), null);
        }

        public T Resolve<T>(object constructorArguments)
        {
            return (T)this.Resolve(typeof(T), constructorArguments);
        }

        public void BindTo<T>(T obj)
        {
            this.instances.Add(typeof(T), obj);
        }

        private object Resolve(Type type, object constructorArguments)
        {
            var isCached = constructorArguments == null;
            if (this.instances.ContainsKey(type) && isCached)
            {
                return this.instances[type];
            }

            if (type.IsInterface)
            {
                var concreteType = FindConcreteType(type);

                if (concreteType == null)
                {
                    throw new ResolverException($"{type.Name} has no binding", true);
                }

                return this.Resolve(concreteType, null);
            }

            var constructor = type.GetConstructors().FirstOrDefault();

            if (constructor == null)
            {
                throw new ResolverException($"{type.Name} has no constructor", true);
            }

            var parameters = new List<object>();

            foreach (var parameterInfo in constructor.GetParameters())
            {
                object value;
                if (this.FindParameter(constructorArguments, parameterInfo, out value))
                {
                    parameters.Add(value);
                }
                else
                {
                    try
                    {
                        parameters.Add(this.Resolve(parameterInfo.ParameterType, null));
                    }
                    catch (ResolverException resolverException)
                    {
                        if (resolverException.IsFirst)
                        {
                            throw new ResolverException(
                                resolverException.Message + " when resolver injection to :\n" + type.Name, false);
                        }
                        else
                        {
                            throw new ResolverException(
                                resolverException.Message + "\n" + type.Name, false);
                        }
                    }
                }
            }

            var instance = constructor.Invoke(parameters.ToArray());

            if (isCached)
            {
                this.instances.Add(type, instance);
            }

            return instance;
        }

        private Type FindConcreteType(Type interfacType)
        {
            return interfacType.Assembly.GetTypes().FirstOrDefault(t => t.GetInterfaces().Any(i => i == interfacType));
        }

        private bool FindParameter(object constructorArguments, ParameterInfo parameterInfo, out object value)
        {
            if (constructorArguments == null)
            {
                value = null;
                return false;
            }

            foreach (var propertyInfo in constructorArguments.GetType().GetProperties())
            {
                if (CompareNames(parameterInfo, propertyInfo))
                {
                    value = propertyInfo.GetValue(constructorArguments);
                    return true;
                }
            }

            value = null;
            return false;
        }

        private static bool CompareNames(ParameterInfo parameterInfo, PropertyInfo propertyInfo)
        {
            return string.Compare(propertyInfo.Name, parameterInfo.Name, StringComparison.InvariantCultureIgnoreCase) == 0;
        }
    }
}