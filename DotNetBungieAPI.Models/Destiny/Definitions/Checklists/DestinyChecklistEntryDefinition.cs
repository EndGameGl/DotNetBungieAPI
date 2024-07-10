using DotNetBungieAPI.Models.Destiny.Definitions.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.Destinations;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.Locations;
using DotNetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Checklists;

/// <summary>
///     The properties of an individual checklist item. Note that almost everything is optional: it is *highly* variable
///     what kind of data we'll actually be able to return: at times we may have no other relationships to entities at all.
///     <para />
///     Whatever UI you build, do it with the knowledge that any given entry might not actually be able to be associated
///     with some other Destiny entity.
/// </summary>
public sealed record DestinyChecklistEntryDefinition
    : IDeepEquatable<DestinyChecklistEntryDefinition>
{
    /// <summary>
    ///     The identifier for this Checklist entry. Guaranteed unique only within this Checklist Definition, and not
    ///     globally/for all checklists.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     Even if no other associations exist, we will give you *something* for display properties. In cases where we have no
    ///     associated entities, it may be as simple as a numerical identifier.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("destinationHash")]
    public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; init; } =
        DefinitionHashPointer<DestinyDestinationDefinition>.Empty;

    [JsonPropertyName("locationHash")]
    public DefinitionHashPointer<DestinyLocationDefinition> Location { get; init; } =
        DefinitionHashPointer<DestinyLocationDefinition>.Empty;

    /// <summary>
    ///     Note that a Bubble's hash doesn't uniquely identify a "top level" entity in Destiny. Only the combination of
    ///     location and bubble can uniquely identify a place in the world of Destiny: so if bubbleHash is populated,
    ///     locationHash must too be populated for it to have any meaning.
    /// </summary>
    [JsonPropertyName("bubbleHash")]
    public uint? BubbleHash { get; init; }

    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } =
        DefinitionHashPointer<DestinyActivityDefinition>.Empty;

    [JsonPropertyName("itemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    [JsonPropertyName("vendorHash")]
    public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } =
        DefinitionHashPointer<DestinyVendorDefinition>.Empty;

    [JsonPropertyName("vendorInteractionIndex")]
    public int? VendorInteractionIndex { get; init; }

    [JsonPropertyName("scope")]
    public DestinyScope Scope { get; init; }

    public bool DeepEquals(DestinyChecklistEntryDefinition other)
    {
        return other != null
            && BubbleHash == other.BubbleHash
            && Destination.DeepEquals(other.Destination)
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && Hash == other.Hash
            && Scope == other.Scope
            && Location.DeepEquals(other.Location)
            && Activity.DeepEquals(other.Activity)
            && Item.DeepEquals(other.Item)
            && Vendor.DeepEquals(other.Vendor)
            && VendorInteractionIndex == other.VendorInteractionIndex;
    }
}
