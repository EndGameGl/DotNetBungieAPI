namespace DotNetBungieAPI.Models;

public sealed class SingleComponentResponseOfDestinyProfileRecordsComponent
{
    [JsonPropertyName("data")]
    public Destiny.Components.Records.DestinyProfileRecordsComponent? Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
