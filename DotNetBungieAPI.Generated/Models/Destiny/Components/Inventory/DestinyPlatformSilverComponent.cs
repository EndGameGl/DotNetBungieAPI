namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Inventory;

public class DestinyPlatformSilverComponent : IDeepEquatable<DestinyPlatformSilverComponent>
{
    /// <summary>
    ///     If a Profile is played on multiple platforms, this is the silver they have for each platform, keyed by Membership Type.
    /// </summary>
    [JsonPropertyName("platformSilver")]
    public Dictionary<BungieMembershipType, Destiny.Entities.Items.DestinyItemComponent> PlatformSilver { get; set; }

    public bool DeepEquals(DestinyPlatformSilverComponent? other)
    {
        return other is not null &&
               PlatformSilver.DeepEqualsDictionary(other.PlatformSilver);
    }
}