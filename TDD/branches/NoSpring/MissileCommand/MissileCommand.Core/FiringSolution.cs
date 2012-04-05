/* Copyright 2008 Tony Rasa trasa@meancat.com
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 * you may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under 
 * the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF 
 * ANY KIND, either express or implied. See the License for the specific language 
 * governing permissions and limitations under the License.
 */
using System;


namespace MissileCommand.Core
{
    public class FiringSolution
    {
        private double storedVector;
        private readonly TargetingSystem system;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FiringSolution"/> class.
        /// Initializes vectors to start position.
        /// </summary>
        /// <param name="system">The system.</param>
        public FiringSolution(TargetingSystem system): this(system, 1)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="FiringSolution"/> class.
        /// set Vector to be the initialVector.
        /// </summary>
        /// <param name="system">The system.</param>
        /// <param name="initialVector">The initial vector.</param>
        public FiringSolution(TargetingSystem system, double initialVector)
        {
            #region TEST: check arguments
            // TEST: check arguments
//            if (initialVector == 0.0)
//                throw new ArgumentOutOfRangeException("initialVector", initialVector, "initial vector cannot be zero");
//            if (system == null)
//                throw new ArgumentNullException("system");
            #endregion

            this.system = system;
            storedVector = initialVector;
        }

        public FiringSolution ReticulateSplines(double vector)
        {
            FiringSolution newSol = new FiringSolution(system);
            newSol.storedVector = (Math.Log(storedVector) + Math.Log(vector)) / system.GeographicBias;
            return newSol;
        }
        
        #region ReticulateSplines - Tests
        /*
        public FiringSolution ReticulateSplines(double vector)
        {
            // TEST: this doesn't work right if Vector property wasn't set (vector = 0, storedVector = 0)
            if (vector.Equals(0.0) || storedVector.Equals(0.0))
            {
                throw new InvalidVectorException("vector can't be zero");
            }

            // TEST: its discovered that this doesnt work right if vector is negative
            bool wasNegative = false;
            if (vector < 0)
            {
                wasNegative = true;
                vector = Math.Abs(vector);
            }

            FiringSolution newSol = new FiringSolution(system);
            newSol.storedVector = (Math.Log(Math.Abs(storedVector)) + Math.Log(vector)) / system.GeographicBias;
            if (wasNegative)
            {
                newSol.storedVector = 0 - newSol.storedVector;
            }
            return newSol;
        }
         */
        #endregion



        /// <summary>
        /// Gets the vector.
        /// </summary>
        /// <value>The vector.</value>
        public double Vector
        {
            get { return storedVector; }
            set { storedVector = value; }
        }

        /// <summary>
        /// tell the master launch system to fire something.
        /// </summary>
        /// <param name="launcher">The launcher.</param>
        /// <returns>result of the firing</returns>
        public string Fire(IMissileLaunchingSystem launcher)
        {
            // use version given to us by the caller:
            return launcher.SendLaunchOrders(this);
        }
    }
}
