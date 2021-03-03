using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyItemPlug
    {
        public ReadOnlyCollection<DestinyObjectiveProgress> PlugObjectives { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; }
        public bool CanInsert { get; }
        public bool IsEnabled { get; }
        public ReadOnlyCollection<int> InsertFailIndexes { get; }
        public ReadOnlyCollection<int> EnableFailIndexes { get; }

        [JsonConstructor]
        internal ComponentDestinyItemPlug(DestinyObjectiveProgress[] plugObjectives, uint plugItemHash, bool canInsert, bool enabled, int[] insertFailIndexes,
            int[] enableFailIndexes)
        {
            PlugObjectives = plugObjectives.AsReadOnlyOrEmpty();
            PlugItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(plugItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            CanInsert = canInsert;
            IsEnabled = enabled;
            InsertFailIndexes = insertFailIndexes.AsReadOnlyOrEmpty();
            EnableFailIndexes = enableFailIndexes.AsReadOnlyOrEmpty();
        }
    }
}
