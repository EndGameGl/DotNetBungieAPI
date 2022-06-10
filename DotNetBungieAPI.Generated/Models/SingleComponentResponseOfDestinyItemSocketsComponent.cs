namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyItemSocketsComponent
{
    [JsonPropertyName("data")]
    public Destiny.Entities.Items.DestinyItemSocketsComponent? Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting? Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
