namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyProfileComponent : IDeepEquatable<SingleComponentResponseOfDestinyProfileComponent>
{
    [JsonPropertyName("data")]
    public Destiny.Entities.Profiles.DestinyProfileComponent Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(SingleComponentResponseOfDestinyProfileComponent? other)
    {
        return other is not null &&
               (Data is not null ? Data.DeepEquals(other.Data) : other.Data is null) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }
}