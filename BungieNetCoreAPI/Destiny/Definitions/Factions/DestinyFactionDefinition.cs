﻿using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.Progressions;
using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Factions
{
    public class DestinyFactionDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> RewardItem { get; }
        public DefinitionHashPointer<DestinyVendorDefinition> RewardVendor { get; }
        public Dictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, uint> TokenValues { get; }

        [JsonConstructor]
        private DestinyFactionDefinition(uint progressionHash, uint rewardItemHash, uint rewardVendorHash, DestinyDefinitionDisplayProperties displayProperties,
            Dictionary<uint, uint> tokenValues,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            Progression = new DefinitionHashPointer<DestinyProgressionDefinition>(progressionHash, "DestinyProgressionDefinition");
            RewardItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(rewardItemHash, "DestinyInventoryItemDefinition");
            RewardVendor = new DefinitionHashPointer<DestinyVendorDefinition>(rewardVendorHash, "DestinyVendorDefinition");
            if (tokenValues == null)
                TokenValues = new Dictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, uint>();
            else
            {
                TokenValues = new Dictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, uint>();
                foreach (var value in tokenValues)
                {
                    TokenValues.Add(new DefinitionHashPointer<DestinyInventoryItemDefinition>(value.Key, "DestinyInventoryItemDefinition"), value.Value);
                }
            }
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
