using System;

namespace Blackfin.Cms.Stubs
{
    /// <summary>
    /// Just a plain old dummy attribute, for testing.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DummyAttribute : Attribute
    {
    }


    // for attribute catalog test
    [DummyAttribute]
    public class LocationStub 
    {

    }

    [Dummy]
    public class RequestStub
    {

    }
}
