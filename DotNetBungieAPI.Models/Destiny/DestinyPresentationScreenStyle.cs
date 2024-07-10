namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     A hint for what screen should be shown when this presentation node is clicked into. How you use this is your UI is
///     up to you.
/// </summary>
public enum DestinyPresentationScreenStyle
{
    /// <summary>
    ///     Use the "default" view for the presentation nodes.
    /// </summary>
    Default = 0,

    /// <summary>
    ///     Show sub-items as "category sets". In-game, you'd see these as a vertical list of child presentation nodes - armor
    ///     sets for example - and the icons of items within those sets displayed horizontally.
    /// </summary>
    CategorySets = 1,

    /// <summary>
    ///     Show sub-items as Badges.
    /// </summary>
    Badge = 2
}
