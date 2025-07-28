namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyItemObjectivesComponent
{
    [JsonPropertyName("data")]
    public Destiny.Entities.Items.DestinyItemObjectivesComponent? Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
