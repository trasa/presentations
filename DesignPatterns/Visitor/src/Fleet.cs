using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitors
{
    public class Fleet
    {
        private readonly List<Mothership> motherships = new List<Mothership>();
        private readonly List<HumanHarvester> harvesters = new List<HumanHarvester>();
        private readonly List<Fighter> fighters = new List<Fighter>();

        public void AddMothership(Mothership ship)
        {
            motherships.Add(ship);
        }

        public void AddHarvester(HumanHarvester ship)
        {
            harvesters.Add(ship);
        }

        public void AddFighter(Fighter ship)
        {
            fighters.Add(ship);
        }


        public void Accept(IAlienVisitor visitor)
        {
            Console.WriteLine("Fleet accepts a visitor: " + visitor);

            motherships.ForEach(ship => ship.Accept(visitor));
            harvesters.ForEach(ship => ship.Accept(visitor));
            fighters.ForEach(ship => ship.Accept(visitor));
        }
    }
}

