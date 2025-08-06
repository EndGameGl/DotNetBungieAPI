namespace DotNetBungieAPI.Models;

public sealed class SingleComponentResponseOfDestinyItemPerksComponent
{
    [JsonPropertyName("data")]
    public Destiny.Entities.Items.DestinyItemPerksComponent? Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
