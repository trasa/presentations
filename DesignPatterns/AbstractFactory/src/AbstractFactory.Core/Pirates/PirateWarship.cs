using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory.Core.Pirates
{
    public class PirateWarship : IWarship
    {
        public double CombatModifier { get { return 0.25; } }

        public override string ToString()
        {
            return "Pirate Warship";
        }
    }
}
