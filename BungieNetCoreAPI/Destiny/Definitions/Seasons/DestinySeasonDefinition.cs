using BungieNetCoreAPI.Attributes;
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
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public int SeasonNumber { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> SeasonPassProgression { get; }
        public DefinitionHashPointer<DestinyUnlockDefinition> SeasonPassUnlock { get; }
        public string StartTimeInSeconds { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> SealPresentationNode { get; }
        public DefinitionHashPointer<DestinySeasonPassDefinition> SeasonPass { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }

        [JsonConstructor]
        private DestinySeasonDefinition(DestinyDefinitionDisplayProperties displayProperties, int seasonNumber, uint seasonPassProgressionHash, uint seasonPassUnlockHash,
            string startTimeInSeconds, uint? sealPresentationNodeHash, uint? seasonPassHash, DateTime? startDate, DateTime? endDate,
            bool blacklisted, uint hash, int index, bool redacted) : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            SeasonNumber = seasonNumber;
            SeasonPassProgression = new DefinitionHashPointer<DestinyProgressionDefinition>(seasonPassProgressionHash, "DestinyProgressionDefinition");
            SeasonPassUnlock = new DefinitionHashPointer<DestinyUnlockDefinition>(seasonPassUnlockHash, "DestinyUnlockDefinition");
            StartTimeInSeconds = startTimeInSeconds;
            SealPresentationNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(sealPresentationNodeHash, "DestinyPresentationNodeDefinition");
            SeasonPass = new DefinitionHashPointer<DestinySeasonPassDefinition>(seasonPassHash, "DestinySeasonPassDefinition");
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string ToString()
        {
            return $"{Hash} {(DisplayProperties.Name)}";
        }
    }
}
