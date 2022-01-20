using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGestorDocumentos.Services
{
    public static class CustomDependencyService
    {
        private static Dictionary<Type, object> instances = new Dictionary<Type, object>();

        public static void Register(Type type)
        {
            var instance = Activator.CreateInstance(type);
            var implementationType = type.GetInterfaces().FirstOrDefault();
            if (instances.ContainsKey(implementationType))
            {
                instances[implementationType] = instance;
            }
            else
            {
                instances.Add(implementationType, instance);
            }
        }
        public static void Register<T>()
        {
            Register(typeof(T));
        }

        public static T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        public static object Get(Type type)
        {
            var implementation = type.GetInterfaces().FirstOrDefault();

            if (instances.ContainsKey(implementation))
            {
                return instances[implementation];
            }
            else
            {
                return null;
            }
        }
    }
}
