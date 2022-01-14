namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     A hint for how the presentation node should be displayed when shown in a list. How you use this is your UI is up to you.
/// </summary>
public enum DestinyPresentationDisplayStyle : int
{
    /// <summary>
    ///     Display the item as a category, through which sub-items are filtered.
    /// </summary>
    Category = 0,
    Badge = 1,
    Medals = 2,
    Collectible = 3,
    Record = 4
}
