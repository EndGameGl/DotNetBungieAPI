using NetBungieApi.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.StatGroups
{
    public class StatGroupScaledStat : IDeepEquatable<StatGroupScaledStat>
    {
        public bool DisplayAsNumeric { get; }
        public ReadOnlyCollection<StatGroupInterpolation> DisplayInterpolation { get; }
        public int MaximumValue { get; }
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; }

        [JsonConstructor]
        internal StatGroupScaledStat(bool displayAsNumeric, StatGroupInterpolation[] displayInterpolation, int maximumValue, uint statHash)
        {
            DisplayAsNumeric = displayAsNumeric;
            DisplayInterpolation = displayInterpolation.AsReadOnlyOrEmpty();
            MaximumValue = maximumValue;
            Stat = new DefinitionHashPointer<DestinyStatDefinition>(statHash, DefinitionsEnum.DestinyStatDefinition);
        }

        public bool DeepEquals(StatGroupScaledStat other)
        {
            return other != null &&
                   DisplayAsNumeric == other.DisplayAsNumeric &&
                   DisplayInterpolation.DeepEqualsReadOnlyCollections(other.DisplayInterpolation) &&
                   MaximumValue == other.MaximumValue &&
                   Stat.DeepEquals(other.Stat);
        }
    }
}
