﻿using System.Text.Json.Serialization;
using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.ActivityModifiers
{
    /// <summary>
    ///     Modifiers - in Destiny 1, these were referred to as "Skulls" - are changes that can be applied to an Activity.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyActivityModifierDefinition)]
    public sealed record DestinyActivityModifierDefinition : IDestinyDefinition,
        IDeepEquatable<DestinyActivityModifierDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        public bool DeepEquals(DestinyActivityModifierDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyActivityModifierDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }

        [JsonPropertyName("hash")] public uint Hash { get; init; }

        [JsonPropertyName("index")] public int Index { get; init; }

        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
        }

        public void SetPointerLocales(BungieLocales locale)
        {
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}