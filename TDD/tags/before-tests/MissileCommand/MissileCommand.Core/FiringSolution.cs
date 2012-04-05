using System;


namespace MissileCommand.Core
{
    public class FiringSolution
    {
        private double storedVector;
        private readonly TargetingSystem system;

        public FiringSolution(TargetingSystem system)
        {
            this.system = system;
        }

        public FiringSolution ReticulateSplines(double vector)
        {
            if (storedVector.Equals(0))
            {
                storedVector = vector;
                return this;
            }
            else
            {
                FiringSolution newSol = new FiringSolution(system);
                newSol.storedVector = (Math.Log(storedVector) + Math.Log(vector)) / system.GeographicBias;
                return newSol;
            }
        }

        /// <summary>
        /// tell the master launch system to fire something.
        /// </summary>
        /// <returns>true if successful, false otherwise</returns>
        public bool  Fire()
        {
            MissileLaunchingSystem launcher = new MissileLaunchingSystem();
            return launcher.SendLaunchOrders(this);
        }
    }
}
