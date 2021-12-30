using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Character;

public sealed class DestinyItemPeerView
{

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }

    [JsonPropertyName("dyes")]
    public List<Destiny.DyeReference> Dyes { get; init; }
}
