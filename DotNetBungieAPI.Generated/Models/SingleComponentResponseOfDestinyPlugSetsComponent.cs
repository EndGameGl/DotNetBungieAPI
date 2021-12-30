using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class SingleComponentResponseOfDestinyPlugSetsComponent
{

    [JsonPropertyName("data")]
    public Destiny.Components.PlugSets.DestinyPlugSetsComponent Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
