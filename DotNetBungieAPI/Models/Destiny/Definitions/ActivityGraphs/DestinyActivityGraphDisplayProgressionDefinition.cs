using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Definitions.Progressions;

namespace DotNetBungieAPI.Models.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    ///     When a Graph needs to show active Progressions, this defines those objectives as well as an identifier.
    /// </summary>
    public sealed record DestinyActivityGraphDisplayProgressionDefinition
        : IDeepEquatable<DestinyActivityGraphDisplayProgressionDefinition>
    {
        [JsonPropertyName("id")] public uint Id { get; init; }

        [JsonPropertyName("progressionHash")]
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; init; } =
            DefinitionHashPointer<DestinyProgressionDefinition>.Empty;

        public bool DeepEquals(DestinyActivityGraphDisplayProgressionDefinition other)
        {
            return other != null &&
                   Id == other.Id &&
                   Progression.DeepEquals(other.Progression);
        }
    }
}