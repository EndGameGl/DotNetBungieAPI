using System.Text.Json.Serialization;
using DotNetBungieAPI.Attributes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.UnlockValues
{
    /// <summary>
    ///     An Unlock Value is an internal integer value, stored on the server and used in a variety of ways, most frequently
    ///     for the gating/requirement checks that the game performs across all of its main features. They can also be used as
    ///     the storage data for mapped Progressions, Objectives, and other features that require storage of variable numeric
    ///     values.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyUnlockValueDefinition)]
    public sealed record DestinyUnlockValueDefinition : IDestinyDefinition, IDeepEquatable<DestinyUnlockValueDefinition>
    {
        public bool DeepEquals(DestinyUnlockValueDefinition other)
        {
            return other != null &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyUnlockValueDefinition;
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
    }
}