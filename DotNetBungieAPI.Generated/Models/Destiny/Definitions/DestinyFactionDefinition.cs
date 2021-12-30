using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyFactionDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("progressionHash")]
    public uint ProgressionHash { get; init; }

    [JsonPropertyName("tokenValues")]
    public Dictionary<uint, uint> TokenValues { get; init; }

    [JsonPropertyName("rewardItemHash")]
    public uint RewardItemHash { get; init; }

    [JsonPropertyName("rewardVendorHash")]
    public uint RewardVendorHash { get; init; }

    [JsonPropertyName("vendors")]
    public List<Destiny.Definitions.DestinyFactionVendorDefinition> Vendors { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
