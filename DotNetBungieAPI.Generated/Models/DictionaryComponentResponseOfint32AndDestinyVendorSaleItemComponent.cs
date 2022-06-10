namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent
{
    [JsonPropertyName("data")]
    public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting? Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
