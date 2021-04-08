using NetBungieAPI.Destiny.Definitions.Seasons;
using NetBungieAPI.Models.User;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class ProfileDataComponent
    {
        public UserInfoCard UserInfo { get; init; }
        public DateTime DateLastPlayed { get; init; }
        public DestinyGameVersions VersionsOwned { get; init; }
        public ReadOnlyCollection<long> CharacterIds { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinySeasonDefinition>> Seasons { get; init; }
        public DefinitionHashPointer<DestinySeasonDefinition> CurrentSeason { get; init; }
        public int CurrentSeasonRewardPowerCap { get; init; }

        [JsonConstructor]
        internal ProfileDataComponent(UserInfoCard userInfo, DateTime dateLastPlayed, DestinyGameVersions versionsOwned, long[] characterIds,
            uint[] seasonHashes, uint currentSeasonHash, int currentSeasonRewardPowerCap)
        {
            UserInfo = userInfo;
            DateLastPlayed = dateLastPlayed;
            VersionsOwned = versionsOwned;
            CharacterIds = characterIds.AsReadOnlyOrEmpty();
            Seasons = seasonHashes.DefinitionsAsReadOnlyOrEmpty<DestinySeasonDefinition>(DefinitionsEnum.DestinySeasonDefinition);
            CurrentSeason = new DefinitionHashPointer<DestinySeasonDefinition>(currentSeasonHash, DefinitionsEnum.DestinySeasonDefinition);
            CurrentSeasonRewardPowerCap = currentSeasonRewardPowerCap;
        }
    }
}
