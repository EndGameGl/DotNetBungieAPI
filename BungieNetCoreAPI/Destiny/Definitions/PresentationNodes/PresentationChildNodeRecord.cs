using BungieNetCoreAPI.Destiny.Definitions.Records;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.PresentationNodes
{
    public class PresentationChildNodeRecord
    {
        public DefinitionHashPointer<DestinyRecordDefinition> Record { get; }

        [JsonConstructor]
        private PresentationChildNodeRecord(uint recordHash)
        {
            Record = new DefinitionHashPointer<DestinyRecordDefinition>(recordHash, DefinitionsEnum.DestinyRecordDefinition);
        }
    }
}
