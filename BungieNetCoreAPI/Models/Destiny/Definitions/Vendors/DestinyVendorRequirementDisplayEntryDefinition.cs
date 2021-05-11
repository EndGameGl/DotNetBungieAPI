using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    /// <summary>
    /// The localized properties of the RequirementsDisplay, allowing information about the requirement or item being featured to be seen.
    /// </summary>
    public sealed record
        DestinyVendorRequirementDisplayEntryDefinition : IDeepEquatable<DestinyVendorRequirementDisplayEntryDefinition>
    {
        [JsonPropertyName("icon")] public string Icon { get; init; }
        [JsonPropertyName("name")] public string Name { get; init; }
        [JsonPropertyName("source")] public string Source { get; init; }
        [JsonPropertyName("type")] public string Type { get; init; }

        public bool DeepEquals(DestinyVendorRequirementDisplayEntryDefinition other)
        {
            return other != null &&
                   Icon == other.Icon &&
                   Name == other.Name &&
                   Source == other.Source &&
                   Type == other.Type;
        }
    }
}