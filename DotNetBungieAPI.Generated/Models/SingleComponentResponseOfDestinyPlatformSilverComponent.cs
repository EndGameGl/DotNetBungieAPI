namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyPlatformSilverComponent
{
    [JsonPropertyName("data")]
    public Destiny.Components.Inventory.DestinyPlatformSilverComponent Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool Disabled { get; set; }
}
