using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Vendors
{
    public class VendorAction : IDeepEquatable<VendorAction>
    {
        public string Description { get; }
        public int ExecuteSeconds { get; }
        public string Icon { get; }
        public string Name { get; }
        public string Verb { get; }
        public bool IsPositive { get; }
        public string ActionId { get; }
        public uint ActionHash { get; }
        public bool AutoPerformAction { get; }

        [JsonConstructor]
        internal VendorAction(string description, int executeSeconds, string icon, string name, string verb, bool isPositive, string actionId, uint actionHash, 
            bool autoPerformAction)
        {
            Description = description;
            ExecuteSeconds = executeSeconds;
            Icon = icon;
            Name = name;
            Verb = verb;
            IsPositive = isPositive;
            ActionId = actionId;
            ActionHash = actionHash;
            AutoPerformAction = autoPerformAction;
        }

        public bool DeepEquals(VendorAction other)
        {
            return other != null &&
                   Description == other.Description &&
                   ExecuteSeconds == other.ExecuteSeconds &&
                   Icon == other.Icon &&
                   Name == other.Name &&
                   Verb == other.Verb &&
                   IsPositive == other.IsPositive &&
                   ActionId == other.ActionId &&
                   ActionHash == other.ActionHash &&
                   AutoPerformAction == other.AutoPerformAction;
        }
    }
}
