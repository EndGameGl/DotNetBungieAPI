using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class DictionaryComponentResponseOfint64AndDestinyItemStatsComponent
{

    [JsonPropertyName("data")]
    public Dictionary<long, Destiny.Entities.Items.DestinyItemStatsComponent> Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
