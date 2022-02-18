using DotNetBungieAPI.Models.Destiny.Definitions.Collectibles;

namespace DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

public sealed record
    DestinyPresentationNodeCollectibleChildEntry : IDeepEquatable<DestinyPresentationNodeCollectibleChildEntry>
{
    [JsonPropertyName("collectibleHash")]
    public DefinitionHashPointer<DestinyCollectibleDefinition> Collectible { get; init; } =
        DefinitionHashPointer<DestinyCollectibleDefinition>.Empty;
    
    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; init; }

    public bool DeepEquals(DestinyPresentationNodeCollectibleChildEntry other)
    {
        return other != null && 
               Collectible.DeepEquals(other.Collectible) &&
               NodeDisplayPriority == other.NodeDisplayPriority;
    }
}