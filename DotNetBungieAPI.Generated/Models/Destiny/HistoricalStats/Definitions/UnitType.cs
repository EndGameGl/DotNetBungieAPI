namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats.Definitions;

public enum UnitType : int
{
    None = 0,
    /// <summary>
    ///     Indicates the statistic is a simple count of something.
    /// </summary>
    Count = 1,
    /// <summary>
    ///     Indicates the statistic is a per game average.
    /// </summary>
    PerGame = 2,
    /// <summary>
    ///     Indicates the number of seconds
    /// </summary>
    Seconds = 3,
    /// <summary>
    ///     Indicates the number of points earned
    /// </summary>
    Points = 4,
    /// <summary>
    ///     Values represents a team ID
    /// </summary>
    Team = 5,
    /// <summary>
    ///     Values represents a distance (units to-be-determined)
    /// </summary>
    Distance = 6,
    /// <summary>
    ///     Ratio represented as a whole value from 0 to 100.
    /// </summary>
    Percent = 7,
    /// <summary>
    ///     Ratio of something, shown with decimal places
    /// </summary>
    Ratio = 8,
    /// <summary>
    ///     True or false
    /// </summary>
    Boolean = 9,
    /// <summary>
    ///     The stat is actually a weapon type.
    /// </summary>
    WeaponType = 10,
    /// <summary>
    ///     Indicates victory, defeat, or something in between.
    /// </summary>
    Standing = 11,
    /// <summary>
    ///     Number of milliseconds some event spanned. For example, race time, or lap time.
    /// </summary>
    Milliseconds = 12,
    /// <summary>
    ///     The value is a enumeration of the Completion Reason type.
    /// </summary>
    CompletionReason = 13
}
