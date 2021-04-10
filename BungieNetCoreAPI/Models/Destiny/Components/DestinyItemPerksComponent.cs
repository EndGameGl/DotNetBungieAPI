using NetBungieAPI.Models.Destiny.Perks;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyItemPerksComponent
    {
        [JsonPropertyName("perks")]
        public ReadOnlyCollection<DestinyPerkReference> Perks { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyPerkReference>();
    }
}
