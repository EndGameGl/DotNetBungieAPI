namespace DotNetBungieAPI.Generated.Models;

public sealed class SingleComponentResponseOfDestinyItemTalentGridComponent
{

    [JsonPropertyName("data")]
    public Destiny.Entities.Items.DestinyItemTalentGridComponent Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
