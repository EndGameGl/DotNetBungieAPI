using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorAction
    {
        public string Description { get; }
        public int ExecuteSeconds { get; }
        public string Name { get; }
        public string Verb { get; }
        public bool IsPositive { get; }
        public string ActionId { get; }
        public uint ActionHash { get; }
        public bool AutoPerformAction { get; }

        [JsonConstructor]
        private VendorAction(string description, int executeSeconds, string name, string verb, bool isPositive, string actionId, uint actionHash, bool autoPerformAction)
        {
            Description = description;
            ExecuteSeconds = executeSeconds;
            Name = name;
            Verb = verb;
            IsPositive = isPositive;
            ActionId = actionId;
            ActionHash = actionHash;
            AutoPerformAction = autoPerformAction;
        }
    }
}
