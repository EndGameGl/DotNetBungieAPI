namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyProfileTransitoryComponent
{
    [JsonPropertyName("data")]
    public Destiny.Components.Profiles.DestinyProfileTransitoryComponent? Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
