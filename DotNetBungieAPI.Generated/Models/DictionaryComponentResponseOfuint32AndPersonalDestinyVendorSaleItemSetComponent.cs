namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent
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
}
