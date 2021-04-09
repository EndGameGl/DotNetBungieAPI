using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions
{
    public sealed record DestinyItemCreationEntryLevelDefinition : IDeepEquatable<DestinyItemCreationEntryLevelDefinition>
    {
        [JsonPropertyName("level")]
        public int Level { get; init; }

        public bool DeepEquals(DestinyItemCreationEntryLevelDefinition other)
        {
            return other != null &&
                   Level == other.Level;
        }
    }
}
