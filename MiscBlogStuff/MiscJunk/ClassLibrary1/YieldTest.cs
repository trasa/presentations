using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ClassLibrary1
{
    [TestFixture]
    public class YieldTest
    {
        [Test]
        public void YieldFromAnEnumerable()
        {
            foreach(int i in GetInts())
                Console.WriteLine(i);

        }


        private static IEnumerable<int> GetInts()
        {
            for (int i=0; i<10; i++)
            {
                yield return i;
            }
        }
    }
}
