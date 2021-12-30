using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent
{

    [JsonPropertyName("data")]
    public Dictionary<uint, Destiny.Responses.PersonalDestinyVendorSaleItemSetComponent> Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
