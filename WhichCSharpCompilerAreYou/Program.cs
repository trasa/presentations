using System;
using System.Collections.Generic;
using System.Text;

namespace WhichCSharpCompilerAreYou
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I'm targeting 2.0");

            // property
            SomeProperty = "hi";
            Console.WriteLine(SomeProperty);

            // lambda
            Console.WriteLine(BuildSomething(3, (someInt) => "your value is " + someInt.ToString()));

            // Func<T>: not in 2.0 libraries

            // linq: not in 2.0 libraries

            // var:
            var x = new List<string>() { "a", "b", "c" };
            foreach(var y in x)
                Console.WriteLine(y);

            // anonymous types:
            var anonyType = new { Name = "Bob", FavoriteNumber = 23 };
            Console.WriteLine(anonyType.GetType().Name);
            Console.WriteLine(anonyType.Name);



            Console.WriteLine("Hit enter");
            Console.ReadLine();
        }

        private delegate string GetValue(int someInt);

        static string BuildSomething(int number, GetValue valueGetter)
        {
            return "we are building something: " + valueGetter(number);
        }
        
        public static string SomeProperty
        {
            get;
            set;
        }
    }
}
