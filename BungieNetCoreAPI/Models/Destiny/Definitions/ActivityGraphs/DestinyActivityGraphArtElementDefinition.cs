using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    /// These Art Elements are meant to represent one-off visual effects overlaid on the map. Currently, we do not have a pipeline to import the assets for these overlays, so this info exists as a placeholder for when such a pipeline exists (if it ever will)
    /// </summary>
    public sealed record DestinyActivityGraphArtElementDefinition : IDeepEquatable<DestinyActivityGraphArtElementDefinition>
    {
        /// <summary>
        /// The position on the map of the art element.
        /// </summary>
        [JsonPropertyName("position")]
        public DestinyPositionDefinition Position { get; init; }

        public bool DeepEquals(DestinyActivityGraphArtElementDefinition other)
        {
            return other != null && Position.DeepEquals(other.Position);
        }
    }
}
