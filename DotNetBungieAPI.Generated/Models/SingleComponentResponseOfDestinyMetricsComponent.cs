namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyMetricsComponent
{
    [JsonPropertyName("data")]
    public Destiny.Components.Metrics.DestinyMetricsComponent? Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
