using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMaterialRequirement
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
        public bool DeleteOnAction { get; init; }
        public int Count { get; init; }
        public bool OmitFromRequirements { get; init; }

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
