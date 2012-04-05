using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitors
{
    public class Mothership : AlienShip
    {
        protected override void Attack()
        {
            Console.WriteLine("Mothership fires space-based weapon systems.");
        }

        protected override void Harvest()
        {
            Console.WriteLine("Mothership has no facilities for harvesting, does nothing.");
        }
    }
}
