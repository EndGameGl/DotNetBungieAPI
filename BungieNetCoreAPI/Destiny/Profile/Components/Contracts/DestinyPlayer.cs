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
        public UserInfoCard DestinyUserInfo { get; }
        public string CharacterClass { get; }
        public DefinitionHashPointer<DestinyClassDefinition> Class { get; }
        public DefinitionHashPointer<DestinyRaceDefinition> Race { get; }
        public DefinitionHashPointer<DestinyGenderDefinition> Gender { get; }
        public int CharacterLevel { get; }
        public int LightLevel { get; }
        public UserInfoCard BungieNetUserInfo { get; }
        public string ClanName { get; }
        public string ClanTag { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Emblem { get; }

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
