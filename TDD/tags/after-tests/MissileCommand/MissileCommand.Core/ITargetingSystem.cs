namespace MissileCommand.Core
{
    public interface ITargetingSystem
    {
        /// <summary>
        /// Gets the geographic bias.
        /// </summary>
        /// <value>The geographic bias.</value>
        double GeographicBias { get; }
    }
}