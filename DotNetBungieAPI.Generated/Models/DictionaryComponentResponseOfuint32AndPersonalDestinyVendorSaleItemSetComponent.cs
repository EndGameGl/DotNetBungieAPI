namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent : IDeepEquatable<DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent>
{
    [JsonPropertyName("data")]
    public Dictionary<uint, Destiny.Responses.PersonalDestinyVendorSaleItemSetComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent? other)
    {
        return other is not null &&
               Data.DeepEqualsDictionary(other.Data) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }
}