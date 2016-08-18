namespace SpecIt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal class Resolver : IResolver
    {
        private readonly Dictionary<TypeInfo, object> instances = new Dictionary<TypeInfo, object>();

        public Resolver()
        {
            this.instances.Add(typeof(IResolver).GetTypeInfo(), this);
        }

        public T Resolve<T>()
        {
            return (T)this.Resolve(typeof(T).GetTypeInfo(), null);
        }

        public T Resolve<T>(object constructorArguments)
        {
            return (T)this.Resolve(typeof(T).GetTypeInfo(), constructorArguments);
        }

        public void BindTo<T>(T obj)
        {
            this.instances.Add(typeof(T).GetTypeInfo(), obj);
        }

        private object Resolve(TypeInfo type, object constructorArguments)
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

            var constructor = type.DeclaredConstructors.FirstOrDefault();

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
                        parameters.Add(this.Resolve(parameterInfo.ParameterType.GetTypeInfo(), null));
                    }
                    catch (ResolverException resolverException)
                    {
                        if (resolverException.IsFirst)
                        {
                            throw new ResolverException(
                                resolverException.Message + " when resolver injection to :\n" + type.Name, false);
                        }

                        throw new ResolverException(
                            resolverException.Message + "\n" + type.Name, false);
                    }
                }
            }
            try
            {
                var instance = constructor.Invoke(parameters.ToArray());

                if (isCached)
                {
                    this.instances.Add(type, instance);
                }

                return instance;
            }
            catch (MemberAccessException ex)
            {
                throw new ResolverException($"{type.Name} has no constructor", true);
            }
        }

        private TypeInfo FindConcreteType(TypeInfo interfacType)
        {
            return interfacType.Assembly.DefinedTypes.FirstOrDefault(t => t.ImplementedInterfaces.Any(i => i.GetTypeInfo() == interfacType));
        }

        private bool FindParameter(object constructorArguments, ParameterInfo parameterInfo, out object value)
        {
            if (constructorArguments == null)
            {
                value = null;
                return false;
            }

            foreach (var propertyInfo in constructorArguments.GetType().GetTypeInfo().DeclaredProperties)
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
            return string.Compare(propertyInfo.Name, parameterInfo.Name, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}