using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemPlugComponent
    {
        public ReadOnlyCollection<DestinyObjectiveProgress> PlugObjectives { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; }
        public bool CanInsert { get; init; }
        public bool IsEnabled { get; init; }
        public ReadOnlyCollection<int> InsertFailIndexes { get; init; }
        public ReadOnlyCollection<int> EnableFailIndexes { get; init; }

        [JsonConstructor]
        internal DestinyItemPlugComponent(DestinyObjectiveProgress[] plugObjectives, uint plugItemHash, bool canInsert, bool enabled, int[] insertFailIndexes,
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
