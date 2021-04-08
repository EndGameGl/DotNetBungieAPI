using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.Classes;
using NetBungieAPI.Models.Destiny.Definitions.Genders;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.Races;
using NetBungieAPI.Models.Destiny.Definitions.Records;
using NetBungieAPI.Models.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCharacterComponent
    {
        public long MembershipId { get; init; }
        public BungieMembershipType MembershipType { get; init; }
        public long CharacterId { get; init; }
        public DateTime DateLastPlayed { get; init; }
        public long MinutesPlayedThisSession { get; init; }
        public long MinutesPlayedTotal { get; init; }
        public int Light { get; init; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyStatDefinition>, int> Stats { get; init; }
        public DefinitionHashPointer<DestinyRaceDefinition> Race { get; init; }
        public DefinitionHashPointer<DestinyGenderDefinition> Gender { get; init; }
        public DefinitionHashPointer<DestinyClassDefinition> Class { get; init; }
        public DestinyRace RaceType { get; init; }
        public DestinyClass ClassType { get; init; }
        public DestinyGender GenderType { get; init; }
        public string EmblemPath { get; init; }
        public string EmblemBackgroundPath { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Emblem { get; init; }
        public DestinyColor EmblemColor { get; init; }
        public DestinyProgression LevelProgression { get; init; }
        public int BaseCharacterLevel { get; init; }
        public double PercentToNextLevel { get; init; }
        public DefinitionHashPointer<DestinyRecordDefinition> TitleRecord { get; init; }
    }
}
