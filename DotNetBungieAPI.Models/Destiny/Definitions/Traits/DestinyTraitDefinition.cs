using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Traits;

[DestinyDefinition(DefinitionsEnum.DestinyTraitDefinition)]
public sealed record DestinyTraitDefinition : IDestinyDefinition, IDeepEquatable<DestinyTraitDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
    
    /// <summary>
    ///     An identifier for how this trait can be displayed. For example: a 'keyword' hint to show an explanation for certain related terms.
    /// </summary>
    [JsonPropertyName("displayHint")]
    public string DisplayHint { get; init; }

    public bool DeepEquals(DestinyTraitDefinition other)
    {
        return other != null &&
               DisplayProperties.DeepEquals(other.DisplayProperties) &&
               DisplayHint == other.DisplayHint &&
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
}