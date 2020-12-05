using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using BungieNetCoreAPI.Destiny.Definitions.Progressions;
using BungieNetCoreAPI.Destiny.Definitions.SeasonPasses;
using BungieNetCoreAPI.Destiny.Definitions.Unlocks;
using Newtonsoft.Json;
using System;

namespace BungieNetCoreAPI.Destiny.Definitions.Seasons
{
    [DestinyDefinition("DestinySeasonDefinition")]
    public class DestinySeasonDefinition : DestinyDefinition
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> ArtifactItem { get; }
        public string BackgroundImagePath { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public int SeasonNumber { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> SealPresentationNode { get; }
        public DefinitionHashPointer<DestinySeasonPassDefinition> SeasonPass { get; }     
        public DefinitionHashPointer<DestinyProgressionDefinition> SeasonPassProgression { get; }
        public DefinitionHashPointer<DestinyUnlockDefinition> SeasonPassUnlock { get; }
        public string StartTimeInSeconds { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }

        [JsonConstructor]
        private DestinySeasonDefinition(DestinyDefinitionDisplayProperties displayProperties, int seasonNumber, uint seasonPassProgressionHash, uint seasonPassUnlockHash,
            string startTimeInSeconds, uint? sealPresentationNodeHash, uint? seasonPassHash, DateTime? startDate, DateTime? endDate, string backgroundImagePath,
            uint artifactItemHash, bool blacklisted, uint hash, int index, bool redacted) : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            SeasonNumber = seasonNumber;
            SeasonPassProgression = new DefinitionHashPointer<DestinyProgressionDefinition>(seasonPassProgressionHash, "DestinyProgressionDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            SeasonPassUnlock = new DefinitionHashPointer<DestinyUnlockDefinition>(seasonPassUnlockHash, "DestinyUnlockDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            StartTimeInSeconds = startTimeInSeconds;
            SealPresentationNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(sealPresentationNodeHash, "DestinyPresentationNodeDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            SeasonPass = new DefinitionHashPointer<DestinySeasonPassDefinition>(seasonPassHash, "DestinySeasonPassDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            StartDate = startDate;
            EndDate = endDate;
            BackgroundImagePath = backgroundImagePath;
            ArtifactItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(artifactItemHash, "DestinyInventoryItemDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }

        public override string ToString()
        {
            return $"{Hash} {(DisplayProperties.Name)}";
        }
    }
}
