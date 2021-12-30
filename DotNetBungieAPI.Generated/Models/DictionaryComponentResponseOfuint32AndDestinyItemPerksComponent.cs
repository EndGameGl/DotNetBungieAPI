using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent
{

    [JsonPropertyName("data")]
    public Dictionary<uint, Destiny.Entities.Items.DestinyItemPerksComponent> Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
