using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Dry.Extensions;

namespace Dry.Services
{
    public class IoC
    {
        /// <summary>
        /// Find all properties tagged [Injectable] in this object, and
        /// attempt to resolve with the current IoC container.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public static void WireUpInjectableProperties(object instance)
        {
            Type type = instance.GetType();
            var injectableProperties = (from property in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                        where property.GetCustomAttributes(typeof(InjectableAttribute), true).IsNullOrEmpty() == false // include if not empty
                                        select property);

            // now we have a list of properties that are Injectable, 
            // so go get values to stuff into the list.
            foreach (var property in injectableProperties)
            {
                // TODO: here you'd use an IoC container to actually resolve the dependencies
                //object dependency = Resolve(property.PropertyType);
                object dependency = Activator.CreateInstance(property.PropertyType);

                property.SetValue(instance, dependency, null);
            }
        }
    }
}
