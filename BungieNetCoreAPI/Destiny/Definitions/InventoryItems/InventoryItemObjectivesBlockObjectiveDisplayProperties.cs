using BungieNetCoreAPI.Destiny.Definitions.Activities;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemObjectivesBlockObjectiveDisplayProperties : IDeepEquatable<InventoryItemObjectivesBlockObjectiveDisplayProperties>
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public bool DisplayOnItemPreviewScreen { get; }

        [JsonConstructor]
        internal InventoryItemObjectivesBlockObjectiveDisplayProperties(uint? activityHash, bool displayOnItemPreviewScreen)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            DisplayOnItemPreviewScreen = displayOnItemPreviewScreen;
        }

        public bool DeepEquals(InventoryItemObjectivesBlockObjectiveDisplayProperties other)
        {
            return other != null &&
                   Activity.DeepEquals(other.Activity) &&
                   DisplayOnItemPreviewScreen == other.DisplayOnItemPreviewScreen;
        }
    }
}
