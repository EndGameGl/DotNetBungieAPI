using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.TalentGrids
{
    public class TalentNodeExclusiveSet : IDeepEquatable<TalentNodeExclusiveSet>
    {
        public ReadOnlyCollection<int> NodeIndexes { get; init; }

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
