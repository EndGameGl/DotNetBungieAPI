using NetBungieApi.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyItemPeerView
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public ReadOnlyCollection<DyeReference> Dyes { get; }

        [JsonConstructor]
        internal DestinyItemPeerView(uint itemHash, DyeReference[] dyes)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Dyes = dyes.AsReadOnlyOrEmpty();
        }
    }
}
