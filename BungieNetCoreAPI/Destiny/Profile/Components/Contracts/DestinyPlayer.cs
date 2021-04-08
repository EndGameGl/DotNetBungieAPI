using NetBungieAPI.Destiny.Definitions.Classes;
using NetBungieAPI.Destiny.Definitions.Genders;
using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.Races;
using NetBungieAPI.Models.User;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPlayer
    {
        public UserInfoCard DestinyUserInfo { get; init; }
        public string CharacterClass { get; init; }
        public DefinitionHashPointer<DestinyClassDefinition> Class { get; init; }
        public DefinitionHashPointer<DestinyRaceDefinition> Race { get; init; }
        public DefinitionHashPointer<DestinyGenderDefinition> Gender { get; init; }
        public int CharacterLevel { get; init; }
        public int LightLevel { get; init; }
        public UserInfoCard BungieNetUserInfo { get; init; }
        public string ClanName { get; init; }
        public string ClanTag { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Emblem { get; init; }

        [JsonConstructor]
        internal DestinyPlayer(UserInfoCard destinyUserInfo, string characterClass, uint classHash, uint raceHash, uint genderHash, int characterLevel,
            int lightLevel, UserInfoCard bungieNetUserInfo, string clanName, string clanTag, uint emblemHash)
        {
            DestinyUserInfo = destinyUserInfo;
            CharacterClass = characterClass;
            Class = new DefinitionHashPointer<DestinyClassDefinition>(classHash, DefinitionsEnum.DestinyClassDefinition);
            Race = new DefinitionHashPointer<DestinyRaceDefinition>(raceHash, DefinitionsEnum.DestinyRaceDefinition);
            Gender = new DefinitionHashPointer<DestinyGenderDefinition>(genderHash, DefinitionsEnum.DestinyGenderDefinition);
            CharacterLevel = characterLevel;
            LightLevel = lightLevel;
            BungieNetUserInfo = bungieNetUserInfo;
            ClanName = clanName;
            ClanTag = clanTag;
            Emblem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(emblemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
        }
    }
}
