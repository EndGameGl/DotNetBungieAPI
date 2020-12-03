using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemObjectivesBlockObjectiveDisplayProperties
    {
        public bool DisplayOnItemPreviewScreen { get; }

        [JsonConstructor]
        private InventoryItemObjectivesBlockObjectiveDisplayProperties(bool displayOnItemPreviewScreen)
        {
            DisplayOnItemPreviewScreen = displayOnItemPreviewScreen;
        }
    }
}
