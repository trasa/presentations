using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitors
{
    class Program
    {
        static void Main()
        {
            #region build the fleet
            Fleet fleet = new Fleet();
            fleet.AddMothership(new Mothership());
            fleet.AddHarvester(new HumanHarvester());
            fleet.AddFighter(new Fighter());
            #endregion

            IAlienVisitor visitor = new SendOrdersVisitor(new AttackCommand());
            fleet.Accept(visitor);
            Console.WriteLine();

            visitor = new SendOrdersVisitor(new HarvestResourcesCommand());
            fleet.Accept(visitor);
            Console.WriteLine();

            // ID4 Virus
            visitor = new VirusVisitor();
            fleet.Accept(visitor);
            
            Console.WriteLine("[Hit Enter]");
            Console.ReadLine();
        }
    }
}
