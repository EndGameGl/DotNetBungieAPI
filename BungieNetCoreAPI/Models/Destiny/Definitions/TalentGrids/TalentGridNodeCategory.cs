using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.TalentGrids
{
    public class TalentGridNodeCategory : IDeepEquatable<TalentGridNodeCategory>
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public string Identifier { get; init; }
        public bool IsLoreDriven { get; init; }
        public ReadOnlyCollection<uint> NodeHashes { get; init; }

        [JsonConstructor]
        internal TalentGridNodeCategory(DestinyDisplayPropertiesDefinition displayProperties, string identifier, bool isLoreDriven, uint[] nodeHashes)
        {
            DisplayProperties = displayProperties;
            Identifier = identifier;
            IsLoreDriven = isLoreDriven;
            NodeHashes = nodeHashes.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(TalentGridNodeCategory other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Identifier == other.Identifier &&
                   IsLoreDriven == other.IsLoreDriven &&
                   NodeHashes.DeepEqualsReadOnlySimpleCollection(other.NodeHashes);
        }
    }
}
