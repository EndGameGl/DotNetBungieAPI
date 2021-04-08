using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorAction : IDeepEquatable<VendorAction>
    {
        public string Description { get; init; }
        public int ExecuteSeconds { get; init; }
        public string Icon { get; init; }
        public string Name { get; init; }
        public string Verb { get; init; }
        public bool IsPositive { get; init; }
        public string ActionId { get; init; }
        public uint ActionHash { get; init; }
        public bool AutoPerformAction { get; init; }

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
