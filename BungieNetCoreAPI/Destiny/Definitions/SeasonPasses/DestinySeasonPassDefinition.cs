using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SeasonPasses
{
    [DestinyDefinition(name: "DestinySeasonPassDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinySeasonPassDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> RewardProgression { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> PrestigeProgression { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinySeasonPassDefinition(uint rewardProgressionHash, uint prestigeProgressionHash, DestinyDefinitionDisplayProperties displayProperties,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            RewardProgression = new DefinitionHashPointer<DestinyProgressionDefinition>(rewardProgressionHash, DefinitionsEnum.DestinyProgressionDefinition);
            PrestigeProgression = new DefinitionHashPointer<DestinyProgressionDefinition>(prestigeProgressionHash, DefinitionsEnum.DestinyProgressionDefinition);
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
