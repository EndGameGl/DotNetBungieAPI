namespace DotNetBungieAPI.Models.Destiny.Definitions.Common
{
    public sealed record DestinyIconSequenceDefinition : IDeepEquatable<DestinyIconSequenceDefinition>
    {
        [JsonPropertyName("frames")]
        public ReadOnlyCollection<BungieNetResource> Frames { get; init; } =
            ReadOnlyCollections<BungieNetResource>.Empty;

        public bool DeepEquals(DestinyIconSequenceDefinition other)
        {
            return Frames.DeepEqualsReadOnlySimpleCollection(other.Frames);
        }
    }
}