using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMaterialRequirement
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public bool DeleteOnAction { get; }
        public int Count { get; }
        public bool OmitFromRequirements { get; }

        [JsonConstructor]
        internal DestinyMaterialRequirement(uint itemHash, bool deleteOnAction, int count, bool omitFromRequirements)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            DeleteOnAction = deleteOnAction;
            Count = count;
            OmitFromRequirements = omitFromRequirements;
        }
    }
}
