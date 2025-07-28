namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyVendorComponent
{
    [JsonPropertyName("data")]
    public Destiny.Entities.Vendors.DestinyVendorComponent? Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
