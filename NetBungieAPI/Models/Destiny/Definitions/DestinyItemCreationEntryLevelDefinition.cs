using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions
{
    /// <summary>
    /// An overly complicated wrapper for the item level at which the item should spawn.
    /// </summary>
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
