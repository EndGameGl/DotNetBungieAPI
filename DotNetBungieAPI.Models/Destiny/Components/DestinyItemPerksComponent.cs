using DotNetBungieAPI.Models.Destiny.Perks;

namespace DotNetBungieAPI.Models.Destiny.Components;

/// <summary>
///     Instanced items can have perks: benefits that the item bestows.
///     <para />
///     These are related to DestinySandboxPerkDefinition, and sometimes - but not always - have human readable info. When
///     they do, they are the icons and text that you see in an item's tooltip.
///     <para />
///     Talent Grids, Sockets, and the item itself can apply Perks, which are then summarized here for your convenience.
/// </summary>
public sealed record DestinyItemPerksComponent
{
    /// <summary>
    ///     The list of perks to display in an item tooltip - and whether or not they have been activated.
    /// </summary>
    [JsonPropertyName("perks")]
    public ReadOnlyCollection<DestinyPerkReference> Perks { get; init; } =
        ReadOnlyCollections<DestinyPerkReference>.Empty;
}
