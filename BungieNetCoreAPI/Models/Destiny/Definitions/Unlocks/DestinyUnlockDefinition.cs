using NetBungieAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NetBungieAPI.Models.Destiny.Definitions.Unlocks
{
    [DestinyDefinition(DefinitionsEnum.DestinyUnlockDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyUnlockDefinition : IDestinyDefinition, IDeepEquatable<DestinyUnlockDefinition>
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        /// <summary>
        /// Always 0 for now, useless
        /// </summary>
        public int Scope { get; init; }
        /// <summary>
        /// Always 0 for now, useless
        /// </summary>
        public int UnlockType { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

        [JsonConstructor]
        internal DestinyUnlockDefinition(DestinyDisplayPropertiesDefinition displayProperties, int scope, int unlockType, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            Scope = scope;
            UnlockType = unlockType;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
        public void MapValues()
        {
            return;
        }
        public bool DeepEquals(DestinyUnlockDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Scope == other.Scope &&
                   UnlockType == other.UnlockType &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
