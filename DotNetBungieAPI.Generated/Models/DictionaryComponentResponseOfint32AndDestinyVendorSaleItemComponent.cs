namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent : IDeepEquatable<DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent>
{
    [JsonPropertyName("data")]
    public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent? other)
    {
        return other is not null &&
               Data.DeepEqualsDictionary(other.Data) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }
}