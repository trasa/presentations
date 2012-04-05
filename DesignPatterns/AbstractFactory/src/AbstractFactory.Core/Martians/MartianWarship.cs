using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory.Core.Martians
{
    public class MartianWarship : IWarship
    {
        public double CombatModifier { get { return 0.2; } }

        public override string ToString()
        {
            return "Martian Warship";
        }
    }
}
