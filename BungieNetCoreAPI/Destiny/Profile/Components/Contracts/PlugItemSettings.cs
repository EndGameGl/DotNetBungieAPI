using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class PlugItemSettings
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; }
        public bool CanInsert { get; }
        public bool IsEnabled { get; }

        [JsonConstructor]
        internal PlugItemSettings(uint plugItemHash, bool canInsert, bool enabled)
        {
            PlugItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(plugItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            CanInsert = canInsert;
            IsEnabled = enabled;
        }
    }
}
