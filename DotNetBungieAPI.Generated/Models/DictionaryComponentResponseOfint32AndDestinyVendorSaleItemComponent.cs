using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent
{

    [JsonPropertyName("data")]
    public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
