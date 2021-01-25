﻿using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityModes
{
    [DestinyDefinition(name: "DestinyActivityModeDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyActivityModeDefinition : IDestinyDefinition
    {
        public int ActivityModeCategory { get; }
        public Dictionary<uint, DestinyActivityModeType> ActivityModeMappings { get; }
        public bool Display { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public string FriendlyName { get; }
        public bool IsAggregateMode { get; }
        public bool IsTeamBased { get; }
        public DestinyActivityModeType ModeType { get; }
        public int Order { get; }
        public List<DefinitionHashPointer<DestinyActivityModeDefinition>> ParentHashes { get; }
        public string PgcrImage { get; }
        public bool SupportsFeedFiltering { get; }
        public int Tier { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyActivityModeDefinition(int activityModeCategory, Dictionary<uint, DestinyActivityModeType> activityModeMappings, bool display, 
            DestinyDefinitionDisplayProperties displayProperties, string friendlyName, bool isAggregateMode, bool isTeamBased, DestinyActivityModeType modeType, int order, 
            List<uint> parentHashes, string pgcrImage, bool supportsFeedFiltering, int tier, bool blacklisted, uint hash, int index, bool redacted)
        {
            ActivityModeCategory = activityModeCategory;
            if (activityModeMappings == null)
                ActivityModeMappings = new Dictionary<uint, DestinyActivityModeType>();
            else
                ActivityModeMappings = activityModeMappings;
            Display = display;
            DisplayProperties = displayProperties;
            FriendlyName = friendlyName;
            IsAggregateMode = isAggregateMode;
            IsTeamBased = isTeamBased;
            ModeType = modeType;
            Order = order;
            if (parentHashes == null)
                ParentHashes = new List<DefinitionHashPointer<DestinyActivityModeDefinition>>();
            else
            {
                ParentHashes = new List<DefinitionHashPointer<DestinyActivityModeDefinition>>();
                foreach (var parentHash in parentHashes)
                {
                    ParentHashes.Add(new DefinitionHashPointer<DestinyActivityModeDefinition>(parentHash, DefinitionsEnum.DestinyActivityModeDefinition));
                }
            }
            PgcrImage = pgcrImage;
            SupportsFeedFiltering = supportsFeedFiltering;
            Tier = tier;
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
