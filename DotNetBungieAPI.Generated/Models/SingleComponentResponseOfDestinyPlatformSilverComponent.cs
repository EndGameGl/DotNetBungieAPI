namespace DotNetBungieAPI.Generated.Models;

public sealed class SingleComponentResponseOfDestinyPlatformSilverComponent
{

    [JsonPropertyName("data")]
    public Destiny.Components.Inventory.DestinyPlatformSilverComponent Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
