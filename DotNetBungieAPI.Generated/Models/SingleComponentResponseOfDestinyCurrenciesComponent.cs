namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyCurrenciesComponent
{
    [JsonPropertyName("data")]
    public Destiny.Components.Inventory.DestinyCurrenciesComponent? Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
