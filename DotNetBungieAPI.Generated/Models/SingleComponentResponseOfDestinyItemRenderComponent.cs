namespace DotNetBungieAPI.Generated.Models;

public sealed class SingleComponentResponseOfDestinyItemRenderComponent
{

    [JsonPropertyName("data")]
    public Destiny.Entities.Items.DestinyItemRenderComponent Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
