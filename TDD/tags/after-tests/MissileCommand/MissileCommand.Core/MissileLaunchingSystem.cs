using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MissileCommand.Core
{
    public class MissileLaunchingSystem : IMissileLaunchingSystem
    {
        /// <summary>
        /// Sends the launch orders.
        /// </summary>
        /// <param name="solution">The solution.</param>
        /// <returns>true if successful, false otherwise</returns>
        public string SendLaunchOrders(FiringSolution solution)
        {
            #region Incredibly complicated, top-secret, and very sensitive launch system happens here

            return "Fired a Very Real Missile with warhead, caused an international incident. (Congrats)";

            #endregion
        }
    }
}
