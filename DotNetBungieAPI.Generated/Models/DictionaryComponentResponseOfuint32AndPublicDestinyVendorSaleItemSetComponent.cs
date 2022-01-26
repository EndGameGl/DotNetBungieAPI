namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent : IDeepEquatable<DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent>
{
    [JsonPropertyName("data")]
    public Dictionary<uint, Destiny.Responses.PublicDestinyVendorSaleItemSetComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent? other)
    {
        return other is not null &&
               Data.DeepEqualsDictionary(other.Data) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }
}