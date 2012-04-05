using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NewFeatures
{
    class LambdaExample
    {
        // lambda expressions deserve a whole discussion by themselves, 
        // here's a brief example:

        #region C# 1.0 style

        bool MatchNumberBelowTen(int n)
        {
            return n < 10;
        }

        int GetNumber_1(ArrayList numbers) 
        {
            foreach(int i in numbers)
                if (MatchNumberBelowTen(i))
                    return i;
            return 0;
        }

        #endregion

        #region C# 2.0 anonymous methods

        int GetNumber2(List<int> numbers)
        {
            // using method:
            //return numbers.Find(MatchNumberBelowTen);

            // anonymous method:
            return numbers.Find(delegate(int n) { return n < 10; });

            /* anonymous advantages:
             * less clutter: don't need extra methods, don't need to name them
             * code locality
             * inferred return type
             * can reference local variables in the outer method
             */
        }

        #endregion

        #region C# 3.0
        
        int GetNumber3(List<int> numbers)
        {
            return numbers.Find(n => n < 10);
            /* basic syntax is: argument-list => expression
             * advantages:
             * syntax is more readable & concise
             * Use leads to Expression Trees, which allows you to 
             *  treat code as data.
             */
             

        }

        void SortNumbers(List<int> numbers)
        {
            numbers.Sort((x, y) => y - x);

            // vs..
            numbers.Sort(delegate(int x, int y) { return y - x; });
        }



        public static void ExpressionTreeExample()
        {
            Expression<Func<int>> f = () => 2 * 3 + 1;
            Console.WriteLine(f.Compile().Invoke());
            Console.WriteLine("My First Function: " + f);
            // expressed as code:
            Expression<Func<int>> f2 = Expression<Func<int>>.Lambda<Func<int>>(
                Expression.Add(
                    Expression.Multiply(
                        Expression.Constant(2),
                        Expression.Constant(3)),
                    Expression.Constant(1)),
                new ParameterExpression[0]);

            Console.WriteLine(f2.Compile().Invoke());
            Console.WriteLine("My second function: " + f2);

        }

        #endregion
    }
}
