using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Dictates a rule around whether the plug is enabled or insertable.
    /// <para/>
    /// In practice, the live Destiny data will refer to these entries by index.You can then look up that index in the appropriate property (enabledRules or insertionRules) to get the localized string for the failure message if it failed.
    /// </summary>
    public class InventoryItemPlugBlockRule : IDeepEquatable<InventoryItemPlugBlockRule>
    {
        public string FailureMessage { get; }

        [JsonConstructor]
        internal InventoryItemPlugBlockRule(string failureMessage)
        {
            FailureMessage = failureMessage;
        }

        public bool DeepEquals(InventoryItemPlugBlockRule other)
        {
            return other != null && FailureMessage == other.FailureMessage;
        }
    }
}
