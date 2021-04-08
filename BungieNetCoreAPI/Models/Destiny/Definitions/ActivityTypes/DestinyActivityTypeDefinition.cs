using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.ActivityTypes
{
    /// <summary>
    /// The definition for an Activity Type.
    /// <para/>
    /// In Destiny 2, an Activity Type represents a conceptual categorization of Activities.
    /// <para/>
    /// These are most commonly used in the game for the subtitle under Activities, but BNet uses them extensively to identify and group activities by their common properties.
    /// <para/>
    /// Unfortunately, there has been a movement away from providing the richer data in Destiny 2 that we used to get in Destiny 1 for Activity Types.For instance, Nightfalls are grouped under the same Activity Type as regular Strikes.
    /// <para />
    /// For this reason, BNet will eventually migrate toward Activity Modes as a better indicator of activity category. But for the time being, it is still referred to in many places across our codebase.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyActivityTypeDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyActivityTypeDefinition : IDestinyDefinition, IDeepEquatable<DestinyActivityTypeDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }

        [JsonPropertyName("hash")]
        public uint Hash { get; init; }

        [JsonPropertyName("index")]
        public int Index { get; init; }

        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
        public bool DeepEquals(DestinyActivityTypeDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            return;
        }
    }
}
