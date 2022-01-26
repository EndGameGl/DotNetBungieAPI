namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyProfileCollectiblesComponent : IDeepEquatable<SingleComponentResponseOfDestinyProfileCollectiblesComponent>
{
    [JsonPropertyName("data")]
    public Destiny.Components.Collectibles.DestinyProfileCollectiblesComponent Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(SingleComponentResponseOfDestinyProfileCollectiblesComponent? other)
    {
        return other is not null &&
               (Data is not null ? Data.DeepEquals(other.Data) : other.Data is null) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }
}