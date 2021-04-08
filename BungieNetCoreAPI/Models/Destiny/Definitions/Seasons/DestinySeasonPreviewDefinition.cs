using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Seasons
{
    public sealed record DestinySeasonPreviewDefinition : IDeepEquatable<DestinySeasonPreviewDefinition>
    {
        [JsonPropertyName("description")]
        public string Description { get; init; }
        [JsonPropertyName("linkPath")]
        public string LinkPath { get; init; }
        [JsonPropertyName("videoLink")]
        public string VideoLink { get; init; }
        [JsonPropertyName("images")]
        public ReadOnlyCollection<DestinySeasonPreviewImageDefinition> Images { get; init; } = Defaults.EmptyReadOnlyCollection<DestinySeasonPreviewImageDefinition>();

        public bool DeepEquals(DestinySeasonPreviewDefinition other)
        {
            return other != null &&
                   Description == other.Description &&
                   LinkPath == other.LinkPath &&
                   VideoLink == other.VideoLink &&
                   Images.DeepEqualsReadOnlyCollections(other.Images);
        }
    }
}
