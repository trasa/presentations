using System;

namespace Dry.Services
{
    /// <summary>
    /// Indicates a property that should be injected via IoC.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class InjectableAttribute : Attribute
    {
    }
}
