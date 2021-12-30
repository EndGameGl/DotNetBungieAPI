using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent
{

    [JsonPropertyName("data")]
    public Dictionary<int, Destiny.Components.Items.DestinyItemPlugObjectivesComponent> Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
