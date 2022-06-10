namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent
{
    [JsonPropertyName("data")]
    public Dictionary<uint, Destiny.Responses.PublicDestinyVendorSaleItemSetComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool Disabled { get; set; }
}
