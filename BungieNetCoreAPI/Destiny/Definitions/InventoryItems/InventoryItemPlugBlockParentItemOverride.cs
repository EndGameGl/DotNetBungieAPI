using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemPlugBlockParentItemOverride : IDeepEquatable<InventoryItemPlugBlockParentItemOverride>
    {
        public ReadOnlyCollection<string> AdditionalEquipRequirementsDisplayStrings { get; }
        public string PipIcon { get; }

        [JsonConstructor]
        internal InventoryItemPlugBlockParentItemOverride(string[] additionalEquipRequirementsDisplayStrings, string pipIcon)
        {
            AdditionalEquipRequirementsDisplayStrings = additionalEquipRequirementsDisplayStrings.AsReadOnlyOrEmpty();
            PipIcon = pipIcon;
        }

        public bool DeepEquals(InventoryItemPlugBlockParentItemOverride other)
        {
            return other != null &&
                AdditionalEquipRequirementsDisplayStrings.DeepEqualsReadOnlySimpleCollection(other.AdditionalEquipRequirementsDisplayStrings) &&
                PipIcon == other.PipIcon;
        }
    }
}
