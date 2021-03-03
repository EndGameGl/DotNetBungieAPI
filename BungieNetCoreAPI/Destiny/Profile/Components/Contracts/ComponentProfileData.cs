using BungieNetCoreAPI.Bungie.Applications;
using BungieNetCoreAPI.Destiny.Definitions.Seasons;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentProfileData
    {
        public BungieNetUserInfo UserInfo { get; }
        public DateTime DateLastPlayed { get; }
        public DestinyGameVersions VersionsOwned { get; }
        public ReadOnlyCollection<long> CharacterIds { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinySeasonDefinition>> Seasons { get; }
        public DefinitionHashPointer<DestinySeasonDefinition> CurrentSeason { get; }
        public int CurrentSeasonRewardPowerCap { get; }

        [JsonConstructor]
        internal ComponentProfileData(BungieNetUserInfo userInfo, DateTime dateLastPlayed, DestinyGameVersions versionsOwned, long[] characterIds,
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
