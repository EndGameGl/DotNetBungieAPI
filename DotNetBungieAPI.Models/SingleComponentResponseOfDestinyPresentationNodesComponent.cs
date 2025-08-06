namespace DotNetBungieAPI.Models;

public sealed class SingleComponentResponseOfDestinyPresentationNodesComponent
{
    [JsonPropertyName("data")]
    public Destiny.Components.Presentation.DestinyPresentationNodesComponent? Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
