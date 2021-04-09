using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyPlatformSilverComponent
    {
        [JsonPropertyName("platformSilver")]
        public ReadOnlyDictionary<BungieMembershipType, DestinyItemComponent> PlatformSilver { get; init; } = Defaults.EmptyReadOnlyDictionary<BungieMembershipType, DestinyItemComponent>();
    }
}
