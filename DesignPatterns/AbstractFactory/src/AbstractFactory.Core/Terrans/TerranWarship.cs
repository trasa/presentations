using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory.Core.Terrans
{
    public class TerranWarship : IWarship
    {
        public double CombatModifier { get { return 0.1; } }

        public override string ToString()
        {
            return "Terran Warship";
        }
    }
}
