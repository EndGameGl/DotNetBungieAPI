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
    [DestinyDefinition(type: DefinitionsEnum.DestinySeasonDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinySeasonDefinition : IDestinyDefinition
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
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinySeasonDefinition(DestinyDefinitionDisplayProperties displayProperties, int seasonNumber, uint seasonPassProgressionHash, uint seasonPassUnlockHash,
            string startTimeInSeconds, uint? sealPresentationNodeHash, uint? seasonPassHash, DateTime? startDate, DateTime? endDate, string backgroundImagePath,
            uint artifactItemHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            SeasonNumber = seasonNumber;
            SeasonPassProgression = new DefinitionHashPointer<DestinyProgressionDefinition>(seasonPassProgressionHash, DefinitionsEnum.DestinyProgressionDefinition);
            SeasonPassUnlock = new DefinitionHashPointer<DestinyUnlockDefinition>(seasonPassUnlockHash, DefinitionsEnum.DestinyUnlockDefinition);
            StartTimeInSeconds = startTimeInSeconds;
            SealPresentationNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(sealPresentationNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            SeasonPass = new DefinitionHashPointer<DestinySeasonPassDefinition>(seasonPassHash, DefinitionsEnum.DestinySeasonPassDefinition);
            StartDate = startDate;
            EndDate = endDate;
            BackgroundImagePath = backgroundImagePath;
            ArtifactItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(artifactItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {(DisplayProperties.Name)}";
        }
    }
}
