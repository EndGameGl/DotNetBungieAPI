using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemPeerView
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
        public ReadOnlyCollection<DyeReference> Dyes { get; init; }

        [JsonConstructor]
        internal DestinyItemPeerView(uint itemHash, DyeReference[] dyes)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Dyes = dyes.AsReadOnlyOrEmpty();
        }
    }
}
