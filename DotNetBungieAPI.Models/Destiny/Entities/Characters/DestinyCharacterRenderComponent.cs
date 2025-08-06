namespace DotNetBungieAPI.Models.Destiny.Entities.Characters;

/// <summary>
///     Only really useful if you're attempting to render the character's current appearance in 3D, this returns a bare minimum of information, pre-aggregated, that you'll need to perform that rendering. Note that you need to combine this with other 3D assets and data from our servers.
/// <para />
///     Examine the Javascript returned by https://bungie.net/sharedbundle/spasm to see how we use this data, but be warned: the rabbit hole goes pretty deep.
/// </summary>
public sealed class DestinyCharacterRenderComponent
{
    /// <summary>
    ///     Custom dyes, calculated by iterating over the character's equipped items. Useful for pre-fetching all of the dye data needed from our server.
    /// </summary>
    [JsonPropertyName("customDyes")]
    public Destiny.DyeReference[]? CustomDyes { get; init; }

    /// <summary>
    ///     This is actually something that Spasm.js *doesn't* do right now, and that we don't return assets for yet. This is the data about what character customization options you picked. You can combine this with DestinyCharacterCustomizationOptionDefinition to show some cool info, and hopefully someday to actually render a user's face in 3D. We'll see if we ever end up with time for that.
    /// </summary>
    [JsonPropertyName("customization")]
    public Destiny.Character.DestinyCharacterCustomization? Customization { get; init; }

    /// <summary>
    ///     A minimal view of:
    /// <para />
    ///     - Equipped items
    /// <para />
    ///     - The rendering-related custom options on those equipped items
    /// <para />
    ///     Combined, that should be enough to render all of the items on the equipped character.
    /// </summary>
    [JsonPropertyName("peerView")]
    public Destiny.Character.DestinyCharacterPeerView? PeerView { get; init; }
}
