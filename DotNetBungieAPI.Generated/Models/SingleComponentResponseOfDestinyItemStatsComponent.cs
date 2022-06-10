namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyItemStatsComponent
{
    [JsonPropertyName("data")]
    public Destiny.Entities.Items.DestinyItemStatsComponent? Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting? Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
