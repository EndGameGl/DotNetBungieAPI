using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    /// These Art Elements are meant to represent one-off visual effects overlaid on the map. Currently, we do not have a pipeline to import the assets for these overlays, so this info exists as a placeholder for when such a pipeline exists (if it ever will)
    /// </summary>
    public class ActivityGraphArtElementEntry : IDeepEquatable<ActivityGraphArtElementEntry>
    {
        /// <summary>
        /// The position on the map of the art element.
        /// </summary>
        public DestinyPosition Position { get; }

        [JsonConstructor]
        internal ActivityGraphArtElementEntry(DestinyPosition position)
        {
            Position = position;
        }

        public bool DeepEquals(ActivityGraphArtElementEntry other)
        {
            return other != null && Position.DeepEquals(other.Position);
        }
    }
}
