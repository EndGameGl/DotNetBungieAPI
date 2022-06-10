namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyKiosksComponent
{
    [JsonPropertyName("data")]
    public Destiny.Components.Kiosks.DestinyKiosksComponent? Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting? Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
