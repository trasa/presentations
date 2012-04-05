namespace MissileCommand.Core
{
    // this was generated using R#
    public interface IMissileLaunchingSystem
    {
        /// <summary>
        /// Sends the launch orders.
        /// </summary>
        /// <param name="solution">The solution.</param>
        /// <returns>true if successful, false otherwise</returns>
        string SendLaunchOrders(FiringSolution solution);
    }
}