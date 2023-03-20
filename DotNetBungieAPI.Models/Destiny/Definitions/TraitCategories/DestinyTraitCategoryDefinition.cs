using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Traits;

namespace DotNetBungieAPI.Models.Destiny.Definitions.TraitCategories;

[DestinyDefinition(DefinitionsEnum.DestinyTraitCategoryDefinition)]
public sealed record DestinyTraitCategoryDefinition : IDestinyDefinition,
    IDeepEquatable<DestinyTraitCategoryDefinition>
{
    /// <summary>
    ///     String for this trait category
    /// </summary>
    [JsonPropertyName("traitCategoryId")]
    public string TraitCategoryId { get; init; }

    /// <summary>
    ///     Traits that are in this category
    /// </summary>
    [JsonPropertyName("traitHashes")]
    public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyTraitDefinition>>.Empty;

    /// <summary>
    ///     Possible trait strings for searching in this category
    /// </summary>
    [JsonPropertyName("traitIds")]
    public ReadOnlyCollection<string> TraitIds { get; init; } = ReadOnlyCollections<string>.Empty;

    public bool DeepEquals(DestinyTraitCategoryDefinition other)
    {
        return other != null &&
               TraitCategoryId == other.TraitCategoryId &&
               Traits.DeepEqualsReadOnlyCollections(other.Traits) &&
               TraitIds.DeepEqualsReadOnlySimpleCollection(other.TraitIds) &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyTraitCategoryDefinition;

    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")] public uint Hash { get; init; }

    [JsonPropertyName("index")] public int Index { get; init; }

    [JsonPropertyName("redacted")] public bool Redacted { get; init; }
}