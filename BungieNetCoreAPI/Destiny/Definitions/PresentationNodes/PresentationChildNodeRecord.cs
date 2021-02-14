using BungieNetCoreAPI.Destiny.Definitions.Records;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.PresentationNodes
{
    public class PresentationChildNodeRecord : IDeepEquatable<PresentationChildNodeRecord>
    {
        public DefinitionHashPointer<DestinyRecordDefinition> Record { get; }

        [JsonConstructor]
        internal PresentationChildNodeRecord(uint recordHash)
        {
            Record = new DefinitionHashPointer<DestinyRecordDefinition>(recordHash, DefinitionsEnum.DestinyRecordDefinition);
        }

        public bool DeepEquals(PresentationChildNodeRecord other)
        {
            return other != null && Record.DeepEquals(other.Record);
        }
    }
}
