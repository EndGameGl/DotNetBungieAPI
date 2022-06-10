namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyItemPerksComponent
{
    [JsonPropertyName("data")]
    public Destiny.Entities.Items.DestinyItemPerksComponent Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool Disabled { get; set; }
}
