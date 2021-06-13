namespace NetBungieAPI.Models.Destiny.Definitions.ActivityModes
{
    /// <summary>
    /// Activity Modes are grouped into a few possible broad categories.
    /// </summary>
    public enum DestinyActivityModeCategory
    {
        /// <summary>
        /// Activities that are neither PVP nor PVE, such as social activities.
        /// </summary>
        None = 0,

        /// <summary>
        /// PvE activities, where you shoot aliens in the face.
        /// </summary>
        PvE = 1,

        /// <summary>
        /// PvP activities, where you shoot your "friends".
        /// </summary>
        PvP = 2,

        /// <summary>
        /// PVE competitive activities, where you shoot whoever you want whenever you want. Or run around collecting small glowing triangles.
        /// </summary>
        PvECompetitive = 3
    }
}