namespace DotNetBungieAPI.Generated.Models;

public sealed class SingleComponentResponseOfDestinyCollectiblesComponent
{

    [JsonPropertyName("data")]
    public Destiny.Components.Collectibles.DestinyCollectiblesComponent Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
