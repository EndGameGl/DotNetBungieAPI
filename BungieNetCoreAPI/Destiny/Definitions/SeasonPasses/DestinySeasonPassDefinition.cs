﻿using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SeasonPasses
{
    [DestinyDefinition("DestinySeasonPassDefinition")]
    public class DestinySeasonPassDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> RewardProgression { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> PrestigeProgression { get; }

        [JsonConstructor]
        private DestinySeasonPassDefinition(uint rewardProgressionHash, uint prestigeProgressionHash, DestinyDefinitionDisplayProperties displayProperties,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            RewardProgression = new DefinitionHashPointer<DestinyProgressionDefinition>(rewardProgressionHash, "DestinyProgressionDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            PrestigeProgression = new DefinitionHashPointer<DestinyProgressionDefinition>(prestigeProgressionHash, "DestinyProgressionDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
