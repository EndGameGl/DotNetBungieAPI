using NetBungieAPI.Destiny.Definitions.Unlocks;
using NetBungieAPI.Destiny.Definitions.UnlockValues;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.UnlockEvents
{
    public class UnlockEventUnlock : IDeepEquatable<UnlockEventUnlock>
    {
        public DefinitionHashPointer<DestinyUnlockDefinition> Unlock { get; }
        public int SelectedValue { get; }
        public int ClearedValue { get; }
        public DefinitionHashPointer<DestinyUnlockValueDefinition> UnlockValue { get; }

        [JsonConstructor]
        internal UnlockEventUnlock(uint unlockHash, int selectedValue, int clearedValue, uint unlockValueHash)
        {
            Unlock = new DefinitionHashPointer<DestinyUnlockDefinition>(unlockHash, DefinitionsEnum.DestinyUnlockDefinition);
            SelectedValue = selectedValue;
            ClearedValue = clearedValue;
            UnlockValue = new DefinitionHashPointer<DestinyUnlockValueDefinition>(unlockValueHash, DefinitionsEnum.DestinyUnlockValueDefinition);
        }

        public bool DeepEquals(UnlockEventUnlock other)
        {
            return other != null &&
                   Unlock.DeepEquals(other.Unlock) &&
                   SelectedValue == other.SelectedValue &&
                   ClearedValue == other.ClearedValue &&
                   UnlockValue.DeepEquals(other.UnlockValue);
        }
    }
}
