using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent
{

    [JsonPropertyName("data")]
    public Dictionary<uint, Destiny.Entities.Items.DestinyItemTalentGridComponent> Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
