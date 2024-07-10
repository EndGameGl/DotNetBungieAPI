using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.ItemTierTypes;

/// <summary>
///     Defines the tier type of an item. Mostly this provides human readable properties for types like Common, Rare,
///     etc...
///     <para />
///     It also provides some base data for infusion that could be useful.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyItemTierTypeDefinition)]
public sealed record DestinyItemTierTypeDefinition
    : IDestinyDefinition,
        IDisplayProperties,
        IDeepEquatable<DestinyItemTierTypeDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     If this tier defines infusion properties, they will be contained here.
    /// </summary>
    [JsonPropertyName("infusionProcess")]
    public DestinyItemTierTypeInfusionBlock InfusionProcess { get; init; }

    public bool DeepEquals(DestinyItemTierTypeDefinition other)
    {
        return other != null
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && InfusionProcess.DeepEquals(other.InfusionProcess)
            && Blacklisted == other.Blacklisted
            && Hash == other.Hash
            && Index == other.Index
            && Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyItemTierTypeDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
