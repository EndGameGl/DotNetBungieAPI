﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardMappings
{
    public class DestinyRewardMappingDefinition : DestinyDefinition
    {
        public uint MappingHash { get; }
        public int MappingIndex { get; }
        public bool IsGlobal { get; }
        [JsonConstructor]
        private DestinyRewardMappingDefinition(uint mappingHash, int mappingIndex, bool isGlobal, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            MappingHash = mappingHash;
            MappingIndex = mappingIndex;
            IsGlobal = IsGlobal;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
