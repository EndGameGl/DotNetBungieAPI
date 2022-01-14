namespace DotNetBungieAPI.Generated.Models;

public sealed class SingleComponentResponseOfDestinyItemReusablePlugsComponent
{

    [JsonPropertyName("data")]
    public Destiny.Components.Items.DestinyItemReusablePlugsComponent Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
