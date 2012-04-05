using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitors
{
    public abstract class AlienShip
    {

        public void Accept(IAlienVisitor visitor)
        {
            visitor.VisitShip(this);
        }
        


        public void Do(ICommand cmd)
        {
            var t = cmd.GetType();
            
            // in a real application, this would do something cool.
            if (t == typeof(AttackCommand))
            {
                Attack();
            }
            else if (t == typeof(HarvestResourcesCommand))
            {
                Harvest();
            } 
            else if (t == typeof(SelfDestructCommand))
            {
                SelfDestruct();
            }
        }

        protected abstract void Attack();
        protected abstract void Harvest();


        /// <summary>
        /// Destroys the alien ship.
        /// </summary>
        /// <remarks>
        /// TODO: Perhaps this should not be part of the public interface?
        /// </remarks>
        public void SelfDestruct()
        {
            Console.WriteLine(GetType().Name + " has been destroyed.");
        }


    }
}
