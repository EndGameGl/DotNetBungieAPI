namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     An artificial construct provided by Bungie.Net, where we attempt to group talent nodes by functionality.
/// <para />
///     This is a single set of references to Talent Nodes that share a common trait or purpose.
/// </summary>
public sealed class DestinyTalentNodeCategory
{
    /// <summary>
    ///     Mostly just for debug purposes, but if you find it useful you can have it. This is BNet's manually created identifier for this category.
    /// </summary>
    [JsonPropertyName("identifier")]
    public string Identifier { get; init; }

    /// <summary>
    ///     If true, we found the localized content in a related DestinyLoreDefinition instead of local BNet localization files. This is mostly for ease of my own future investigations.
    /// </summary>
    [JsonPropertyName("isLoreDriven")]
    public bool IsLoreDriven { get; init; }

    /// <summary>
    ///     Will contain at least the "name", which will be the title of the category. We will likely not have description and an icon yet, but I'm going to keep my options open.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    /// <summary>
    ///     The set of all hash identifiers for Talent Nodes (DestinyTalentNodeDefinition) in this Talent Grid that are part of this Category.
    /// </summary>
    [JsonPropertyName("nodeHashes")]
    public uint[]? NodeHashes { get; init; }
}
