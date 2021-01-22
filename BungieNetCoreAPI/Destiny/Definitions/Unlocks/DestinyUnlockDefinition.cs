﻿using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Unlocks
{
    [DestinyDefinition(name: "DestinyUnlockDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyUnlockDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// Always 0 for now, useless
        /// </summary>
        public int Scope { get; }
        /// <summary>
        /// Always 0 for now, useless
        /// </summary>
        public int UnlockType { get; }

        [JsonConstructor]
        private DestinyUnlockDefinition(DestinyDefinitionDisplayProperties displayProperties, int scope, int unlockType, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            Scope = scope;
            UnlockType = unlockType;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
