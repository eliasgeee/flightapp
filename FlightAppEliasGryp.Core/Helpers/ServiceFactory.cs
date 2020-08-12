using System;
using System.Collections.Generic;
using System.Text;

namespace FlightAppEliasGryp.Core.Helpers
{
    public static class ServiceFactory
    {
        public static Dictionary<Type, object> _lookup = new Dictionary<Type, object>();

        public static void StoreFactory<T>(Func<T> Factory)
        {
            _lookup[typeof(T)] = Factory;
        }

        public static T GetObject<T>()
        {
            object o = null;
            if(_lookup.TryGetValue(typeof(T), out o))
            {
                var factory = (Func<T>)o;
                return (T)factory();
            }
            return default(T);
        } 
    }
}
