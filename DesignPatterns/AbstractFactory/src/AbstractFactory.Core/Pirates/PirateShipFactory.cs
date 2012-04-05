using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory.Core.Pirates
{
    public class PirateShipFactory : ShipFactory
    {
        public override IScout CreateScout()
        {
            return new PirateScout();
        }

        public override IFreighter CreateFreighter()
        {
            return new PirateFreighter();
        }

        public override IWarship CreateWarship()
        {
            return new PirateWarship();
        }
    }
}
