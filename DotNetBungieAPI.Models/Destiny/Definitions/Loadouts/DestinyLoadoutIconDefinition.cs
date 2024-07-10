using DotNetBungieAPI.Models.Attributes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Loadouts;

[DestinyDefinition(DefinitionsEnum.DestinyLoadoutIconDefinition)]
public sealed record DestinyLoadoutIconDefinition
    : IDestinyDefinition,
        IDeepEquatable<DestinyLoadoutIconDefinition>
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyLoadoutIconDefinition;

    [JsonPropertyName("iconImagePath")]
    public string IconImagePath { get; init; }

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }

    public bool DeepEquals(DestinyLoadoutIconDefinition other)
    {
        return other is not null
            && IconImagePath == other.IconImagePath
            && Blacklisted == other.Blacklisted
            && Hash == other.Hash
            && Index == other.Index
            && Redacted == other.Redacted;
    }
}
