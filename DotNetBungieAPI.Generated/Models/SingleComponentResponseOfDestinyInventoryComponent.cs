namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyInventoryComponent
{
    [JsonPropertyName("data")]
    public Destiny.Entities.Inventory.DestinyInventoryComponent? Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
