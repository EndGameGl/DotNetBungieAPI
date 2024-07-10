namespace DotNetBungieAPI.Models.Destiny.Character;

/// <summary>
///     A minimal view of a character's equipped items, for the purpose of rendering a summary screen or showing the
///     character in 3D.
/// </summary>
public sealed record DestinyCharacterPeerView
{
    [JsonPropertyName("equipment")]
    public ReadOnlyCollection<DestinyItemPeerView> Equipment { get; init; } =
        ReadOnlyCollections<DestinyItemPeerView>.Empty;
}
