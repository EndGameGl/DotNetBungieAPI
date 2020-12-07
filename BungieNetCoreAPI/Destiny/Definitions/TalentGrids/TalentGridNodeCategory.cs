using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.TalentGrids
{
    public class TalentGridNodeCategory
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public string Identifier { get; }
        public bool IsLoreDriven { get; }
        public List<uint> NodeHashes { get; }

        [JsonConstructor]
        private TalentGridNodeCategory(DestinyDefinitionDisplayProperties displayProperties, string identifier, bool isLoreDriven, List<uint> nodeHashes)
        {
            DisplayProperties = displayProperties;
            Identifier = identifier;
            IsLoreDriven = isLoreDriven;
            NodeHashes = nodeHashes;
        }
    }
}
