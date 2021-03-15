using NetBungieAPI.Bungie.Applications;
using NetBungieAPI.Destiny.Definitions.Seasons;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class ProfileDataComponent
    {
        public BungieNetUserInfo UserInfo { get; }
        public DateTime DateLastPlayed { get; }
        public DestinyGameVersions VersionsOwned { get; }
        public ReadOnlyCollection<long> CharacterIds { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinySeasonDefinition>> Seasons { get; }
        public DefinitionHashPointer<DestinySeasonDefinition> CurrentSeason { get; }
        public int CurrentSeasonRewardPowerCap { get; }

        [JsonConstructor]
        internal ProfileDataComponent(BungieNetUserInfo userInfo, DateTime dateLastPlayed, DestinyGameVersions versionsOwned, long[] characterIds,
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
