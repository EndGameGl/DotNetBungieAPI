using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.RewardSources;

/// <summary>
///     Represents a heuristically-determined "item source" according to Bungie.net. These item sources are non-canonical:
///     we apply a combination of special configuration and often-fragile heuristics to attempt to discern whether an item
///     should be part of a given "source," but we have known cases of false positives and negatives due to our imperfect
///     heuristics.
///     <para />
///     Still, they provide a decent approximation for people trying to figure out how an item can be obtained.
///     DestinyInventoryItemDefinition refers to sources in the sourceDatas.sourceHashes property for all sources we
///     determined the item could spawn from.
///     <para />
///     An example in Destiny 1 of a Source would be "Nightfall". If an item has the "Nightfall" source associated with it,
///     it's extremely likely that you can earn that item while playing Nightfall, either during play or as an
///     after-completion reward.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyRewardSourceDefinition)]
public sealed record DestinyRewardSourceDefinition
    : IDestinyDefinition, IDisplayProperties, IDeepEquatable<DestinyRewardSourceDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     Sources are grouped into categories: common ways that items are provided. I hope to see this expand in Destiny 2
    ///     once we have time to generate accurate reward source data.
    /// </summary>
    [JsonPropertyName("category")]
    public DestinyRewardSourceCategory Category { get; init; }

    public bool DeepEquals(DestinyRewardSourceDefinition other)
    {
        return other != null &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyRewardSourceDefinition;
    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
    [JsonPropertyName("hash")] public uint Hash { get; init; }
    [JsonPropertyName("index")] public int Index { get; init; }
    [JsonPropertyName("redacted")] public bool Redacted { get; init; }
}