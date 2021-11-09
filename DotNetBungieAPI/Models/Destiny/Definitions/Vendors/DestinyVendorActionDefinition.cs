namespace DotNetBungieAPI.Models.Destiny.Definitions.Vendors
{
    /// <summary>
    ///     If a vendor can ever end up performing actions, these are the properties that will be related to those actions. I'm
    ///     not going to bother documenting this yet, as it is unused and unclear if it will ever be used... but in case it is
    ///     ever populated and someone finds it useful, it is defined here.
    /// </summary>
    public sealed record DestinyVendorActionDefinition : IDeepEquatable<DestinyVendorActionDefinition>
    {
        [JsonPropertyName("description")] public string Description { get; init; }

        [JsonPropertyName("executeSeconds")] public int ExecuteSeconds { get; init; }

        [JsonPropertyName("icon")] public BungieNetResource Icon { get; init; }

        [JsonPropertyName("name")] public string Name { get; init; }

        [JsonPropertyName("verb")] public string Verb { get; init; }

        [JsonPropertyName("isPositive")] public bool IsPositive { get; init; }

        [JsonPropertyName("actionId")] public string ActionId { get; init; }

        [JsonPropertyName("actionHash")] public uint ActionHash { get; init; }

        [JsonPropertyName("autoPerformAction")]
        public bool AutoPerformAction { get; init; }

        public bool DeepEquals(DestinyVendorActionDefinition other)
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