using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyClassDefinition
{

    [JsonPropertyName("classType")]
    public Destiny.DestinyClass ClassType { get; init; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("genderedClassNames")]
    public Dictionary<Destiny.DestinyGender, string> GenderedClassNames { get; init; }

    [JsonPropertyName("genderedClassNamesByGenderHash")]
    public Dictionary<uint, string> GenderedClassNamesByGenderHash { get; init; }

    [JsonPropertyName("mentorVendorHash")]
    public uint? MentorVendorHash { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
