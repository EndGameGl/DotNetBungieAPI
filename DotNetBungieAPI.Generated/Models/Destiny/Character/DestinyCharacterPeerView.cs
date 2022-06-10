namespace DotNetBungieAPI.Generated.Models.Destiny.Character;

/// <summary>
///     A minimal view of a character's equipped items, for the purpose of rendering a summary screen or showing the character in 3D.
/// </summary>
public class DestinyCharacterPeerView
{
    [JsonPropertyName("equipment")]
    public List<Destiny.Character.DestinyItemPeerView> Equipment { get; set; }
}
