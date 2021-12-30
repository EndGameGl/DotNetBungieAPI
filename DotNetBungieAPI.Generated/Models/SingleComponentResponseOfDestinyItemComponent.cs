using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class SingleComponentResponseOfDestinyItemComponent
{

    [JsonPropertyName("data")]
    public Destiny.Entities.Items.DestinyItemComponent Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
