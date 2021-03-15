using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemSocketState
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Plug { get; }
        public bool IsEnabled { get; }
        public bool IsVisible { get; }
        public ReadOnlyCollection<int> EnableFailIndexes { get; }

        [JsonConstructor]
        internal DestinyItemSocketState(uint? plugHash, bool isEnabled, bool isVisible, int[] enableFailIndexes)
        {
            Plug = new DefinitionHashPointer<DestinyInventoryItemDefinition>(plugHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            IsEnabled = isEnabled;
            IsVisible = isVisible;
            EnableFailIndexes = enableFailIndexes.AsReadOnlyOrEmpty();
        }
    }
}
