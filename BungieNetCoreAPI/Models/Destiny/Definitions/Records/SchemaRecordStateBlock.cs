using NetBungieAPI.Models.Destiny.Definitions.Unlocks;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Records
{
    public sealed record SchemaRecordStateBlock : IDeepEquatable<SchemaRecordStateBlock>
    {
        [JsonPropertyName("claimedUnlockHash")]
        public DefinitionHashPointer<DestinyUnlockDefinition> ClaimedUnlock { get; init; } = DefinitionHashPointer<DestinyUnlockDefinition>.Empty;
        [JsonPropertyName("completeUnlockHash")]
        public DefinitionHashPointer<DestinyUnlockDefinition> CompleteUnlock { get; init; } = DefinitionHashPointer<DestinyUnlockDefinition>.Empty;
        [JsonPropertyName("featuredPriority")]
        public int FeaturedPriority { get; init; }
        [JsonPropertyName("obscuredString")]
        public string ObscuredString { get; init; }

        public bool DeepEquals(SchemaRecordStateBlock other)
        {
            return other != null &&
                   ClaimedUnlock.DeepEquals(other.ClaimedUnlock) &&
                   CompleteUnlock.DeepEquals(other.CompleteUnlock) &&
                   FeaturedPriority == other.FeaturedPriority &&
                   ObscuredString == other.ObscuredString;
        }
    }
}
