using DotNetBungieAPI.Attributes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.MedalTiers;

/// <summary>
///     An artificial construct of our own creation, to try and put some order on top of Medals and keep them from being one giant, unmanageable and unsorted blob of stats.
///     <para />
///     Unfortunately, we haven't had time to do this evaluation yet in Destiny 2, so we're short on Medal Tiers. This will hopefully be updated over time, if Medals continue to exist.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyMedalTierDefinition)]
public sealed record DestinyMedalTierDefinition : IDestinyDefinition, IDeepEquatable<DestinyMedalTierDefinition>
{
    /// <summary>
    ///     If you're rendering medals by tier, render them in this order (ascending)
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; init; }

    /// <summary>
    ///     The name of the tier.
    /// </summary>
    [JsonPropertyName("tierName")]
    public string TierName { get; init; }

    public bool DeepEquals(DestinyMedalTierDefinition other)
    {
        return other != null &&
               Order == other.Order &&
               TierName == other.TierName &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyMedalTierDefinition;
    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")] public uint Hash { get; init; }

    [JsonPropertyName("index")] public int Index { get; init; }

    [JsonPropertyName("redacted")] public bool Redacted { get; init; }

    public void MapValues()
    {
    }

    public void SetPointerLocales(BungieLocales locale)
    {
    }
}