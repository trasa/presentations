using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewFeatures
{


    #region Feature 1: Auto-Implemented Properties
    class Customer
    {
        // prop: string CustomerId
        // prop: string ContactName
        // prop: string City

        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
    }
    #endregion


    class Program
    {
        static void Main(string[] args)
        {
            

            // 1: see defn of Customer (above)
            List<Customer> customers = LoadCustomers();
            // 2: defn LoadCustomers (below)

            #region Feature 4: LINQ


            var query = from c in customers
                        where c.City == "London"
                        select c;

            // equivalent to: (loop / iterator)
            #region Why Bother?
            // 1.  The query is easily extensible
                    // orderby c.ContactName.Split(' ')[1]
            // 2.  easier to take advantage of multicore, similar improvements

            // order by last name:
            
            #endregion


            #region Feature 5: "var" Local Variable Type Inference 

            foreach (var item in query)
            {
                Console.WriteLine("{0}, {1}, {2}",
                    item.CustomerId, item.ContactName, item.City);
            }

            // Note: "item" is strongly typed, at compile type
            // the type is inferred from the RHS, cutting down on typing.
            // this is required for LINQ & Anonymous Types (below)

            #region another application

            // one application: a dictionary, keyed by strings,
            // containing a dictionary of strings and lists.
            Dictionary<string, Dictionary<string, List<int>>> d = new Dictionary<string,Dictionary<string,List<int>>>();
            //vs
            var d2 = new Dictionary<string, Dictionary<string, List<int>>>();

            #endregion

            #region Feature 6: Implicitly Typed Arrays

            var a1 = new[] { "a", null, "b" };
            var a2 = new[] { 1, 2, 3, 4 };
            
            // this doesn't seem to be 100% supported:
            var a3 = new[,] { { "a", "a" }, { "b", "a" } };

            #endregion

            #endregion


            #endregion

            #region Feature 7: Anon Types
            // we only really need the CustomerID and Name, so
            // we don't need to deal with the whole Customer object:
            var query3 = from c in customers
                         where c.City == "London"
                         orderby c.ContactName.Split(' ')[1]
                         select new
                                {
                                    CustomerId = c.CustomerId,
                                    ContactName = c.ContactName
                                };
            // this generates a new type with the two properties
            // CustomerId and ContactName




            // since this comes up so often...
            var query4 = from c in customers
                         where c.City == "London"
                         orderby c.ContactName.Split(' ')[1]
                         select new { c.CustomerId, c.ContactName };
            
            foreach (var item in query4)
            {
                // item is anonymous, but with full intellisense support:
                Console.WriteLine("{0}, {1}",
                    item.CustomerId,
                    item.ContactName);
            }

            #endregion

            #region Feature 8 / 9 : Lambda Expressions and Expression Trees

            //LambdaExample.ExpressionTreeExample();

            #endregion

            Console.ReadLine();

            /* Some more features we didn't get to:
             * 
             * 10 Extension Methods
             * 11 Partial Methods
             */
        }

        private static List<Customer> LoadCustomers()
        {
            #region Feature 2: Object Initializers

            Customer c1 = new Customer();
            c1.CustomerId = "ALFKI";
            c1.ContactName = "Maria Anders";
            c1.City = "Berlin";

            #region replace with
            // same as:
            c1 = new Customer()
                 {
                     CustomerId = "ALFKI",
                     ContactName = "Maria Anders",
                     City = "Berlin"
                 };
            #endregion

            #endregion

            #region Feature 3: Collection Initializers
            List<Customer> customers = new List<Customer>();
            customers.Add(c1);

            #region replace with
            customers = new List<Customer>() {
                            c1 
                        };
            #endregion

            #region all together
            customers = new List<Customer>() {
             new Customer() { CustomerId = "ALFKI", ContactName = "Maria Anders", City = "Berlin" },
             new Customer() { CustomerId = "FOO", ContactName = "Bob Smith", City = "London" }
                        };
            #endregion

            #region Feature 3: another example
            Dictionary<int, string> lookup = new Dictionary<int, string>() {
                         {1, "one"},
                         {2, "two"},
                         {3, "three"}
                     };
            #endregion

            #endregion

            return customers;
        }
    }
}
