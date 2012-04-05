using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitors
{
    public class HumanHarvester : AlienShip
    {
        protected override void Attack()
        {
            Console.WriteLine("Harvester waves arms, frantically.");
        }

        protected override void Harvest()
        {
            Console.WriteLine("Harvester looks for yummy humans to convert into energy.");
        }
    }
}
