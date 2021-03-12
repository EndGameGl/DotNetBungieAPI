using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.TalentGrids
{
    public class TalentGridNodeCategory : IDeepEquatable<TalentGridNodeCategory>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public string Identifier { get; }
        public bool IsLoreDriven { get; }
        public ReadOnlyCollection<uint> NodeHashes { get; }

        [JsonConstructor]
        internal TalentGridNodeCategory(DestinyDefinitionDisplayProperties displayProperties, string identifier, bool isLoreDriven, uint[] nodeHashes)
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
