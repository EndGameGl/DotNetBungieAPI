using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Objectives
{
    public class DestinyObjectiveStatEntryDefinition : IDeepEquatable<DestinyObjectiveStatEntryDefinition>
    {
        [JsonPropertyName("stat")]
        public DestinyItemInvestmentStatDefinition Stat { get; init; }
        [JsonPropertyName("style")]
        public DestinyObjectiveGrantStyle Style { get; init; }

        public bool DeepEquals(DestinyObjectiveStatEntryDefinition other)
        {
            return other != null &&
                   (Stat != null ? Stat.DeepEquals(other.Stat) : other.Stat == null) &&
                   Style == other.Style;
        }
    }
}
