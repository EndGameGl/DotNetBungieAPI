namespace DotNetBungieAPI.Generated.Models;

public sealed class SingleComponentResponseOfDestinyMetricsComponent
{

    [JsonPropertyName("data")]
    public Destiny.Components.Metrics.DestinyMetricsComponent Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
