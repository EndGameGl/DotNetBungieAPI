using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemSocketState
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Plug { get; init; }
        public bool IsEnabled { get; init; }
        public bool IsVisible { get; init; }
        public ReadOnlyCollection<int> EnableFailIndexes { get; init; }

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
