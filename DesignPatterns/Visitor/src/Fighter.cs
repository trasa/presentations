using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitors
{
    public class Fighter : AlienShip
    {
        protected override void Attack()
        {
            Console.WriteLine("Fightercraft shoots at everything in sight.");
        }

        protected override void Harvest()
        {
            Console.WriteLine("Fightercraft shoots at everything in sight (dead humans are easier to harvest)");
        }
    }
}
