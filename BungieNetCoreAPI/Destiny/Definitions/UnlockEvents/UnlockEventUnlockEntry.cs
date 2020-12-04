using BungieNetCoreAPI.Destiny.Definitions.Unlocks;
using BungieNetCoreAPI.Destiny.Definitions.UnlockValues;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockEvents
{
    public class UnlockEventUnlockEntry
    {
        public DefinitionHashPointer<DestinyUnlockDefinition> Unlock { get; }
        public int SelectedValue { get; }
        public int ClearedValue { get; }
        public DefinitionHashPointer<DestinyUnlockValueDefinition> UnlockValue { get; }

        [JsonConstructor]
        private UnlockEventUnlockEntry(uint unlockHash, int selectedValue, int clearedValue, uint unlockValueHash)
        {
            Unlock = new DefinitionHashPointer<DestinyUnlockDefinition>(unlockHash, "DestinyUnlockDefinition");
            SelectedValue = selectedValue;
            ClearedValue = clearedValue;
            UnlockValue = new DefinitionHashPointer<DestinyUnlockValueDefinition>(unlockValueHash, "DestinyUnlockValueDefinition");
        }
    }
}
