using DotNetBungieAPI.Models.Attributes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Loadouts;

[DestinyDefinition(DefinitionsEnum.DestinyLoadoutNameDefinition)]
public sealed record DestinyLoadoutNameDefinition : IDestinyDefinition, IDeepEquatable<DestinyLoadoutNameDefinition>
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyLoadoutNameDefinition;

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }

    public bool DeepEquals(DestinyLoadoutNameDefinition other)
    {
        return other is not null &&
               Name == other.Name &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }
}
