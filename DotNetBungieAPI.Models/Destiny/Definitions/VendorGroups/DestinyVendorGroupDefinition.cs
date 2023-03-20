using DotNetBungieAPI.Models.Attributes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.VendorGroups;

/// <summary>
///     BNet attempts to group vendors into similar collections. These groups aren't technically game canonical, but they
///     are helpful for filtering vendors or showing them organized into a clean view on a webpage or app.
///     <para />
///     These definitions represent the groups we've built. Unlike in Destiny 1, a Vendors' group may change dynamically as
///     the game state changes: thus, you will want to check DestinyVendorComponent responses to find a vendor's currently
///     active Group (if you care).
///     <para />
///     Using this will let you group your vendors in your UI in a similar manner to how we will do grouping in the
///     Companion.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyVendorGroupDefinition)]
public sealed record DestinyVendorGroupDefinition : IDestinyDefinition, IDeepEquatable<DestinyVendorGroupDefinition>
{
    /// <summary>
    ///     For now, a group just has a name.
    /// </summary>
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; init; }

    /// <summary>
    ///     The recommended order in which to render the groups, Ascending order.
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; init; }

    public bool DeepEquals(DestinyVendorGroupDefinition other)
    {
        return other != null &&
               CategoryName == other.CategoryName &&
               Order == other.Order &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyVendorGroupDefinition;
    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
    [JsonPropertyName("hash")] public uint Hash { get; init; }
    [JsonPropertyName("index")] public int Index { get; init; }
    [JsonPropertyName("redacted")] public bool Redacted { get; init; }
}