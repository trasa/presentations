using System;
using Blackfin.SpringHelper;


namespace MissileCommand.Core
{
    public class FiringSolution
    {
        private double storedVector;
        private readonly ITargetingSystem system;

        /// <summary>
        /// Initializes a new instance of the <see cref="FiringSolution"/> class.
        /// Initializes vectors to start position.
        /// </summary>
        /// <param name="system">The system.</param>
        public FiringSolution(ITargetingSystem system): this(system, 1)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="FiringSolution"/> class.
        /// set Vector to be the initialVector.
        /// </summary>
        /// <param name="system">The system.</param>
        /// <param name="initialVector">The initial vector.</param>
        public FiringSolution(ITargetingSystem system, double initialVector)
        {
            // TEST: check arguments
            if (initialVector == 0.0)
                throw new ArgumentOutOfRangeException("initialVector", initialVector, "initial vector cannot be zero");
            if (system == null)
                throw new ArgumentNullException("system");

            this.system = system;
            storedVector = initialVector;
        }

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
            newSol.storedVector = (Math.Log(Math.Abs(storedVector)) + Math.Log(vector))/system.GeographicBias;
            if (wasNegative)
            {
                newSol.storedVector = 0 - newSol.storedVector;
            }
            return newSol;
        }

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
        /// <returns>result of the firing</returns>
        public string Fire()
        {
            // TEST: we want to be able to create a FiringSolution, and test FiringSolution,
            // without the worry of causing an international incident.
            MissileLaunchingSystem launcher = new MissileLaunchingSystem();
            return launcher.SendLaunchOrders(this);



            #region decoupled from concrete implementation:
            //IMissileLaunchingSystem launcher = Factory<IMissileLaunchingSystem>.Create();
            //return launcher.SendLaunchOrders(this);
            #endregion
        }
    }
}
