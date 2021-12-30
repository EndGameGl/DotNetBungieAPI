using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Character;

public sealed class DestinyCharacterPeerView
{

    [JsonPropertyName("equipment")]
    public List<Destiny.Character.DestinyItemPeerView> Equipment { get; init; }
}
