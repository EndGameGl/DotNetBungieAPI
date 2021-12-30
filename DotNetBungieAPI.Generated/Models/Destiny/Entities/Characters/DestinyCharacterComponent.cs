using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Characters;

/// <summary>
///     This component contains base properties of the character. You'll probably want to always request this component, but hey you do you.
/// </summary>
public sealed class DestinyCharacterComponent
{

    /// <summary>
    ///     Every Destiny Profile has a membershipId. This is provided on the character as well for convenience.
    /// </summary>
    [JsonPropertyName("membershipId")]
    public long MembershipId { get; init; }

    /// <summary>
    ///     membershipType tells you the platform on which the character plays. Examine the BungieMembershipType enumeration for possible values.
    /// </summary>
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }

    /// <summary>
    ///     The unique identifier for the character.
    /// </summary>
    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    /// <summary>
    ///     The last date that the user played Destiny.
    /// </summary>
    [JsonPropertyName("dateLastPlayed")]
    public DateTime DateLastPlayed { get; init; }

    /// <summary>
    ///     If the user is currently playing, this is how long they've been playing.
    /// </summary>
    [JsonPropertyName("minutesPlayedThisSession")]
    public long MinutesPlayedThisSession { get; init; }

    /// <summary>
    ///     If this value is 525,600, then they played Destiny for a year. Or they're a very dedicated Rent fan. Note that this includes idle time, not just time spent actually in activities shooting things.
    /// </summary>
    [JsonPropertyName("minutesPlayedTotal")]
    public long MinutesPlayedTotal { get; init; }

    /// <summary>
    ///     The user's calculated "Light Level". Light level is an indicator of your power that mostly matters in the end game, once you've reached the maximum character level: it's a level that's dependent on the average Attack/Defense power of your items.
    /// </summary>
    [JsonPropertyName("light")]
    public int Light { get; init; }

    /// <summary>
    ///     Your character's stats, such as Agility, Resilience, etc... *not* historical stats.
    /// <para />
    ///     You'll have to call a different endpoint for those.
    /// </summary>
    [JsonPropertyName("stats")]
    public Dictionary<uint, int> Stats { get; init; }

    /// <summary>
    ///     Use this hash to look up the character's DestinyRaceDefinition.
    /// </summary>
    [JsonPropertyName("raceHash")]
    public uint RaceHash { get; init; }

    /// <summary>
    ///     Use this hash to look up the character's DestinyGenderDefinition.
    /// </summary>
    [JsonPropertyName("genderHash")]
    public uint GenderHash { get; init; }

    /// <summary>
    ///     Use this hash to look up the character's DestinyClassDefinition.
    /// </summary>
    [JsonPropertyName("classHash")]
    public uint ClassHash { get; init; }

    /// <summary>
    ///     Mostly for historical purposes at this point, this is an enumeration for the character's race.
    /// <para />
    ///     It'll be preferable in the general case to look up the related definition: but for some people this was too convenient to remove.
    /// </summary>
    [JsonPropertyName("raceType")]
    public Destiny.DestinyRace RaceType { get; init; }

    /// <summary>
    ///     Mostly for historical purposes at this point, this is an enumeration for the character's class.
    /// <para />
    ///     It'll be preferable in the general case to look up the related definition: but for some people this was too convenient to remove.
    /// </summary>
    [JsonPropertyName("classType")]
    public Destiny.DestinyClass ClassType { get; init; }

    /// <summary>
    ///     Mostly for historical purposes at this point, this is an enumeration for the character's Gender.
    /// <para />
    ///     It'll be preferable in the general case to look up the related definition: but for some people this was too convenient to remove. And yeah, it's an enumeration and not a boolean. Fight me.
    /// </summary>
    [JsonPropertyName("genderType")]
    public Destiny.DestinyGender GenderType { get; init; }

    /// <summary>
    ///     A shortcut path to the user's currently equipped emblem image. If you're just showing summary info for a user, this is more convenient than examining their equipped emblem and looking up the definition.
    /// </summary>
    [JsonPropertyName("emblemPath")]
    public string EmblemPath { get; init; }

    /// <summary>
    ///     A shortcut path to the user's currently equipped emblem background image. If you're just showing summary info for a user, this is more convenient than examining their equipped emblem and looking up the definition.
    /// </summary>
    [JsonPropertyName("emblemBackgroundPath")]
    public string EmblemBackgroundPath { get; init; }

    /// <summary>
    ///     The hash of the currently equipped emblem for the user. Can be used to look up the DestinyInventoryItemDefinition.
    /// </summary>
    [JsonPropertyName("emblemHash")]
    public uint EmblemHash { get; init; }

    /// <summary>
    ///     A shortcut for getting the background color of the user's currently equipped emblem without having to do a DestinyInventoryItemDefinition lookup.
    /// </summary>
    [JsonPropertyName("emblemColor")]
    public Destiny.Misc.DestinyColor EmblemColor { get; init; }

    /// <summary>
    ///     The progression that indicates your character's level. Not their light level, but their character level: you know, the thing you max out a couple hours in and then ignore for the sake of light level.
    /// </summary>
    [JsonPropertyName("levelProgression")]
    public Destiny.DestinyProgression LevelProgression { get; init; }

    /// <summary>
    ///     The "base" level of your character, not accounting for any light level.
    /// </summary>
    [JsonPropertyName("baseCharacterLevel")]
    public int BaseCharacterLevel { get; init; }

    /// <summary>
    ///     A number between 0 and 100, indicating the whole and fractional % remaining to get to the next character level.
    /// </summary>
    [JsonPropertyName("percentToNextLevel")]
    public float PercentToNextLevel { get; init; }

    /// <summary>
    ///     If this Character has a title assigned to it, this is the identifier of the DestinyRecordDefinition that has that title information.
    /// </summary>
    [JsonPropertyName("titleRecordHash")]
    public uint? TitleRecordHash { get; init; }
}
