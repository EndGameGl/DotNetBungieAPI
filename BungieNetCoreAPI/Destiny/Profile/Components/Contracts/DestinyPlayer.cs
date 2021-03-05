using BungieNetCoreAPI.Bungie.Applications;
using BungieNetCoreAPI.Destiny.Definitions.Classes;
using BungieNetCoreAPI.Destiny.Definitions.Genders;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.Races;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPlayer
    {
        public BungieNetUserInfo DestinyUserInfo { get; }
        public string CharacterClass { get; }
        public DefinitionHashPointer<DestinyClassDefinition> Class { get; }
        public DefinitionHashPointer<DestinyRaceDefinition> Race { get; }
        public DefinitionHashPointer<DestinyGenderDefinition> Gender { get; }
        public int CharacterLevel { get; }
        public int LightLevel { get; }
        public BungieNetUserInfo BungieNetUserInfo { get; }
        public string ClanName { get; }
        public string ClanTag { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Emblem { get; }

        [JsonConstructor]
        internal DestinyPlayer(BungieNetUserInfo destinyUserInfo, string characterClass, uint classHash, uint raceHash, uint genderHash, int characterLevel,
            int lightLevel, BungieNetUserInfo bungieNetUserInfo, string clanName, string clanTag, uint emblemHash)
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
