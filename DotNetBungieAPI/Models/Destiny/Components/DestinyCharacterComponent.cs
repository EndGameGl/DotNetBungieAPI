using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.Destiny.Definitions.Classes;
using DotNetBungieAPI.Models.Destiny.Definitions.Genders;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.Races;
using DotNetBungieAPI.Models.Destiny.Definitions.Records;
using DotNetBungieAPI.Models.Destiny.Definitions.Stats;
using DotNetBungieAPI.Models.Destiny.Progressions;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    /// <summary>
    ///     This component contains base properties of the character. You'll probably want to always request this component,
    ///     but hey you do you.
    /// </summary>
    public sealed record DestinyCharacterComponent
    {
        /// <summary>
        ///     Every Destiny Profile has a membershipId. This is provided on the character as well for convenience.
        /// </summary>
        [JsonPropertyName("membershipId")]
        public long MembershipId { get; init; }

        /// <summary>
        ///     membershipType tells you the platform on which the character plays. Examine the BungieMembershipType enumeration
        ///     for possible values.
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
        ///     If this value is 525,600, then they played Destiny for a year. Or they're a very dedicated Rent fan. Note that this
        ///     includes idle time, not just time spent actually in activities shooting things.
        /// </summary>
        [JsonPropertyName("minutesPlayedTotal")]
        public long MinutesPlayedTotal { get; init; }

        /// <summary>
        ///     The user's calculated "Light Level". Light level is an indicator of your power that mostly matters in the end game,
        ///     once you've reached the maximum character level: it's a level that's dependent on the average Attack/Defense power
        ///     of your items.
        /// </summary>
        [JsonPropertyName("light")]
        public int Light { get; init; }

        /// <summary>
        ///     Your character's stats, such as Agility, Resilience, etc... *not* historical stats.
        /// </summary>
        [JsonPropertyName("stats")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyStatDefinition>, int> Stats { get; init; } =
            ReadOnlyDictionaries<DefinitionHashPointer<DestinyStatDefinition>, int>.Empty;

        /// <summary>
        ///     Use this hash to look up the character's DestinyRaceDefinition.
        /// </summary>
        [JsonPropertyName("raceHash")]
        public DefinitionHashPointer<DestinyRaceDefinition> Race { get; init; } =
            DefinitionHashPointer<DestinyRaceDefinition>.Empty;

        /// <summary>
        ///     Use this hash to look up the character's DestinyGenderDefinition.
        /// </summary>
        [JsonPropertyName("genderHash")]
        public DefinitionHashPointer<DestinyGenderDefinition> Gender { get; init; } =
            DefinitionHashPointer<DestinyGenderDefinition>.Empty;

        /// <summary>
        ///     Use this hash to look up the character's DestinyClassDefinition
        /// </summary>
        [JsonPropertyName("classHash")]
        public DefinitionHashPointer<DestinyClassDefinition> Class { get; init; } =
            DefinitionHashPointer<DestinyClassDefinition>.Empty;

        /// <summary>
        ///     Mostly for historical purposes at this point, this is an enumeration for the character's race.
        /// </summary>
        [JsonPropertyName("raceType")]
        public DestinyRace RaceType { get; init; }

        /// <summary>
        ///     Mostly for historical purposes at this point, this is an enumeration for the character's class.
        /// </summary>
        [JsonPropertyName("classType")]
        public DestinyClass ClassType { get; init; }

        /// <summary>
        ///     Mostly for historical purposes at this point, this is an enumeration for the character's Gender.
        /// </summary>
        [JsonPropertyName("genderType")]
        public DestinyGender GenderType { get; init; }

        /// <summary>
        ///     A shortcut path to the user's currently equipped emblem image. If you're just showing summary info for a user, this
        ///     is more convenient than examining their equipped emblem and looking up the definition.
        /// </summary>
        [JsonPropertyName("emblemPath")]
        public string EmblemPath { get; init; }

        /// <summary>
        ///     A shortcut path to the user's currently equipped emblem background image. If you're just showing summary info for a
        ///     user, this is more convenient than examining their equipped emblem and looking up the definition.
        /// </summary>
        [JsonPropertyName("emblemBackgroundPath")]
        public string EmblemBackgroundPath { get; init; }

        /// <summary>
        ///     The hash of the currently equipped emblem for the user. Can be used to look up the DestinyInventoryItemDefinition.
        /// </summary>
        [JsonPropertyName("emblemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Emblem { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        /// <summary>
        ///     A shortcut for getting the background color of the user's currently equipped emblem without having to do a
        ///     DestinyInventoryItemDefinition lookup.
        /// </summary>
        [JsonPropertyName("emblemColor")]
        public DestinyColor EmblemColor { get; init; }

        /// <summary>
        ///     The progression that indicates your character's level. Not their light level, but their character level: you know,
        ///     the thing you max out a couple hours in and then ignore for the sake of light level.
        /// </summary>
        [JsonPropertyName("levelProgression")]
        public DestinyProgression LevelProgression { get; init; }

        /// <summary>
        ///     The "base" level of your character, not accounting for any light level.
        /// </summary>
        [JsonPropertyName("baseCharacterLevel")]
        public int BaseCharacterLevel { get; init; }

        /// <summary>
        ///     A number between 0 and 100, indicating the whole and fractional % remaining to get to the next character level.
        /// </summary>
        [JsonPropertyName("percentToNextLevel")]
        public double PercentToNextLevel { get; init; }

        /// <summary>
        ///     If this Character has a title assigned to it, this is the identifier of the DestinyRecordDefinition that has that
        ///     title information.
        /// </summary>
        [JsonPropertyName("titleRecordHash")]
        public DefinitionHashPointer<DestinyRecordDefinition> TitleRecord { get; init; } =
            DefinitionHashPointer<DestinyRecordDefinition>.Empty;
    }
}