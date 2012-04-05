using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory.Core.Terrans
{
    public class TerranShipFactory : ShipFactory
    {
        public override IScout CreateScout()
        {
            return new TerranScout();
        }

        public override IFreighter CreateFreighter()
        {
            return new TerranFreighter();
        }

        public override IWarship CreateWarship()
        {
            return new TerranWarship();
        }
    }
}
