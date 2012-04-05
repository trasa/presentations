
using System;

namespace RobotArmy.Core.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Gets the name of the controller out of the type name, assuming this type is a controller of course....
        /// </summary>
        /// <param name="controllerType">type to extract name from.</param>
        /// <returns>name minus controller</returns>
        public static string GetControllerName(this Type controllerType)
        {
            // This is based on an MVC Convention:
            return controllerType.Name.Replace("Controller", string.Empty);
        }
    }
}
