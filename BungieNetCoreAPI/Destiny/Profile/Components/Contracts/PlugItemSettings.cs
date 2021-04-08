using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class PlugItemSettings
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; }
        public bool CanInsert { get; init; }
        public bool IsEnabled { get; init; }

        [JsonConstructor]
        internal PlugItemSettings(uint plugItemHash, bool canInsert, bool enabled)
        {
            PlugItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(plugItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            CanInsert = canInsert;
            IsEnabled = enabled;
        }
    }
}
