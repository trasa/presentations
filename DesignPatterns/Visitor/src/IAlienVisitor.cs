using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitors
{
    public interface IAlienVisitor
    {
        void VisitShip<T>(T ship) where T : AlienShip;
    }
}
