using DotNetBungieAPI.Models.Attributes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.SandboxPatterns;

[DestinyDefinition(DefinitionsEnum.DestinySandboxPatternDefinition)]
public sealed record DestinySandboxPatternDefinition : IDestinyDefinition,
    IDeepEquatable<DestinySandboxPatternDefinition>
{
    [JsonPropertyName("patternHash")] 
    public uint PatternHash { get; init; }
    
    [JsonPropertyName("patternGlobalTagIdHash")]
    public uint PatternGlobalTagIdHash { get; init; }

    [JsonPropertyName("weaponContentGroupHash")]
    public uint WeaponContentGroupHash { get; init; }

    [JsonPropertyName("weaponTranslationGroupHash")]
    public uint WeaponTranslationGroupHash { get; init; }
    
    [JsonPropertyName("weaponTypeHash")] 
    public uint? WeaponTypeHash { get; init; }
    
    [JsonPropertyName("weaponType")] 
    public int WeaponType { get; init; }
    
    [JsonPropertyName("filters")]
    public ReadOnlyCollection<DestinyArrangementRegionFilterDefinition> Filters { get; init; } =
        ReadOnlyCollections<DestinyArrangementRegionFilterDefinition>.Empty;

    public bool DeepEquals(DestinySandboxPatternDefinition other)
    {
        return other != null &&
               PatternGlobalTagIdHash == other.PatternGlobalTagIdHash &&
               PatternHash == other.PatternHash &&
               WeaponContentGroupHash == other.WeaponContentGroupHash &&
               WeaponTranslationGroupHash == other.WeaponTranslationGroupHash &&
               WeaponType == other.WeaponType &&
               WeaponTypeHash == other.WeaponTypeHash &&
               Filters.DeepEqualsReadOnlyCollections(other.Filters) &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinySandboxPatternDefinition;
    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")] public uint Hash { get; init; }

    [JsonPropertyName("index")] public int Index { get; init; }

    [JsonPropertyName("redacted")] public bool Redacted { get; init; }
}