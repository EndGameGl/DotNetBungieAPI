﻿using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;

namespace NetBungieAPI.Models.Destiny.Definitions.Unlocks
{
    /// <summary>
    ///     Unlock Flags are small bits (literally, a bit, as in a boolean value) that the game server uses for an extremely
    ///     wide range of state checks, progress storage, and other interesting tidbits of information.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyUnlockDefinition)]
    public sealed record DestinyUnlockDefinition : IDestinyDefinition, IDeepEquatable<DestinyUnlockDefinition>
    {
        /// <summary>
        ///     Sometimes, but not frequently, these unlock flags also have human readable information: usually when they are being
        ///     directly tested for some requirement, in which case the string is a localized description of why the requirement
        ///     check failed.
        /// </summary>
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        ///     Always 0 for now, useless
        /// </summary>
        [JsonPropertyName("scope")]
        public int Scope { get; init; }

        /// <summary>
        ///     Always 0 for now, useless
        /// </summary>
        [JsonPropertyName("unlockType")]
        public int UnlockType { get; init; }

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

        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}