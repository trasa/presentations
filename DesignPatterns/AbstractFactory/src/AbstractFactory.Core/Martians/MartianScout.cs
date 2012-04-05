using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory.Core.Martians
{
    public class MartianScout : IScout
    {
        public double CombatModifier { get { return 0.1; } }

        public override string ToString()
        {
            return "Martian Scout";
        }
    }
}
