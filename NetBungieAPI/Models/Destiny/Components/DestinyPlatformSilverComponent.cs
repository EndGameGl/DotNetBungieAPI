using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyPlatformSilverComponent
    {
        /// <summary>
        /// If a Profile is played on multiple platforms, this is the silver they have for each platform, keyed by Membership Type.
        /// </summary>
        [JsonPropertyName("platformSilver")]
        public ReadOnlyDictionary<BungieMembershipType, DestinyItemComponent> PlatformSilver { get; init; } = Defaults.EmptyReadOnlyDictionary<BungieMembershipType, DestinyItemComponent>();
    }
}
