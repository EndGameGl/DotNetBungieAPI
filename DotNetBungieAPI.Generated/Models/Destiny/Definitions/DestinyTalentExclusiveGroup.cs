using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyTalentExclusiveGroup
{

    [JsonPropertyName("groupHash")]
    public uint GroupHash { get; init; }

    [JsonPropertyName("loreHash")]
    public uint? LoreHash { get; init; }

    [JsonPropertyName("nodeHashes")]
    public List<uint> NodeHashes { get; init; }

    [JsonPropertyName("opposingGroupHashes")]
    public List<uint> OpposingGroupHashes { get; init; }

    [JsonPropertyName("opposingNodeHashes")]
    public List<uint> OpposingNodeHashes { get; init; }
}
