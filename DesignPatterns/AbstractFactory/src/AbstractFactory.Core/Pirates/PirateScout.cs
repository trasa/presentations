using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory.Core.Pirates
{
    public class PirateScout : IScout
    {
        public double CombatModifier { get { return 0.1; } }

        public override string ToString()
        {
            return "Pirate Scout";
        }
    }
}
