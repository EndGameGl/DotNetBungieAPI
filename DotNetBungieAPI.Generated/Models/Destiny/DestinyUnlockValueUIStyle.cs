namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     If you're showing an unlock value in the UI, this is the format in which it should be shown. You'll have to build your own algorithms on the client side to determine how best to render these options.
/// </summary>
public enum DestinyUnlockValueUIStyle : int
{
    /// <summary>
    ///     Generally, Automatic means "Just show the number"
    /// </summary>
    Automatic = 0,

    /// <summary>
    ///     Show the number as a fractional value. For this to make sense, the value being displayed should have a comparable upper bound, like the progress to the next level of a Progression.
    /// </summary>
    Fraction = 1,

    /// <summary>
    ///     Show the number as a checkbox. 0 Will mean unchecked, any other value will mean checked.
    /// </summary>
    Checkbox = 2,

    /// <summary>
    ///     Show the number as a percentage. For this to make sense, the value being displayed should have a comparable upper bound, like the progress to the next level of a Progression.
    /// </summary>
    Percentage = 3,

    /// <summary>
    ///     Show the number as a date and time. The number will be the number of seconds since the Unix Epoch (January 1st, 1970 at midnight UTC). It'll be up to you to convert this into a date and time format understandable to the user in their time zone.
    /// </summary>
    DateTime = 4,

    /// <summary>
    ///     Show the number as a floating point value that represents a fraction, where 0 is min and 1 is max. For this to make sense, the value being displayed should have a comparable upper bound, like the progress to the next level of a Progression.
    /// </summary>
    FractionFloat = 5,

    /// <summary>
    ///     Show the number as a straight-up integer.
    /// </summary>
    Integer = 6,

    /// <summary>
    ///     Show the number as a time duration. The value will be returned as seconds.
    /// </summary>
    TimeDuration = 7,

    /// <summary>
    ///     Don't bother showing the value at all, it's not easily human-interpretable, and used for some internal purpose.
    /// </summary>
    Hidden = 8,

    /// <summary>
    ///     Example: "1.5x"
    /// </summary>
    Multiplier = 9,

    /// <summary>
    ///     Show the value as a series of green pips, like the wins in a Trials of Osiris score card.
    /// </summary>
    GreenPips = 10,

    /// <summary>
    ///     Show the value as a series of red pips, like the losses in a Trials of Osiris score card.
    /// </summary>
    RedPips = 11,

    /// <summary>
    ///     Show the value as a percentage. For example: "51%" - Does no division, only appends '%'
    /// </summary>
    ExplicitPercentage = 12,

    /// <summary>
    ///     Show the value as a floating-point number. For example: "4.52" NOTE: Passed along from Investment as whole number with last two digits as decimal values (452 -> 4.52)
    /// </summary>
    RawFloat = 13
}
