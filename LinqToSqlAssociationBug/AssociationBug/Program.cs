using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociationBug
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new ExampleContextDataContext();
            // get some element:
            var element = ctx.Elements.Where(e => e.ElementID == 1).First();
            // set some property:
            element.SomeOtherValue = false;
            // attempt to save -- FAIL
            ctx.SubmitChanges();
            
            Console.ReadLine();
        }
    }
}
