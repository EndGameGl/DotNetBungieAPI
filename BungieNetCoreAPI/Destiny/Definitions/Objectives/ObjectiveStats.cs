using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Objectives
{
    public class ObjectiveStats : IDeepEquatable<ObjectiveStats>
    {
        public ObjectiveStat Stat { get; }
        public ObjectivePerksStyle Style { get; }

        [JsonConstructor]
        internal ObjectiveStats(ObjectiveStat stat, ObjectivePerksStyle style)
        {
            Stat = stat;
            Style = style;
        }

        public bool DeepEquals(ObjectiveStats other)
        {
            return other != null &&
                   (Stat != null ? Stat.DeepEquals(other.Stat) : other.Stat == null) &&
                   Style == other.Style;
        }
    }
}
