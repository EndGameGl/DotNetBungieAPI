namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Sockets;

/// <summary>
///     All Sockets have a "Type": a set of common properties that determine when the socket allows Plugs to be inserted, what Categories of Plugs can be inserted, and whether the socket is even visible at all given the current game/character/account state.
/// <para />
///     See DestinyInventoryItemDefinition for more information about Socketed items and Plugs.
/// </summary>
public class DestinySocketTypeDefinition
{
    /// <summary>
    ///     There are fields for this display data, but they appear to be unpopulated as of now. I am not sure where in the UI these would show if they even were populated, but I will continue to return this data in case it becomes useful.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public object DisplayProperties { get; set; }

    /// <summary>
    ///     Defines what happens when a plug is inserted into sockets of this type.
    /// </summary>
    [JsonPropertyName("insertAction")]
    public object InsertAction { get; set; }

    /// <summary>
    ///     A list of Plug "Categories" that are allowed to be plugged into sockets of this type.
    /// <para />
    ///     These should be compared against a given plug item's DestinyInventoryItemDefinition.plug.plugCategoryHash, which indicates the plug item's category.
    /// <para />
    ///     If the plug's category matches any whitelisted plug, or if the whitelist is empty, it is allowed to be inserted.
    /// </summary>
    [JsonPropertyName("plugWhitelist")]
    public List<Destiny.Definitions.Sockets.DestinyPlugWhitelistEntryDefinition> PlugWhitelist { get; set; }

    [JsonPropertyName("socketCategoryHash")]
    public uint SocketCategoryHash { get; set; }

    /// <summary>
    ///     Sometimes a socket isn't visible. These are some of the conditions under which sockets of this type are not visible. Unfortunately, the truth of visibility is much, much more complex. Best to rely on the live data for whether the socket is visible and enabled.
    /// </summary>
    [JsonPropertyName("visibility")]
    public Destiny.DestinySocketVisibility Visibility { get; set; }

    [JsonPropertyName("alwaysRandomizeSockets")]
    public bool AlwaysRandomizeSockets { get; set; }

    [JsonPropertyName("isPreviewEnabled")]
    public bool IsPreviewEnabled { get; set; }

    [JsonPropertyName("hideDuplicateReusablePlugs")]
    public bool HideDuplicateReusablePlugs { get; set; }

    /// <summary>
    ///     This property indicates if the socket type determines whether Emblem icons and nameplates should be overridden by the inserted plug item's icon and nameplate.
    /// </summary>
    [JsonPropertyName("overridesUiAppearance")]
    public bool OverridesUiAppearance { get; set; }

    [JsonPropertyName("avoidDuplicatesOnInitialization")]
    public bool AvoidDuplicatesOnInitialization { get; set; }

    [JsonPropertyName("currencyScalars")]
    public List<Destiny.Definitions.Sockets.DestinySocketTypeScalarMaterialRequirementEntry> CurrencyScalars { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }
}
