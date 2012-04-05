using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitors
{
    public interface ICommand
    {
    }

    public class AttackCommand : ICommand
    {
        public override string ToString()
        {
            return "Attack!  KILL KILL KILL KILL!";
        }
    }

    public class HarvestResourcesCommand : ICommand
    {
        public override string ToString()
        {
            return "Seek out and gather resources.";
        }
    }

    public class SelfDestructCommand : ICommand
    {
        public override string ToString()
        {
            return "Destruct sequence 1, code 1-1 ALPHA. Code zero zero zero. Destruct. Zero.";
        }
    }
}
