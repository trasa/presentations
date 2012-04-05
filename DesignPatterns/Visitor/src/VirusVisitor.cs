using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitors
{
    public class VirusVisitor : IAlienVisitor
    {
        public void VisitShip<T>(T ship) where T : AlienShip
        {
            ship.SelfDestruct();
        }

        public override string ToString()
        {
            return "ID4 ViRUZ -- SH0wtz out to friends of the cDc";
        }
    }

    
}
