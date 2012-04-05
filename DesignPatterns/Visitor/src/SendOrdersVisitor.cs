using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitors
{
    public class SendOrdersVisitor : IAlienVisitor
    {
        private readonly ICommand cmd;

        public SendOrdersVisitor(ICommand cmd)
        {
            this.cmd = cmd;
        }
        
        public void VisitShip<T>(T ship) where T : AlienShip
        {
            ship.Do(cmd);
        }

        public override string ToString()
        {
            return "SendOrders: " + cmd;
        }
    }
}
