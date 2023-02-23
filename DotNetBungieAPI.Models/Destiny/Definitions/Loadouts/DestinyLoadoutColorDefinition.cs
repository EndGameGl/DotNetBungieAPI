using DotNetBungieAPI.Models.Attributes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Loadouts;

[DestinyDefinition(DefinitionsEnum.DestinyLoadoutColorDefinition)]
public sealed record DestinyLoadoutColorDefinition : IDestinyDefinition, IDeepEquatable<DestinyLoadoutColorDefinition>
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyLoadoutColorDefinition;

    [JsonPropertyName("colorImagePath")]
    public string ColorImagePath { get; init; }

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }

    public bool DeepEquals(DestinyLoadoutColorDefinition other)
    {
        return other is not null &&
               ColorImagePath == other.ColorImagePath &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }
}
