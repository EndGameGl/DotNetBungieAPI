using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.TraitCategories;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Traits;

[DestinyDefinition(DefinitionsEnum.DestinyTraitDefinition)]
public sealed record DestinyTraitDefinition : IDestinyDefinition, IDeepEquatable<DestinyTraitDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("traitCategoryId")] public string TraitCategoryId { get; init; }

    [JsonPropertyName("traitCategoryHash")]
    public DefinitionHashPointer<DestinyTraitCategoryDefinition> TraitCategory { get; init; }

    public bool DeepEquals(DestinyTraitDefinition other)
    {
        return other != null &&
               DisplayProperties.DeepEquals(other.DisplayProperties) &&
               TraitCategoryId == other.TraitCategoryId &&
               TraitCategory.DeepEquals(other.TraitCategory) &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyTraitDefinition;
    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")] public uint Hash { get; init; }

    [JsonPropertyName("index")] public int Index { get; init; }

    [JsonPropertyName("redacted")] public bool Redacted { get; init; }

    public void MapValues()
    {
        TraitCategory.TryMapValue();
    }

    public void SetPointerLocales(BungieLocales locale)
    {
        TraitCategory.SetLocale(locale);
    }

    public override string ToString()
    {
        return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
    }
}