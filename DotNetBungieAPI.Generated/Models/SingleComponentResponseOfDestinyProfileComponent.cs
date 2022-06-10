namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyProfileComponent
{
    [JsonPropertyName("data")]
    public Destiny.Entities.Profiles.DestinyProfileComponent? Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting? Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
