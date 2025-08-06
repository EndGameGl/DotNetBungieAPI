namespace DotNetBungieAPI.Models.Destiny.Components.Inventory;

public sealed class DestinyPlatformSilverComponent
{
    /// <summary>
    ///     If a Profile is played on multiple platforms, this is the silver they have for each platform, keyed by Membership Type.
    /// </summary>
    [JsonPropertyName("platformSilver")]
    public Dictionary<BungieMembershipType, Destiny.Entities.Items.DestinyItemComponent>? PlatformSilver { get; init; }
}
