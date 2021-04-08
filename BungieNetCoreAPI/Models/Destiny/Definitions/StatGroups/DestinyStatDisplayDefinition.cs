using NetBungieAPI.Models.Destiny.Definitions.Stats;
using NetBungieAPI.Models.Interpolation;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.StatGroups
{
    public sealed record DestinyStatDisplayDefinition : IDeepEquatable<DestinyStatDisplayDefinition>
    {
        [JsonPropertyName("displayAsNumeric")]
        public bool DisplayAsNumeric { get; init; }
        [JsonPropertyName("displayInterpolation")]
        public ReadOnlyCollection<InterpolationPoint> DisplayInterpolation { get; init; } = Defaults.EmptyReadOnlyCollection<InterpolationPoint>();
        [JsonPropertyName("maximumValue")]
        public int MaximumValue { get; init; }
        [JsonPropertyName("statHash")]
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; init; } = DefinitionHashPointer<DestinyStatDefinition>.Empty;

        public bool DeepEquals(DestinyStatDisplayDefinition other)
        {
            return other != null &&
                   DisplayAsNumeric == other.DisplayAsNumeric &&
                   DisplayInterpolation.DeepEqualsReadOnlyCollections(other.DisplayInterpolation) &&
                   MaximumValue == other.MaximumValue &&
                   Stat.DeepEquals(other.Stat);
        }
    }
}
