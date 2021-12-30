using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyRaceDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("raceType")]
    public Destiny.DestinyRace RaceType { get; init; }

    [JsonPropertyName("genderedRaceNames")]
    public Dictionary<Destiny.DestinyGender, string> GenderedRaceNames { get; init; }

    [JsonPropertyName("genderedRaceNamesByGenderHash")]
    public Dictionary<uint, string> GenderedRaceNamesByGenderHash { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
