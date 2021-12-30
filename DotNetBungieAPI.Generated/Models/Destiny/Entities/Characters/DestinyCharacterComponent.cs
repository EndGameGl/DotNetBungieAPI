using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Characters;

public sealed class DestinyCharacterComponent
{

    [JsonPropertyName("membershipId")]
    public long MembershipId { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("dateLastPlayed")]
    public DateTime DateLastPlayed { get; init; }

    [JsonPropertyName("minutesPlayedThisSession")]
    public long MinutesPlayedThisSession { get; init; }

    [JsonPropertyName("minutesPlayedTotal")]
    public long MinutesPlayedTotal { get; init; }

    [JsonPropertyName("light")]
    public int Light { get; init; }

    [JsonPropertyName("stats")]
    public Dictionary<uint, int> Stats { get; init; }

    [JsonPropertyName("raceHash")]
    public uint RaceHash { get; init; }

    [JsonPropertyName("genderHash")]
    public uint GenderHash { get; init; }

    [JsonPropertyName("classHash")]
    public uint ClassHash { get; init; }

    [JsonPropertyName("raceType")]
    public Destiny.DestinyRace RaceType { get; init; }

    [JsonPropertyName("classType")]
    public Destiny.DestinyClass ClassType { get; init; }

    [JsonPropertyName("genderType")]
    public Destiny.DestinyGender GenderType { get; init; }

    [JsonPropertyName("emblemPath")]
    public string EmblemPath { get; init; }

    [JsonPropertyName("emblemBackgroundPath")]
    public string EmblemBackgroundPath { get; init; }

    [JsonPropertyName("emblemHash")]
    public uint EmblemHash { get; init; }

    [JsonPropertyName("emblemColor")]
    public Destiny.Misc.DestinyColor EmblemColor { get; init; }

    [JsonPropertyName("levelProgression")]
    public Destiny.DestinyProgression LevelProgression { get; init; }

    [JsonPropertyName("baseCharacterLevel")]
    public int BaseCharacterLevel { get; init; }

    [JsonPropertyName("percentToNextLevel")]
    public float PercentToNextLevel { get; init; }

    [JsonPropertyName("titleRecordHash")]
    public uint? TitleRecordHash { get; init; }
}
