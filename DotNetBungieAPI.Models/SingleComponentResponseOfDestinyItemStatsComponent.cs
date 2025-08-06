namespace DotNetBungieAPI.Models;

public sealed class SingleComponentResponseOfDestinyItemStatsComponent
{
    [JsonPropertyName("data")]
    public Destiny.Entities.Items.DestinyItemStatsComponent? Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
