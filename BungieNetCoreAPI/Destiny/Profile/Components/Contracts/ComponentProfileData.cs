using BungieNetCoreAPI.Bungie.Applications;
using BungieNetCoreAPI.Destiny.Definitions.Seasons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentProfileData
    {
        public BungieNetUserInfo UserInfo { get; }
        public DateTime DateLastPlayed { get; }
        public DestinyGameVersions VersionsOwned { get; }
        public string[] CharacterIds { get; }
        public List<DefinitionHashPointer<DestinySeasonDefinition>> Seasons { get; }
        public DefinitionHashPointer<DestinySeasonDefinition> CurrentSeason { get; }
        public int CurrentSeasonRewardPowerCap { get; }

        [JsonConstructor]
        private ComponentProfileData(BungieNetUserInfo userInfo, DateTime dateLastPlayed, DestinyGameVersions versionsOwned, string[] characterIds,
            List<uint> seasonHashes, uint currentSeasonHash, int currentSeasonRewardPowerCap)
        {
            UserInfo = userInfo;
            DateLastPlayed = dateLastPlayed;
            VersionsOwned = versionsOwned;
            CharacterIds = characterIds;
            Seasons = new List<DefinitionHashPointer<DestinySeasonDefinition>>();
            if (seasonHashes != null)
            {
                foreach (var seasonHash in seasonHashes)
                    Seasons.Add(new DefinitionHashPointer<DestinySeasonDefinition>(seasonHash, DefinitionsEnum.DestinySeasonDefinition));
            }
            CurrentSeason = new DefinitionHashPointer<DestinySeasonDefinition>(currentSeasonHash, DefinitionsEnum.DestinySeasonDefinition);
            CurrentSeasonRewardPowerCap = currentSeasonRewardPowerCap;
        }
    }
}
