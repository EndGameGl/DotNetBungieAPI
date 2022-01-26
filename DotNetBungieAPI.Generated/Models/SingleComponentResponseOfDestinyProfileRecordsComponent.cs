namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyProfileRecordsComponent : IDeepEquatable<SingleComponentResponseOfDestinyProfileRecordsComponent>
{
    [JsonPropertyName("data")]
    public Destiny.Components.Records.DestinyProfileRecordsComponent Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(SingleComponentResponseOfDestinyProfileRecordsComponent? other)
    {
        return other is not null &&
               (Data is not null ? Data.DeepEquals(other.Data) : other.Data is null) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }
}