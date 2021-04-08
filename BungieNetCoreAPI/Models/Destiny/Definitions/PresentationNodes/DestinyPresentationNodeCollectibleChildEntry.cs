using NetBungieAPI.Models.Destiny.Definitions.Collectibles;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.PresentationNodes
{
    public sealed record DestinyPresentationNodeCollectibleChildEntry : IDeepEquatable<DestinyPresentationNodeCollectibleChildEntry>
    {
        [JsonPropertyName("collectibleHash")]
        public DefinitionHashPointer<DestinyCollectibleDefinition> Collectible { get; init; } = DefinitionHashPointer<DestinyCollectibleDefinition>.Empty;

        public bool DeepEquals(DestinyPresentationNodeCollectibleChildEntry other)
        {
            return other != null && Collectible.DeepEquals(other.Collectible);
        }
    }
}
