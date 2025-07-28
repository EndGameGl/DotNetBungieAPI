namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Characters;

/// <summary>
///     This component contains base properties of the character. You'll probably want to always request this component, but hey you do you.
/// </summary>
public class DestinyCharacterComponent
{
    /// <summary>
    ///     Every Destiny Profile has a membershipId. This is provided on the character as well for convenience.
    /// </summary>
    [JsonPropertyName("membershipId")]
    public long MembershipId { get; set; }

    /// <summary>
    ///     membershipType tells you the platform on which the character plays. Examine the BungieMembershipType enumeration for possible values.
    /// </summary>
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    /// <summary>
    ///     The unique identifier for the character.
    /// </summary>
    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    /// <summary>
    ///     The last date that the user played Destiny.
    /// </summary>
    [JsonPropertyName("dateLastPlayed")]
    public DateTime DateLastPlayed { get; set; }

    /// <summary>
    ///     If the user is currently playing, this is how long they've been playing.
    /// </summary>
    [JsonPropertyName("minutesPlayedThisSession")]
    public long MinutesPlayedThisSession { get; set; }

    /// <summary>
    ///     If this value is 525,600, then they played Destiny for a year. Or they're a very dedicated Rent fan. Note that this includes idle time, not just time spent actually in activities shooting things.
    /// </summary>
    [JsonPropertyName("minutesPlayedTotal")]
    public long MinutesPlayedTotal { get; set; }

    /// <summary>
    ///     The user's calculated "Light Level". Light level is an indicator of your power that mostly matters in the end game, once you've reached the maximum character level: it's a level that's dependent on the average Attack/Defense power of your items.
    /// </summary>
    [JsonPropertyName("light")]
    public int Light { get; set; }

    /// <summary>
    ///     Your character's stats, such as Agility, Resilience, etc... *not* historical stats.
    /// <para />
    ///     You'll have to call a different endpoint for those.
    /// </summary>
    [JsonPropertyName("stats")]
    public Dictionary<uint, int>? Stats { get; set; }

    /// <summary>
    ///     Use this hash to look up the character's DestinyRaceDefinition.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyRaceDefinition>("Destiny.Definitions.DestinyRaceDefinition")]
    [JsonPropertyName("raceHash")]
    public uint RaceHash { get; set; }

    /// <summary>
    ///     Use this hash to look up the character's DestinyGenderDefinition.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyGenderDefinition>("Destiny.Definitions.DestinyGenderDefinition")]
    [JsonPropertyName("genderHash")]
    public uint GenderHash { get; set; }

    /// <summary>
    ///     Use this hash to look up the character's DestinyClassDefinition.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyClassDefinition>("Destiny.Definitions.DestinyClassDefinition")]
    [JsonPropertyName("classHash")]
    public uint ClassHash { get; set; }

    /// <summary>
    ///     Mostly for historical purposes at this point, this is an enumeration for the character's race.
    /// <para />
    ///     It'll be preferable in the general case to look up the related definition: but for some people this was too convenient to remove.
    /// </summary>
    [JsonPropertyName("raceType")]
    public Destiny.DestinyRace RaceType { get; set; }

    /// <summary>
    ///     Mostly for historical purposes at this point, this is an enumeration for the character's class.
    /// <para />
    ///     It'll be preferable in the general case to look up the related definition: but for some people this was too convenient to remove.
    /// </summary>
    [JsonPropertyName("classType")]
    public Destiny.DestinyClass ClassType { get; set; }

    /// <summary>
    ///     Mostly for historical purposes at this point, this is an enumeration for the character's Gender.
    /// <para />
    ///     It'll be preferable in the general case to look up the related definition: but for some people this was too convenient to remove. And yeah, it's an enumeration and not a boolean. Fight me.
    /// </summary>
    [JsonPropertyName("genderType")]
    public Destiny.DestinyGender GenderType { get; set; }

    /// <summary>
    ///     A shortcut path to the user's currently equipped emblem image. If you're just showing summary info for a user, this is more convenient than examining their equipped emblem and looking up the definition.
    /// </summary>
    [JsonPropertyName("emblemPath")]
    public string EmblemPath { get; set; }

    /// <summary>
    ///     A shortcut path to the user's currently equipped emblem background image. If you're just showing summary info for a user, this is more convenient than examining their equipped emblem and looking up the definition.
    /// </summary>
    [JsonPropertyName("emblemBackgroundPath")]
    public string EmblemBackgroundPath { get; set; }

    /// <summary>
    ///     The hash of the currently equipped emblem for the user. Can be used to look up the DestinyInventoryItemDefinition.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("emblemHash")]
    public uint EmblemHash { get; set; }

    /// <summary>
    ///     A shortcut for getting the background color of the user's currently equipped emblem without having to do a DestinyInventoryItemDefinition lookup.
    /// </summary>
    [JsonPropertyName("emblemColor")]
    public Destiny.Misc.DestinyColor? EmblemColor { get; set; }

    /// <summary>
    ///     The progression that indicates your character's level. Not their light level, but their character level: you know, the thing you max out a couple hours in and then ignore for the sake of light level.
    /// </summary>
    [JsonPropertyName("levelProgression")]
    public Destiny.DestinyProgression? LevelProgression { get; set; }

    /// <summary>
    ///     The "base" level of your character, not accounting for any light level.
    /// </summary>
    [JsonPropertyName("baseCharacterLevel")]
    public int BaseCharacterLevel { get; set; }

    /// <summary>
    ///     A number between 0 and 100, indicating the whole and fractional % remaining to get to the next character level.
    /// </summary>
    [JsonPropertyName("percentToNextLevel")]
    public float? PercentToNextLevel { get; set; }

    /// <summary>
    ///     If this Character has a title assigned to it, this is the identifier of the DestinyRecordDefinition that has that title information.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Records.DestinyRecordDefinition>("Destiny.Definitions.Records.DestinyRecordDefinition")]
    [JsonPropertyName("titleRecordHash")]
    public uint? TitleRecordHash { get; set; }
}
