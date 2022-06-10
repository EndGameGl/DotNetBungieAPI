namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyProfileRecordsComponent
{
    [JsonPropertyName("data")]
    public Destiny.Components.Records.DestinyProfileRecordsComponent? Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting? Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
