using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class SingleComponentResponseOfDestinyCollectiblesComponent
{

    [JsonPropertyName("data")]
    public Destiny.Components.Collectibles.DestinyCollectiblesComponent Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
