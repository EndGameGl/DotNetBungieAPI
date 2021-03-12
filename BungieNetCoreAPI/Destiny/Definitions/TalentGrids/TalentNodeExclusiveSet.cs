using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.TalentGrids
{
    public class TalentNodeExclusiveSet : IDeepEquatable<TalentNodeExclusiveSet>
    {
        public ReadOnlyCollection<int> NodeIndexes { get; }

        [JsonConstructor]
        internal TalentNodeExclusiveSet(int[] nodeIndexes)
        {
            NodeIndexes = nodeIndexes.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(TalentNodeExclusiveSet other)
        {
            return other != null &&
                   NodeIndexes.DeepEqualsReadOnlySimpleCollection(other.NodeIndexes);
        }
    }
}
