using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.SocketCategories;

namespace DotNetBungieAPI.Models.Destiny.Definitions.SocketTypes;

/// <summary>
///     All Sockets have a "Type": a set of common properties that determine when the socket allows Plugs to be inserted,
///     what Categories of Plugs can be inserted, and whether the socket is even visible at all given the current
///     game/character/account state.
///     <para />
///     See DestinyInventoryItemDefinition for more information about Socketed items and Plugs.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinySocketTypeDefinition)]
public sealed record DestinySocketTypeDefinition : IDestinyDefinition, IDeepEquatable<DestinySocketTypeDefinition>
{
    /// <summary>
    ///     There are fields for this display data, but they appear to be unpopulated as of now. I am not sure where in the UI
    ///     these would show if they even were populated, but I will continue to return this data in case it becomes useful.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     Defines what happens when a plug is inserted into sockets of this type.
    /// </summary>
    [JsonPropertyName("insertAction")]
    public DestinyInsertPlugActionDefinition InsertAction { get; init; }

    /// <summary>
    ///     A list of Plug "Categories" that are allowed to be plugged into sockets of this type.
    ///     <para />
    ///     These should be compared against a given plug item's DestinyInventoryItemDefinition.plug.plugCategoryHash, which
    ///     indicates the plug item's category.
    ///     <para />
    ///     If the plug's category matches any whitelisted plug, or if the whitelist is empty, it is allowed to be inserted.
    /// </summary>
    [JsonPropertyName("plugWhitelist")]
    public ReadOnlyCollection<DestinyPlugWhitelistEntryDefinition> PlugWhitelist { get; init; } =
        ReadOnlyCollections<DestinyPlugWhitelistEntryDefinition>.Empty;

    [JsonPropertyName("socketCategoryHash")]
    public DefinitionHashPointer<DestinySocketCategoryDefinition> SocketCategory { get; init; } =
        DefinitionHashPointer<DestinySocketCategoryDefinition>.Empty;

    /// <summary>
    ///     Sometimes a socket isn't visible. These are some of the conditions under which sockets of this type are not
    ///     visible. Unfortunately, the truth of visibility is much, much more complex. Best to rely on the live data for
    ///     whether the socket is visible and enabled.
    /// </summary>
    [JsonPropertyName("visibility")]
    public DestinySocketVisibility Visibility { get; init; }

    [JsonPropertyName("alwaysRandomizeSockets")]
    public bool AlwaysRandomizeSockets { get; init; }

    [JsonPropertyName("isPreviewEnabled")] public bool IsPreviewEnabled { get; init; }

    [JsonPropertyName("hideDuplicateReusablePlugs")]
    public bool HideDuplicateReusablePlugs { get; init; }

    /// <summary>
    ///     This property indicates if the socket type determines whether Emblem icons and nameplates should be overridden by
    ///     the inserted plug item's icon and nameplate.
    /// </summary>
    [JsonPropertyName("overridesUiAppearance")]
    public bool OverridesUiAppearance { get; init; }

    [JsonPropertyName("avoidDuplicatesOnInitialization")]
    public bool AvoidDuplicatesOnInitialization { get; init; }

    [JsonPropertyName("currencyScalars")]
    public ReadOnlyCollection<DestinySocketTypeScalarMaterialRequirementEntry> CurrencyScalars { get; init; } =
        ReadOnlyCollections<DestinySocketTypeScalarMaterialRequirementEntry>.Empty;

    public bool DeepEquals(DestinySocketTypeDefinition other)
    {
        return other != null &&
               AlwaysRandomizeSockets == other.AlwaysRandomizeSockets &&
               AvoidDuplicatesOnInitialization == other.AvoidDuplicatesOnInitialization &&
               HideDuplicateReusablePlugs == other.HideDuplicateReusablePlugs &&
               IsPreviewEnabled == other.IsPreviewEnabled &&
               OverridesUiAppearance == other.OverridesUiAppearance &&
               SocketCategory.DeepEquals(other.SocketCategory) &&
               Visibility == other.Visibility &&
               DisplayProperties.DeepEquals(other.DisplayProperties) &&
               InsertAction.DeepEquals(other.InsertAction) &&
               CurrencyScalars.DeepEqualsReadOnlyCollections(other.CurrencyScalars) &&
               PlugWhitelist.DeepEqualsReadOnlyCollections(other.PlugWhitelist) &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinySocketTypeDefinition;
    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
    [JsonPropertyName("hash")] public uint Hash { get; init; }
    [JsonPropertyName("index")] public int Index { get; init; }
    [JsonPropertyName("redacted")] public bool Redacted { get; init; }
}