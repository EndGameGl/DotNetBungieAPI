using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class DictionaryComponentResponseOfint64AndDestinyCurrenciesComponent
{

    [JsonPropertyName("data")]
    public Dictionary<long, Destiny.Components.Inventory.DestinyCurrenciesComponent> Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
