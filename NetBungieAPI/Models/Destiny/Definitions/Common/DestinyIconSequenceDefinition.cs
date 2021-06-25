using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Common
{
    public sealed record DestinyIconSequenceDefinition : IDeepEquatable<DestinyIconSequenceDefinition>
    {
        [JsonPropertyName("frames")]
        public ReadOnlyCollection<DestinyResource> Frames { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyResource>();

        public bool DeepEquals(DestinyIconSequenceDefinition other)
        {
            return Frames.DeepEqualsReadOnlySimpleCollection(other.Frames);
        }
    }
}