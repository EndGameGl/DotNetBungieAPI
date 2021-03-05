﻿using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockExpressionMappings
{
    /// <summary>
    /// Empty definition at the moment
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyUnlockExpressionMappingDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyUnlockExpressionMappingDefinition : IDestinyDefinition
    {
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
        [JsonConstructor]
        private DestinyUnlockExpressionMappingDefinition(bool blacklisted, uint hash, int index, bool redacted) { }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
