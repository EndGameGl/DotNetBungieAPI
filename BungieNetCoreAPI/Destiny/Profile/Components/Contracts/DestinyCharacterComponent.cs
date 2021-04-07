using NetBungieAPI.Bungie;
using NetBungieAPI.Destiny.Definitions.Classes;
using NetBungieAPI.Destiny.Definitions.Genders;
using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.Races;
using NetBungieAPI.Destiny.Definitions.Records;
using NetBungieAPI.Destiny.Definitions.Stats;
using NetBungieAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCharacterComponent
    {
        public long MembershipId { get; }
        public BungieMembershipType MembershipType { get; }
        public long CharacterId { get; }
        public DateTime DateLastPlayed { get; }
        public long MinutesPlayedThisSession { get; }
        public long MinutesPlayedTotal { get; }
        public int Light { get; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyStatDefinition>, int> Stats { get; }
        public DefinitionHashPointer<DestinyRaceDefinition> Race { get; }
        public DefinitionHashPointer<DestinyGenderDefinition> Gender { get; }
        public DefinitionHashPointer<DestinyClassDefinition> Class { get; }
        public DestinyRaceType RaceType { get; }
        public DestinyClassType ClassType { get; }
        public DestinyGenderTypes GenderType { get; }
        public string EmblemPath { get; }
        public string EmblemBackgroundPath { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Emblem { get; }
        public DestinyColor EmblemColor { get; }
        public DestinyProgression LevelProgression { get; }
        public int BaseCharacterLevel { get; }
        public double PercentToNextLevel { get; }
        public DefinitionHashPointer<DestinyRecordDefinition> TitleRecord { get; }

        [JsonConstructor]
        internal DestinyCharacterComponent(long membershipId, BungieMembershipType membershipType, long characterId, DateTime dateLastPlayed,
            long minutesPlayedThisSession, long minutesPlayedTotal, int light, Dictionary<uint, int> stats, uint raceHash, uint genderHash,
            uint classHash, DestinyRaceType raceType, DestinyClassType classType, DestinyGenderTypes genderType, string emblemPath,
            string emblemBackgroundPath, uint emblemHash, DestinyColor emblemColor, DestinyProgression levelProgression,
            int baseCharacterLevel, double percentToNextLevel, uint? titleRecordHash)
        {
            MembershipId = membershipId;
            MembershipType = membershipType;
            CharacterId = characterId;
            DateLastPlayed = dateLastPlayed;
            MinutesPlayedThisSession = minutesPlayedThisSession;
            MinutesPlayedTotal = minutesPlayedTotal;
            Light = light;
            Stats = stats.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyStatDefinition, int>(DefinitionsEnum.DestinyStatDefinition);
            Race = new DefinitionHashPointer<DestinyRaceDefinition>(raceHash, DefinitionsEnum.DestinyRaceDefinition);
            Gender = new DefinitionHashPointer<DestinyGenderDefinition>(genderHash, DefinitionsEnum.DestinyGenderDefinition);
            Class = new DefinitionHashPointer<DestinyClassDefinition>(classHash, DefinitionsEnum.DestinyClassDefinition);
            RaceType = raceType;
            ClassType = classType;
            GenderType = genderType;
            EmblemPath = emblemPath;
            EmblemBackgroundPath = emblemBackgroundPath;
            Emblem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(emblemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            EmblemColor = emblemColor;
            LevelProgression = levelProgression;
            BaseCharacterLevel = baseCharacterLevel;
            PercentToNextLevel = percentToNextLevel;
            TitleRecord = new DefinitionHashPointer<DestinyRecordDefinition>(titleRecordHash, DefinitionsEnum.DestinyRecordDefinition);
        }
    }
}
