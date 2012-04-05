using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory.Core.Martians
{
    public class MartianShipFactory : ShipFactory
    {
    
        public override IScout CreateScout()
        {
            return new MartianScout();
        }

        public override IFreighter CreateFreighter()
        {
            return new MartianFreighter();
        }

        public override IWarship CreateWarship()
        {
            return new MartianWarship();
        }
    }
}
