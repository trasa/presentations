using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory.Core.Pirates
{
    public class PirateFreighter : IFreighter
    {
        public double CombatModifier { get { return 0.15; } }

        public override string ToString()
        {
            return "Pirate Freighter";
        }
    }
}
